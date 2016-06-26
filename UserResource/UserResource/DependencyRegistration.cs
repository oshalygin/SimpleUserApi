using System.Web.Http;
using AutoMapper;
using ExternalSynchronization;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using UserResource.BLL;
using UserResource.DAL;

namespace UserResource
{
    public static class DependencyRegistration
    {
        public static void Registration()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);


            container.Register<IMapper, Mapper>();
            container.Register<IUserBLL, UserBLL>();
            container.Register<IUserDAL, IUserDAL>(Lifestyle.Scoped);
            container.Register<IExternalUserClient, ExternalUserClient>(Lifestyle.Scoped);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

        }
    }
}