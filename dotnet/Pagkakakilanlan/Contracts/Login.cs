namespace Pagkakakilanlan;

public static class Login
{
    public sealed record Request : ICQRSRequest
    {
        public required string Username { get; init; }
        public required string Password { get; init; }
    }

    public sealed record Response : ICQRSResponse
    {
        public required UserObj User { get; init; }
        public required AccessToken AccessToken { get; init; }

        public sealed record UserObj
        {
            public int Id { get; init; }
            public required string Username { get; init; }
            public required string FullName { get; init; }
        }
    }
}