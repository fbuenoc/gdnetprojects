using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Models.System
{
    public class RegisterModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        [Email("GUI.Common.InvalidFormat")]
        [DisplayNameML("GUI.User.Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DisplayNameML("GUI.User.Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayNameML("GUI.User.ConfirmPassword")]
        [CompareML("Password", "GUI.User.ConfirmPassword.Error")]
        public string ConfirmPassword { get; set; }
    }
}
