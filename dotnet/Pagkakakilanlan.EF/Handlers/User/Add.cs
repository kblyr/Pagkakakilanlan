namespace Pagkakakilanlan;

sealed class User_AddHDL : ICQRSRequestHandler<User_Add.Request>
{
    readonly IPermissionVerifier _permissionVerifier;
    readonly IDbContextFactory<Context> _contextFactory;
    readonly IPasswordHash _passwordHash;
    readonly IMapper _mapper;
    readonly IUserFullNameBuilder _fullNameBuilder;
    readonly IAuditInfoProvider _auditInfoProvider;

    public User_AddHDL(IPermissionVerifier permissionVerifier, IDbContextFactory<Context> contextFactory, IPasswordHash passwordHash, IMapper mapper, IUserFullNameBuilder fullNameBuilder, IAuditInfoProvider auditInfoProvider)
    {
        _permissionVerifier = permissionVerifier;
        _contextFactory = contextFactory;
        _passwordHash = passwordHash;
        _mapper = mapper;
        _fullNameBuilder = fullNameBuilder;
        _auditInfoProvider = auditInfoProvider;
    }

    public async Task<ICQRSResponse> Handle(User_Add.Request request, CancellationToken cancellationToken)
    {
        if (await _permissionVerifier.Verify(Permissions.User.Add, cancellationToken) == false)
        {
            return new VerifyPermissionFailed { PermissionId = Permissions.User.Add };
        }

        using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        if (await context.Users.UsernameExists(request.Username, cancellationToken))
        {
            return new User_UsernameAlreadyExists { Username = request.Username };
        }

        var passwordHashResult = _passwordHash.Compute(request.Password);

        if (passwordHashResult is PasswordHashComputeErrorResult || passwordHashResult is not PasswordHashComputeSuccessResult passwordHashSuccess)
        {
            return PasswordEncryptionFailed.Instance;
        }

        var auditInfo = await _auditInfoProvider.Get(cancellationToken);
        var user = _mapper.Map<User_Add.Request, User>(request) with
        {
            HashedPassword = passwordHashSuccess.HashedPassword,
            PasswordSalt = passwordHashSuccess.Salt,
            FullName = _fullNameBuilder.Build(request),
            IsDeleted = false,
            InsertedById = auditInfo.UserId(),
            InsertedOn = auditInfo.Timestamp()
        };

        return new User_Add.Response
        {
            Id = user.Id,
            FullName = user.FullName
        };
    }
}
