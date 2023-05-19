// See https://aka.ms/new-console-template for more information

using Common.Dispatcher.CommandProcessor;

namespace ConsoleAppToTest
{
    class Program
    {
        private CommandProcessor _commandProcessor;
        public Program(CommandProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }
        static void Main(string[] args)
        {
            //var command = new Command();
            //var commandWithReturn = new CommandWithReturn();

            //Console.WriteLine("Hello World!");
            ////await _commandProcessor.SendAsync(command);
            ////var result = await _commandProcessor.SendAsync<BasicDto, CommandWithReturn>(commandWithReturn);
            ////var result2 = await _commandProcessor.SendAsync<BasicDto>(commandWithReturn);
            //_commandProcessor.Send(command);
            //var result3 = _commandProcessor.Send<BasicDto>(commandWithReturn);
        }
    }
}
