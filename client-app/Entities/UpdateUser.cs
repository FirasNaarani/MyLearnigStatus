using System.ComponentModel.DataAnnotations;

namespace LearnSchoolApp.Entities
{
    public class UpdateUser
    {
        [Required(ErrorMessage = "User Type Required")]
        public UserType userType { get; set; }

        [Required(ErrorMessage = "Username Required")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string password { get; set; }
        
        [Required(ErrorMessage = "Name Required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        public string email { get; set; }
       
    }
}
