namespace Pagkakakilanlan;

sealed class User_LockHDL : ICQRSRequestHandler<User_Lock>
{
    readonly IPermissionVerifier _permissionVerifier;
    readonly IDbContextFactory<Context> _contextFactory;
    readonly IAuditInfoProvider _auditInfoProvider;
    readonly IIdGenerator _idGenerator;

    public User_LockHDL(IPermissionVerifier permissionVerifier, IDbContextFactory<Context> contextFactory, IAuditInfoProvider auditInfoProvider, IIdGenerator idGenerator)
    {
        _permissionVerifier = permissionVerifier;
        _contextFactory = contextFactory;
        _auditInfoProvider = auditInfoProvider;
        _idGenerator = idGenerator;
    }

    public async Task<ICQRSResponse> Handle(User_Lock request, CancellationToken cancellationToken)
    {
        if (await _permissionVerifier.Verify(Permissions.User.Lock, cancellationToken) == false)
        {
            return new VerifyPermissionFailed { PermissionId = Permissions.User.Lock };
        }

        using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        var user = await context.Users
            .Where(user => user.Id == request.Id && (user.IsDeleted == false))
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            return new User_NotFound { Id = request.Id };
        }

        if (user.StatusId == UserStatuses.Locked)
        {
            return new User_StatusAlreadySet
            {
                UserId = user.Id,
                StatusId = UserStatuses.Locked
            };
        }

        var auditInfo = await _auditInfoProvider.Get(cancellationToken);
        var userId = auditInfo.UserId();

        if (userId is null)
        {
            return InvalidCurrentUser.Instance;
        }

        var statusChangeActivity = new UserStatusChangeActivity
        {
            Id = _idGenerator.Generate(),
            UserId = user.Id,
            FromId = user.StatusId,
            ToId = UserStatuses.Locked,
            ChangedById = userId.Value,
            ChangedOn = auditInfo.Timestamp(),
            Remarks = request.Remarks
        };
        user.StatusId = UserStatuses.Locked;
        context.Users.Update(user);
        context.UserStatusChangeActivities.Add(statusChangeActivity);
        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return Success.Instance;
    }
}
