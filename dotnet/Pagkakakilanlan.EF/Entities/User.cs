namespace Pagkakakilanlan;

sealed record User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string HashedPassword { get; set; }
    public required string PasswordSalt { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public bool IsAdministrator { get; set; }
    public bool IsPasswordChangeRequired { get; set; }
    public short StatusId { get; set; }

    public required string FullName { get; set; }
    
    public bool IsDeleted { get; set; }
    public int? InsertedById { get; set; }
    public DateTimeOffset? InsertedOn { get; set; }
    public int? UpdatedById { get; set; }
    public DateTimeOffset? UpdatedOn { get; set; }
    public int? DeletedById { get; set; }
    public DateTimeOffset? DeletedOn { get; set; }

    UserStatus? _status;
    public UserStatus Status
    {
        get => _status ?? throw new UninitializedPropertyException(nameof(Status));
        set => _status = value;
    }

    IEnumerable<UserMobileNumber>? _mobileNumbers;
    public IEnumerable<UserMobileNumber> MobileNumbers
    {
        get => _mobileNumbers ?? throw new UninitializedPropertyException(nameof(MobileNumbers));
        set => _mobileNumbers = value;
    }
}

sealed class UserETC : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(DatabaseObjects.Tables.User, DatabaseObjects.Schema);
        builder.HasOne(_ => _.Status)
            .WithMany()
            .HasForeignKey(_ => _.StatusId);
    }
}