namespace Pagkakakilanlan;

sealed class User_AddEP : APIEndpoint<User_AddAPI.Request, User_Add.Request>
{
    public override void Configure()
    {
        Post("/");
        Group<EndpointGroups.Users>();
    }
}