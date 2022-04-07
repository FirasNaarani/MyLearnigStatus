using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnSchoolApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearnSchoolApp.Views.Account
{
    public class LoginModel : PageModel
    {
        public UserAuth Credential { get; set; }

        public void OnGet()
        {
        }
    }
}
