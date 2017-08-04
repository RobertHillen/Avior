using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using Avior.Base.Interfaces;
using Avior.Business.Queries;
using Avior.Base.Helpers;
using Avior.Business.SImpleInjector;

namespace Avior.App_Start
{
    public class DependencyConfig
    {
        public static void RegisterDependencyContainer(Container container)
        {
            ConfigureContainer(container);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            SimpleInjectorServiceHostFactory.SetContainer(container);
        }

        public static void ConfigureContainer(Container container)
        {
            container.RegisterUnitOfWorks();
            container.RegisterQueryHandling();
            container.RegisterCommonTypes();
        }
    }
}