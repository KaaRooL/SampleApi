using Microsoft.Extensions.DependencyInjection;

namespace Common.Dispatcher.QueryProcessor
{
    public class QueryProcessor : IQueryProcessor
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public QueryProcessor(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            var typeArgument = query.GetType();
            var handlerType = typeof(IQueryHandlerAsync<,>).MakeGenericType(typeArgument, typeof(TResult));

            using var scope = _serviceScopeFactory.CreateScope();
            var handler = (dynamic)scope.ServiceProvider.GetRequiredService(handlerType);
            return await handler.HandleAsync((dynamic)query);
        }

        public TResult Query<TResult>(IQuery<TResult> query)
        {
            var typeArgument = query.GetType();
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(typeArgument, typeof(TResult));

            using var scope = _serviceScopeFactory.CreateScope();
            var handler = (dynamic)scope.ServiceProvider.GetRequiredService(handlerType);
            return handler.Handle((dynamic)query);
        }
    }
}

