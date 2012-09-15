using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Common.Models
{
    public class RegisterModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        [Email(ErrorKeyword = "GUI.Common.InvalidFormat")]
        [DisplayNameML("GUI.RegisterModel.Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6)]
        [DisplayNameML("GUI.AccountInformation.Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayNameML("GUI.RegisterModel.ConfirmPassword")]
        [CompareML("Password", "GUI.Account.ConfirmPassword.Error")]
        public string ConfirmPassword { get; set; }
    }
}
