namespace Pagkakakilanlan;

public static class User_Add
{
    public sealed record Request : ICQRSRequest, IUserFullNameSource
    {
        public required string Username { get; init; }
        public required string Password { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
    }

    public sealed record Response : ICQRSResponse
    {
        public int Id { get; init; }
        public required string FullName { get; init; }
    }
}