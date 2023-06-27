using System;
using System.Collections;
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
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;

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
        private string _test;
        private readonly string _test2;
        private readonly string _SampleApiTestKey;
        private readonly string _testKey;

        public HomeController(IDispatcher dispatcher, IConfiguration config)
        {
            _dispatcher = dispatcher;
            _testKey = config["ConnectionStrings:SampleApiDatabase"];
            _SampleApiTestKey = config["SampleApi:ConnectionStrings:SampleApiDatabase"];
            _test2 = config["ConnectionStrings:SampleApiDatabase"];
            
            IDictionary environmentVariables = Environment.GetEnvironmentVariables();

            foreach (DictionaryEntry variable in environmentVariables)
            {
                string key = variable.Key.ToString();
                string value = variable.Value.ToString();
                _test2 += $"Key: {key}, Value: {value} /n";
            }
        }

        [HttpGet("UserInfo")]
        [Authorize]
        public async Task<IActionResult> UserInfo()
        {
            var claims = HttpContext.User.Claims;

            var claimz = claims.ToDictionary(k => k.Type, v => v.Value);

            UserInfo userInfo = new UserInfo(claimz["id"], claimz["email"], bool.Parse(
                    claimz["email_verified"]), claimz["username"]);

            return new JsonResult(userInfo);
        }

        [HttpGet("GetVaueFromEnv")]
        public IActionResult Home2()
        {
            return new JsonResult(_test2);
        }

        [HttpGet("_SampleApiTestKey")]
        public IActionResult SampleApiTestKey()
        {
            return new JsonResult(_SampleApiTestKey);
        }
        
        [HttpGet("_testKey")]
        public IActionResult TestKey()
        {
            return new JsonResult(_testKey);
        }
    }
}

public record UserInfo(string Id, string Email, bool EmailVerified, string Username);