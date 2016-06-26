namespace UserResource.AcceptanceTests
{
    public class Mother
    {
        public const string LocalHostUrl = "@http://localhost:9005/api/";
        public static int UserId => 1;
        public static string UserBaseEndpoint => LocalHostUrl + @"user";
        public static string UserBaseEndpointWithPaging => LocalHostUrl + @"user?page=1&pageSize=10";
        public static string UserBaseEndpointWithUserId => LocalHostUrl + $"user?userId={UserId}";
        public static string UserPayLoad =>
            "[{\"id\":\"1\", \"firstName\": \"Oleg\", \"lastName\": \"Shalygin\"}]";
    }
}