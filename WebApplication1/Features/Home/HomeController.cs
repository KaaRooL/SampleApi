using System.Threading.Tasks;
using Application.Commands;
using Common.Dispatcher;
using Common.Dispatcher.CommandProcessor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Features.Home
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("First")]
    public class HomeController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        private readonly ICommandProcessor _commandProcessor;
        public HomeController(IDispatcher dispatcher, ICommandProcessor commandProcessor)
        {
            _dispatcher = dispatcher;
            _commandProcessor = commandProcessor;
        }

        [HttpGet("Dispatcher")]
        public async Task<IActionResult> Home()
        {
            var command = new Command();
            await _dispatcher.RunAsync(command);
            return new JsonResult("essa");
        }

        [HttpGet("DispatcherSync")]
        [Authorize]
        public IActionResult Home2()
        {
            var command = new Command();
            // var commandWithReturn = new CommandWithReturn();
            
             _dispatcher.Run(command);
            // var a = _dispatcher.Run(commandWithReturn);


            return new AcceptedResult();
        }
    }
}
