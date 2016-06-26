namespace ExternalSynchronization
{
    public interface IExternalUserClient
    {
        ExternalUser Save(ExternalUser user);
        ExternalUser Delete(ExternalUser user);
    }
}