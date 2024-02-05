namespace Pagkakakilanlan;

public sealed record User_Lock : ICQRSRequest
{
    public int Id { get; init; }
    public required string Remarks { get; init; }
}