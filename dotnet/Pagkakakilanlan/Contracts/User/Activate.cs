namespace Pagkakakilanlan;

public sealed record User_Activate : ICQRSRequest
{
    public int Id { get; init; }
    public required string Remarks { get; init; }
}