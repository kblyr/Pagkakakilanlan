namespace Pagkakakilanlan;

sealed record UserStatus
{
    public short Id { get; set; }
    public required string Name { get; init; }
}