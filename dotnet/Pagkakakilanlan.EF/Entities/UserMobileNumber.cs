namespace Pagkakakilanlan;

sealed record UserMobileNumber
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public required string MobileNumber { get; set; }
    public bool IsPrimary { get; set; }
    public bool IsVerified { get; set; }
    public DateTimeOffset? VerifiedOn { get; set; }

    public bool IsDeleted { get; set; }
    public int? InsertedById { get; set; }
    public DateTimeOffset? InsertedOn { get; set; }
    public int? DeletedById { get; set; }
    public DateTimeOffset? DeletedOn { get; set; }

    User? _user;
    public User User
    {
        get => _user ?? throw new UninitializedPropertyException(nameof(User));
        set => _user = value;
    }
}

sealed class UserMobileNumberETC : IEntityTypeConfiguration<UserMobileNumber>
{
    public void Configure(EntityTypeBuilder<UserMobileNumber> builder)
    {
        builder.ToTable(DatabaseObjects.Tables.UserMobileNumber, DatabaseObjects.Schema);
        builder.HasOne(_ => _.User)
            .WithMany(_ => _.MobileNumbers)
            .HasForeignKey(_ => _.UserId);
    }
}