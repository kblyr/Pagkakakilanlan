namespace Pagkakakilanlan;

[SchemaId(SchemaIds.User.UsernameAlreadyExists)]
public sealed record User_UsernameAlreadyExistsAPI : IAPIErrorResponse
{
    public required string Username { get; init; }
}