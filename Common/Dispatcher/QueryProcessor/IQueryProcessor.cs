using Common.Services;

namespace Common.Dispatcher.QueryProcessor
{
    public interface IQueryProcessor : ISingleService
    {
        Task<T1> QueryAsync<T1>(IQuery<T1> query);
        TResult Query<TResult>(IQuery<TResult> query);
    }
}