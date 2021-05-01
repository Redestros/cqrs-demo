using Autofac;
using System;
using System.Linq;

namespace cqrs_demo.CQRS
{
    public interface IQueryProcessor
    {
        TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
    public class QueryProcessor : IQueryProcessor
    {
        private readonly IComponentContext context;

        public QueryProcessor(IComponentContext context)
        {
            this.context = context;
        }

        public TResult Process<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            var queryHandlerType = typeof(IQueryHandler<TQuery, TResult>);
            var targetHandlerInterface = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .FirstOrDefault(t => queryHandlerType.IsAssignableFrom(t) && t.IsInterface);

            if (targetHandlerInterface == null)
            {
                return default;
            }

            dynamic targetHandler = context.Resolve(targetHandlerInterface);
            return targetHandler.Handle(query);
        }
    }
}
