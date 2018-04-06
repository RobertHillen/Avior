using System.Data.Entity;
using System.Linq;
using SimpleInjector;
using Avior.Base.Helpers;
using Avior.Base.Interfaces;
using Avior.Business.UnitOfWork;
using Avior.Database.Entity;

namespace Avior.Business.SimpleInjector
{
    public static class ContainerExtensions
    {
        public static void RegisterTypes(this Container container)
        {
            var assemblies = ReflectionHelper.GetAviorAssemblies().ToArray();

            // UnitOfWork
            container.Register<IDataUnitOfWork, DataUnitOfWork>(Lifestyle.Scoped);
            container.Register<IRepositoryMapper, EntityFrameWorkRepositoryMapper>(Lifestyle.Scoped);
            container.Register<DbContext, AviorDbEntity>(Lifestyle.Scoped);

            // Query and Command Handling
            container.Register(typeof(IQueryHandler<,>), assemblies, Lifestyle.Scoped);
            container.Register(typeof(ICommandHandler<>), assemblies, Lifestyle.Scoped);
        }
    }
}