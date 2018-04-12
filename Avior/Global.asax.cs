using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using Avior.App_Start;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;

namespace Avior
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            log.Info("Starting Avior Volleybal Manager");

            GlobalConfiguration.Configure(WebApiConfig.Register);

            var container = new Container();
            // container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            ServicePointManager.DefaultConnectionLimit = 50;

            DependencyConfig.RegisterDependencyContainer(container);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
