using LearnSchoolApp.Entities;
using node.Infra;
using System;

namespace LearnSchoolApp.Services
{
    public class AuthenticationService
    {
        private readonly IJWTAuthenticationManager _jWTAuthenticationManager; 
        private readonly ManagerService _managerService;

        private readonly IJWTAuthenticationHeadOfDeprament _jWTAuthenticationHeadOfDeprament;
        private readonly HeadOfDepramentService _headOfDepramentService;

        private readonly IJWTAuthenticationGuide _jWTAuthenticationGuide;
        private readonly GuideService _guideService;
        
        private readonly IJWTAuthenticationStudent _jWTAuthenticationStudent;
        private readonly StudentService _studentService;

        public AuthenticationService(ManagerService managerService, IJWTAuthenticationManager jWTAuthenticationManager, GuideService guideService, IJWTAuthenticationGuide jWTAuthenticationGuide, StudentService studentService, IJWTAuthenticationStudent jWTAuthenticationStudent, HeadOfDepramentService headOfDepramentService, IJWTAuthenticationHeadOfDeprament jWTAuthenticationHeadOfDeprament)
        {
            this._jWTAuthenticationManager = jWTAuthenticationManager;
            this._managerService = managerService;

            this._jWTAuthenticationGuide = jWTAuthenticationGuide;
            this._guideService = guideService;

            this._jWTAuthenticationStudent = jWTAuthenticationStudent;
            this._studentService = studentService;

            this._jWTAuthenticationHeadOfDeprament = jWTAuthenticationHeadOfDeprament;
            this._headOfDepramentService = headOfDepramentService;

        }

        public string Authenticate(string user, string password,UserType userType)
        {
            switch (userType)
            {
                case UserType.Student:
                    if (!_studentService.isValidCredentials(user, password))
                    {
                        return null;
                    }
                    return this._jWTAuthenticationStudent.prepareAuthenticationToken(user, userType.ToString());

                case UserType.Guid:
                    if (!_guideService.isValidCredentials(user, password))
                    {
                        return null;
                    }
                    return this._jWTAuthenticationGuide.prepareAuthenticationToken(user, userType.ToString());

                case UserType.HeadOfDeprament:
                    if (!_headOfDepramentService.isValidCredentials(user, password))
                    {
                        return null;
                    }
                    return this._jWTAuthenticationHeadOfDeprament.prepareAuthenticationToken(user, userType.ToString());

                case UserType.Admin:
                    if (!_managerService.isValidCredentials(user, password))
                    {
                        return null;
                    }
                    return this._jWTAuthenticationManager.prepareAuthenticationToken(user,userType.ToString());
                default:
                    throw new Exception("user type not supported");

            }
        }
    }
}
