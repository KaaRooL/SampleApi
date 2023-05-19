using Application.Dtos;
using Common.Dispatcher.CommandProcessor;
using Core.Repositories;

namespace Application.Commands
{
    public class CommandHandler : ICommandHandler<Command>
    {
        private readonly ISampleRepository _sampleRepository;

        public CommandHandler(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public void Handle(Command command)
        {
            var a = _sampleRepository.DbAlive().GetAwaiter().GetResult();
        }

    }
    
    public class CommandHandlerAsync : ICommandHandlerAsync<Command>
    {
        private readonly ISampleRepository _sampleRepository;

        public CommandHandlerAsync(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public async Task HandleAsync(Command command)
        {
            var a = await _sampleRepository.DbAlive();
        }
    }
    
    public class CommandHandlerWithReturnAsync : ICommandHandlerAsync<CommandWithReturn, bool>
    {
        private readonly ISampleRepository _sampleRepository;

        public CommandHandlerWithReturnAsync(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public async Task<bool> HandleAsync(CommandWithReturn command)
        {
            return await _sampleRepository.DbAlive();
        }
    }
    
    public class CommandHandlerWithReturn : ICommandHandler<CommandWithReturn, bool>
    {
        private readonly ISampleRepository _sampleRepository;

        public CommandHandlerWithReturn(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public bool Handle(CommandWithReturn command)
        {
            return _sampleRepository.DbAlive().GetAwaiter().GetResult();
        }
    }
}