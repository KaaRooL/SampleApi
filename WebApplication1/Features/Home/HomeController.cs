using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Commands;
using Common.Dispatcher;
using Common.Dispatcher.CommandProcessor;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Features.Home
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("Sample")]
    public class HomeController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        private readonly ICommandProcessor _commandProcessor;
        public HomeController(IDispatcher dispatcher, ICommandProcessor commandProcessor)
        {
            _dispatcher = dispatcher;
            _commandProcessor = commandProcessor;
        }

        [HttpGet("UserInfo")]
        [Authorize]
        public async Task<IActionResult> UserInfo()
        {
            var claims = HttpContext.User.Claims;

            var claimz = claims.ToDictionary(k=>k.Type, v=>v.Value);

            UserInfo userInfo = new UserInfo(claimz["id"], claimz["email"], bool.Parse(
                    claimz["email_verified"]), claimz["username"]);
            
            return new JsonResult(userInfo);
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
public record UserInfo(string Id, string Email, bool EmailVerified, string Username);
