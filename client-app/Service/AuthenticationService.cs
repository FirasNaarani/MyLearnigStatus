using LearnSchoolApp.Entities;
using node.Infra;
using System;

namespace LearnSchoolApp.Services
{
    public class AuthenticationService
    {
        private readonly IJWTAuthenticationManager _jWTAuthenticationManager; 
        private readonly ManagerService _managerService;
        public AuthenticationService(ManagerService managerService, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            this._jWTAuthenticationManager = jWTAuthenticationManager;
            this._managerService = managerService;
        }

        public string Authenticate(string user, string password, UserType userType)
        {
            switch (userType)
            {
                case UserType.Student:
                    return null;
                case UserType.Guid:
                    return null;
                case UserType.HeadOfDeprament:
                    if (!_managerService.isValidCredentials(user, password))
                    {
                        return null;
                    }
                    return this._jWTAuthenticationManager.prepareAuthenticationToken(user);
                case UserType.Admin:
                    return null;
                default:
                    throw new Exception("user type not supported");

            }
        }

    }
}
