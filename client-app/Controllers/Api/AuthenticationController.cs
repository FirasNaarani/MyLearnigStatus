using LearnSchoolApp.Entities;
using LearnSchoolApp.Models;
using LearnSchoolApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

            var user = _authenticationService.GetUser(userAuth);

            var token = _authenticationService.GenerateToken(user);

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

        public UpdateUser GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                var checkUserType = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value;

                var x = GetUserType(checkUserType);

                return new UpdateUser
                {
                    username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    userId = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.SerialNumber)?.Value,
                    email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    name = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value,
                    userType = x
                };
            }
            return null;
        }



        private UserType GetUserType(string type)
        {
            switch (type)
            {
                case "0":
                    return UserType.Student;

                case "1":
                    return UserType.Guid;

                case "2":
                    return UserType.HeadOfDeprament;

                case "3":
                    return UserType.Admin;
                default:
                    throw new Exception("user type not supported");
            }
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
