namespace Pagkakakilanlan;

sealed record UserStatus
{
    public short Id { get; set; }
    public required string Name { get; init; }
}

sealed class UserStatusETC : IEntityTypeConfiguration<UserStatus>
{
    public void Configure(EntityTypeBuilder<UserStatus> builder)
    {
        builder.ToTable(DatabaseObjects.Tables.UserStatus, DatabaseObjects.Schema);
    }
}