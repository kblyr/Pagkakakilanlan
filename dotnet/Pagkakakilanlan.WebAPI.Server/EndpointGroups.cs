namespace Pagkakakilanlan;

static class EndpointGroups
{
    public sealed class Users : Group
    {
        public Users()
        {
            Configure("/users", ep => {});
        }
    }
}