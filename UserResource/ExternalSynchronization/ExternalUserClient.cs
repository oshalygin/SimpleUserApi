namespace ExternalSynchronization
{
    public class ExternalUserClient: IExternalUserClient
    {
        public ExternalUser Save(ExternalUser user)
        {
            return user;
        }

        public ExternalUser Delete(ExternalUser user)
        {
            return user;
        }
    }
}