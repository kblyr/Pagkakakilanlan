namespace Pagkakakilanlan;

public sealed record User_NotFound : ICQRSResponse
{
    public int Id { get; init; }
}