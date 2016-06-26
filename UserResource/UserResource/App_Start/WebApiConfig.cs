using System.Web.Http;

namespace UserResource
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            DependencyRegistration.Registration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
