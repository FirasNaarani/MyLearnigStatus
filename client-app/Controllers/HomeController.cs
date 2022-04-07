using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LearnSchoolApp.Models;
using LearnSchoolApp.Services;
using LearnSchoolApp.Entities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LearnSchoolApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthenticationService _authenticationService;

        public HomeController(ILogger<HomeController> logger, AuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public IActionResult Validate(string username, string password, UserType userType)
        {
            if (username == "bb" && password == "bb")
            {
                return RedirectToAction("Index");
            }

            return BadRequest();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
