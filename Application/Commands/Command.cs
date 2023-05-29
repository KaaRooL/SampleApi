using Common.Dispatcher.CommandProcessor;

namespace Application.Commands
{
    public class Command : ICommand
    {

    }

    public class CommandWithReturn : ICommand<bool>
    {

    }
}