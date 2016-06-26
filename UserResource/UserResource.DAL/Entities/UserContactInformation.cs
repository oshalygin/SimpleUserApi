namespace UserResource.DAL.Entities
{
    public class UserContactInformation
    {
        public int Id { get; set; }
        public ContactType ContactType { get; set; }
        public string ContactValue { get; set; }
    }
}