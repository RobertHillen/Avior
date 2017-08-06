using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Avior.Base.Helpers;
using Avior.Base.Interfaces;
using Avior.Business.Queries;
using Avior.Business.UnitOfWork;
using Avior.Database.Data;
using Avior.Business.Commands.Coach;
using Avior.Business.Commands;

namespace Avior.Business.SImpleInjector
{
    public static class ContainerExtensions
    {
        public static void RegisterTypes(this Container container)
        {
            var assemblies = ReflectionHelper.GetAviorAssemblies().ToArray();

            // UnitOfWork
            container.Register<IDataUnitOfWork, DataUnitOfWork>(Lifestyle.Scoped);
            container.Register<IRepositoryMapper, EntityFrameWorkRepositoryMapper>(Lifestyle.Scoped);
            container.Register<DbContext, AviorDbContext>(Lifestyle.Scoped);

            // QueryHandling
            container.Register<IQueryProcessor, QueryProcessor>(Lifestyle.Scoped);
            container.Register(typeof(IQueryHandler<,>), assemblies, Lifestyle.Scoped);

            // QueryCommandHandling
            container.Register(typeof(ICommandHandler<>), assemblies, Lifestyle.Scoped);
        }
    }
}