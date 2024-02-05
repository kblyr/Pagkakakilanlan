namespace Pagkakakilanlan;

public sealed record User_UsernameAlreadyExists : ICQRSErrorResponse
{
    public required string Username { get; init; }
}