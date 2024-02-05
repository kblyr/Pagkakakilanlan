namespace Pagkakakilanlan;

public static class User_AddAPI
{
    public sealed record Request : IAPIRequest
    {
        public string Username { get; init; } = "";
        public string Password { get; init; } = "";
        public string FirstName { get; init; } = "";
        public string LastName { get; init; } = "";
    }

    [SchemaId(SchemaIds.User.Add)]
    public sealed record Response : IAPIResponse
    {
        public required string Id { get; init; }
        public required string FullName { get; init; }
    }
}