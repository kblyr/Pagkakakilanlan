namespace Pagkakakilanlan;

sealed record UserEmailAddress
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public required string EmailAddress { get; set; }
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

sealed class UserEmailAddressETC : IEntityTypeConfiguration<UserEmailAddress>
{
    public void Configure(EntityTypeBuilder<UserEmailAddress> builder)
    {
        builder.ToTable(DatabaseObjects.Tables.UserEmailAddress, DatabaseObjects.Schema);
        builder.HasOne(_ => _.User)
            .WithMany(_ => _.EmailAddresses)
            .HasForeignKey(_ => _.UserId);
    }
}