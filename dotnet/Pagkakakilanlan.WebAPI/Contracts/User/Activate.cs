namespace Pagkakakilanlan;

public sealed record User_ActivateAPI : IAPIRequest
{
    public string Id { get; init; } = "";
    public string Remarks { get; init; } = "";
}