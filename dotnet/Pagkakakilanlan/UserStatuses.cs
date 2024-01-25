namespace Pagkakakilanlan;

public sealed record UserStatusesOptions
{
    public const string CONFIGKEY = "Pagkakakilanlan:UserStatuses";

    public short Pending { get; set; } = 1;
    public short Active { get; set; } = 2;
    public short Locked { get; set; } = 3;
}