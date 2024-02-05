namespace Pagkakakilanlan;

sealed class User_ActivateVAL : Validator<User_ActivateAPI>
{
    public User_ActivateVAL()
    {
        RuleFor(_ => _.Id).NotEmpty();
        RuleFor(_ => _.Remarks).NotEmpty();
    }
}