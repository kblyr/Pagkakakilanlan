namespace Pagkakakilanlan;

sealed class Mapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<PasswordEncryptionFailed, PasswordEncryptionFailedAPI>()
        ;

        config.ForType<User_ActivateAPI, User_Activate>()
            .Map(dest => dest.Id, src => HashIdConverterInstance.Instance.ToInt32(src.Id));

        config.ForType<User_Add.Response, User_AddAPI.Response>()
            .Map(dest => dest.Id, src => HashIdConverterInstance.Instance.FromInt32(src.Id));
    }
}

sealed class ResponseTypeMapRegistration : IResponseTypeMapRegistration
{
    public void Register(IResponseTypeMapRegistry registry)
    {
        registry
            .RegisterBadRequest<PasswordEncryptionFailed, PasswordEncryptionFailedAPI>()
            .RegisterCreated<User_Add.Response, User_AddAPI.Response>()
        ;
    }
}
