﻿using System.Net;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using Avior.App_Start;

namespace Avior
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            log.Info("Starting Avior Volleybal Manager");

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            ServicePointManager.DefaultConnectionLimit = 50;

            DependencyConfig.RegisterDependencyContainer(container);

            container.Verify();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
