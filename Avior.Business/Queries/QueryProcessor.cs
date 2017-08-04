using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Avior.Base.Interfaces;

namespace Avior.Business.Queries
{
    public sealed class QueryProcessor : IQueryProcessor
    {
        private readonly Container container;

        public QueryProcessor(Container container)
        {
            this.container = container;
        }

        public bool CanExecute<TResult>(IQuery<TResult> query)
        {
            var handlerType = GetHandlerType(query);

            return this.container.GetCurrentRegistrations().Any(ip => ip.ServiceType == handlerType);
        }

        public TResult Execute<TResult>(IQuery<TResult> query)
        {
            var handlerType = GetHandlerType(query);

            dynamic handler = container.GetInstance(handlerType);

            dynamic result = handler.Handle((dynamic)query);

            return result;
        }

        private Type GetHandlerType<TResult>(IQuery<TResult> query)
        {
            return typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        }
    }
}