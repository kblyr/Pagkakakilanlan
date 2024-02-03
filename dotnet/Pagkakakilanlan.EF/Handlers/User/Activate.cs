namespace Pagkakakilanlan;

sealed class User_ActivateHDL : ICQRSRequestHandler<User_Activate>
{
    readonly IDbContextFactory<Context> _contextFactory;
    readonly IPermissionVerifier _permissionVerifier;
    readonly IAuditInfoProvider _auditInfoProvider;
    readonly IIdGenerator _idGenerator;

    public User_ActivateHDL(IDbContextFactory<Context> contextFactory, IPermissionVerifier permissionVerifier, IAuditInfoProvider auditInfoProvider, IIdGenerator idGenerator)
    {
        _contextFactory = contextFactory;
        _permissionVerifier = permissionVerifier;
        _auditInfoProvider = auditInfoProvider;
        _idGenerator = idGenerator;
    }

    public async Task<ICQRSResponse> Handle(User_Activate request, CancellationToken cancellationToken)
    {
        if (await _permissionVerifier.Verify(Permissions.User.Activate, cancellationToken) == false)
        {
            return new VerifyPermissionFailed { PermissionId = Permissions.User.Activate };
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

        if (user.StatusId == UserStatuses.Active)
        {
            return new User_StatusAlreadySet
            {
                UserId = user.Id,
                StatusId = UserStatuses.Active
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
            ToId = UserStatuses.Active,
            ChangedById = userId.Value,
            ChangedOn = auditInfo.Timestamp(),
            Remarks = request.Remarks
        };
        user.StatusId = UserStatuses.Active;
        context.Users.Update(user);
        context.UserStatusChangeActivities.Add(statusChangeActivity);
        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return Success.Instance;
    }
}
