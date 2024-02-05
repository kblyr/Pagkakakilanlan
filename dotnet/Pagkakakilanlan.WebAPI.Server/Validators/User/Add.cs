namespace Pagkakakilanlan;

sealed class User_AddVAL : Validator<User_AddAPI.Request>
{
    public User_AddVAL()
    {
        RuleFor(_ => _.Username).NotEmpty();
        RuleFor(_ => _.Password).NotEmpty();
        RuleFor(_ => _.FirstName).NotEmpty();
        RuleFor(_ => _.LastName).NotEmpty();
    }
}