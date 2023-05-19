using Common.Dispatcher.CommandProcessor;
using Common.Dispatcher.QueryProcessor;

namespace Common.Dispatcher
{
    public class Dispatcher : IDispatcher
    {
        private readonly ICommandProcessor _commandProcessor;
        private readonly IQueryProcessor _queryProcessor;

        public Dispatcher(ICommandProcessor commandProcessor, IQueryProcessor queryProcessor)
        {
            _commandProcessor = commandProcessor;
            _queryProcessor = queryProcessor;
        }

        public async Task RunAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            await _commandProcessor.SendAsync(command);
        }

        public void Run<T>(T command) where T : class, ICommand
        {
            _commandProcessor.Send(command);
        }
        public Task<TResult> RunAsync<TResult>(ICommand<TResult> command)
        {
            return _commandProcessor.SendAsync(command);
        }
        public TResult Run<TResult>(ICommand<TResult> command)
        {
            return _commandProcessor.Send(command);
        }
        
        public Task<T1> RunAsync<T1>(IQuery<T1> query) 
        {
            return _queryProcessor.QueryAsync(query);
        }

        public TResult Run<TResult>(IQuery<TResult> query)
        {
            return _queryProcessor.Query(query);
        }


        
    }
}