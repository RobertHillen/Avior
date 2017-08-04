using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using Avior.Database.Data;
using Avior.Helpers;
using Avior.App_Start;

namespace Avior
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            log.Info("[ Starting Avior application ]");

            log.Info("[ Initializing SimpleInjector ]");

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            ServicePointManager.DefaultConnectionLimit = 50;

            container.Register<QueryExecutor>();
            DependencyConfig.RegisterDependencyContainer(container);

            container.Verify();

            log.Info("[ Initializing SQL Server LocalDB ]");
            InitializeDatabase();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void InitializeDatabase()
        {
            System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<AviorDbContext>());
            using (var db = new AviorDbContext())
            {
                db.Database.Initialize(false);
            }
        }
    }
}
