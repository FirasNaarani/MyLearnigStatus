using System.ComponentModel.DataAnnotations;

namespace LearnSchoolApp.Entities
{
    public class UpdateUser
    {
        public UserType userType { get; set; }

        [Required(ErrorMessage = "Username Required")]
        public string username { get; set; }

        public string password { get; set; }
        
        [Required(ErrorMessage = "Name Required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        public string email { get; set; }

        [Required(ErrorMessage = "Phone Required")]
        [MaxLength(10, ErrorMessage = "Incorrect Phone Number")]
        public string phone { get; set; }
    }
}
