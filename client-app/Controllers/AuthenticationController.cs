using LearnSchoolApp.Models;
using LearnSchoolApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using node.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnSchoolApp.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    { 
        private readonly AuthenticationService _authenticationService;
        private readonly ManagerService _managerService;


        public AuthenticationController(AuthenticationService authenticationService, ManagerService managerService)
        {
            _authenticationService = authenticationService;
            _managerService = managerService;
        }

    
        [HttpPost("authenticate")]
        public ActionResult<UserLoginToken> Authenticate([FromBody] UserAuth userAuth)
        {
            Console.WriteLine($"User login with {JsonConvert.SerializeObject(userAuth)}");

            var token = _authenticationService.Authenticate(userAuth.Username, userAuth.Password , userAuth.UserType);

            Console.WriteLine($"Token:  {token}");

            if (token == null)
                return new UnauthorizedResult();
            string key = "Token";
            CookieOptions cookie = new CookieOptions();
            Response.Cookies.Append(key, token);
            var userToken = new UserLoginToken();
            userToken.Token = token;
            return userToken;
        }

        //[ActionName("SignIn")]
        //public Task<IActionResult> SignIn()
        //{
        //    return View()
        //}

        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
