namespace Pagkakakilanlan;

public static class Permissions
{
    public static class User
    {
        public static int Add { get; set; }         = 0001_0001_0001;
        public static int Activate { get; set; }    = 0001_0001_0002;
        public static int Lock { get; set; }        = 0001_0001_0003;
    }
}