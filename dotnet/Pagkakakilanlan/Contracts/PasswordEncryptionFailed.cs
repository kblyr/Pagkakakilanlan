namespace Pagkakakilanlan;

public sealed record PasswordEncryptionFailed : ICQRSErrorResponse
{
    public static readonly PasswordEncryptionFailed Instance = new();
}