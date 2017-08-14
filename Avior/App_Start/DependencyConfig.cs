using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using SimpleInjector.Integration.Web.Mvc;
using Avior.Business.SimpleInjector;

namespace Avior.App_Start
{
    public class DependencyConfig
    {
        public static void RegisterDependencyContainer(Container container)
        {
            container.RegisterTypes();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            SimpleInjectorServiceHostFactory.SetContainer(container);
        }
    }
}