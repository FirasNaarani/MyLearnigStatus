using LearnSchoolApp.Entities;
using LearnSchoolApp.Models;
using node.Infra;
using System;

namespace LearnSchoolApp.Services
{
    public class AuthenticationService
    {
        private readonly ManagerService _managerService;
        private readonly GuideService _guideService;
        private readonly StudentService _studentService;
        private readonly HeadOfDepramentService _headOfDepramentService;

        private readonly IJWTAuthenticationOptions _jWTAuthenticationOptions; 

        public AuthenticationService(ManagerService managerService, GuideService guideService, StudentService studentService, HeadOfDepramentService headOfDepramentService, IJWTAuthenticationOptions jWTAuthenticationOptions)
        {
            this._managerService = managerService;
            this._guideService = guideService;
            this._studentService = studentService;
            this._headOfDepramentService = headOfDepramentService;

            this._jWTAuthenticationOptions = jWTAuthenticationOptions;
        }

        public UpdateUser Authenticate(UserAuth userLogin)
        {
            switch (userLogin.UserType)
            {
                case UserType.Student:
                    if (!_studentService.isValidCredentials(userLogin.Username, userLogin.Password))
                    {
                        return null;
                    }
                    return _studentService.Get(userLogin.Username);

                case UserType.Guid:
                    if (!_guideService.isValidCredentials(userLogin.Username, userLogin.Password))
                    {
                        return null;
                    }
                    return _guideService.Get(userLogin.Username);

                case UserType.HeadOfDeprament:
                    if (!_headOfDepramentService.isValidCredentials(userLogin.Username, userLogin.Password))
                    {
                        return null;
                    }
                    return _headOfDepramentService.Get(userLogin.Username);

                case UserType.Admin:
                    if (!_managerService.isValidCredentials(userLogin.Username, userLogin.Password))
                    {
                        return null;
                    }
                    return _managerService.Get(userLogin.Username);
                default:
                    throw new Exception("user type not supported");
            }
        }

        public string GenerateToken(UpdateUser user)
        {
            return this._jWTAuthenticationOptions.prepareAuthenticationToken(user);
        }

    }
}
