namespace Pagkakakilanlan;

public sealed record InvalidCurrentUser : ICQRSErrorResponse
{
    public static readonly InvalidCurrentUser Instance = new();
}