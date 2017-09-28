using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace CQSDemo.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            BrighterRegistrations.SetupContainer(container);
            MediatrRegistrations.SetupContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();


            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
