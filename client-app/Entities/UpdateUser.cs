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
        [DataType(DataType.Text)]
        public string name { get; set; }

        [Required(ErrorMessage = "Id Required")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(9, ErrorMessage = "Incorrect ID Number")]
        [MinLength(9, ErrorMessage = "Incorrect ID Number")]
        public string userId { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Phone Required")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(10, ErrorMessage = "Incorrect Phone Number")]
        [MinLength(10, ErrorMessage = "Incorrect Phone Number")]
        public string phone { get; set; }
    }
}
