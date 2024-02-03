namespace Pagkakakilanlan;

sealed class Context : DbContext
{
    public Context(DbContextOptions options) : base(options) {}

    public DbSet<User> Users => Set<User>();
    public DbSet<UserEmailAddress> UserEmailAddresses => Set<UserEmailAddress>();
    public DbSet<UserMobileNumber> UserMobileNumbers => Set<UserMobileNumber>();
    public DbSet<UserStatus> UserStatuses => Set<UserStatus>();
    public DbSet<UserStatusChangeActivity> UserStatusChangeActivities => Set<UserStatusChangeActivity>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .ApplyConfiguration(new UserETC())
            .ApplyConfiguration(new UserEmailAddressETC())
            .ApplyConfiguration(new UserMobileNumberETC())
            .ApplyConfiguration(new UserStatusETC())
            .ApplyConfiguration(new UserStatusChangeActivityETC())
        ;
    }
}