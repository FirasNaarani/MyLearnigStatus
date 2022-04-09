using LearnSchoolApp.Entities;
using LearnSchoolApp.Models;
using node.Infra;
using System;

namespace LearnSchoolApp.Services
{
    public interface IAuthenticationService
    {
        public UpdateUser GetUser(UserAuth userLogin);
        public string GenerateToken(UpdateUser user);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IManagerService _managerService;
        private readonly IGuideService _guideService;
        private readonly IStudentService _studentService;
        private readonly IHeadOfDepramentService _headOfDepramentService;

        private readonly IJWTAuthenticationOptions _jWTAuthenticationOptions; 

        public AuthenticationService(ManagerService managerService, GuideService guideService, StudentService studentService, HeadOfDepramentService headOfDepramentService, IJWTAuthenticationOptions jWTAuthenticationOptions)
        {
            this._managerService = managerService;
            this._guideService = guideService;
            this._studentService = studentService;
            this._headOfDepramentService = headOfDepramentService;

            this._jWTAuthenticationOptions = jWTAuthenticationOptions;
        }

        public UpdateUser GetUser(UserAuth userLogin)
        {
            switch (userLogin.UserType)
            {
                case UserType.Student:
                    if (!_studentService.isValidCredentials(userLogin.Username, userLogin.Password))
                    {
                        return null;
                    }
                    return _studentService.Authenticate(userLogin.Username);

                case UserType.Guid:
                    if (!_guideService.isValidCredentials(userLogin.Username, userLogin.Password))
                    {
                        return null;
                    }
                    return _guideService.Authenticate(userLogin.Username);

                case UserType.HeadOfDeprament:
                    if (!_headOfDepramentService.isValidCredentials(userLogin.Username, userLogin.Password))
                    {
                        return null;
                    }
                    return _headOfDepramentService.Authenticate(userLogin.Username);

                case UserType.Admin:
                    if (!_managerService.isValidCredentials(userLogin.Username, userLogin.Password))
                    {
                        return null;
                    }
                    return _managerService.Authenticate(userLogin.Username);
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
