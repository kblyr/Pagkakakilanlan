namespace Pagkakakilanlan;

public sealed record User_StatusAlreadySet : ICQRSResponse
{
    public int UserId { get; init; }
    public short StatusId { get; init; }
}