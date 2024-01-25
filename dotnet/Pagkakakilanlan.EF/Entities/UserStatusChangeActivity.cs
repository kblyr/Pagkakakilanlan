namespace Pagkakakilanlan;

sealed record UserStatusChangeActivity
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public short FromId { get; set; }
    public short ToId { get; set; }
    public int ChangedById { get; set; }
    public DateTimeOffset ChangedOn { get; set; }
    public required string Remarks { get; set; }

    User? _user;
    public User User
    {
        get => _user ?? throw new UninitializedPropertyException(nameof(User));
        set => _user = value;
    }

    UserStatus? _from;
    public UserStatus From
    {
        get => _from ?? throw new UninitializedPropertyException(nameof(From));
        set => _from = value;
    }

    UserStatus? _to;
    public UserStatus To
    {
        get  => _to ?? throw new UninitializedPropertyException(nameof(To));
        set => _to = value;
    }

    User? _changedBy;
    public User ChangedBy
    {
        get => _changedBy ?? throw new UninitializedPropertyException(nameof(ChangedBy));
        set => _changedBy = value;
    }
}

sealed class UserStatusChangeActivityETC : IEntityTypeConfiguration<UserStatusChangeActivity>
{
    public void Configure(EntityTypeBuilder<UserStatusChangeActivity> builder)
    {
        builder.ToTable(DatabaseObjects.Tables.UserStatusChangeActivity, DatabaseObjects.Schema);
        builder.HasOne(_ => _.User)
            .WithMany(_ => _.StatusChangeActivities)
            .HasForeignKey(_ => _.UserId);
        builder.HasOne(_ => _.From)
            .WithMany()
            .HasForeignKey(_ => _.FromId);
        builder.HasOne(_ => _.To)
            .WithMany()
            .HasForeignKey(_ => _.ToId);
        builder.HasOne(_ => _.ChangedBy)
            .WithMany()
            .HasForeignKey(_ => _.ChangedById);
    }
}