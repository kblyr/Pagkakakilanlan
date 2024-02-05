namespace Pagkakakilanlan;

sealed class User_ActivateEP : APIEndpoint<User_ActivateAPI, User_Activate>
{
    public override void Configure()
    {
        Patch("/activate");
        Group<EndpointGroups.Users>();
    }
}