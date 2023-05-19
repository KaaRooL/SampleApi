using Common.Services;

namespace Common.Dispatcher.CommandProcessor
{
    public interface ICommandProcessor : ISingleService
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
        void Send<TCommand>(TCommand command) where TCommand : class, ICommand;
        Task<TResult> SendAsync<TResult>(ICommand<TResult> command);
        TResult Send<TResult>(ICommand<TResult> command);


    }
}

