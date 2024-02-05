namespace Pagkakakilanlan;

static class DatabaseObjects
{
    public static string Schema { get; set; } = "dbo";

    public static class Tables
    {
        public static string User { get; set; }                     = "User";
        public static string UserEmailAddress { get; set; }         = "UserEmailAddress";
        public static string UserMobileNumber { get; set; }         = "UserMobileNumber";
        public static string UserStatus { get; set; }               = "UserStatus";
        public static string UserStatusChangeActivity { get; set; } = "UserStatusChangeActivity";
    }
}