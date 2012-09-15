using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Common.Models
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayNameML("GUI.RegisterModel.Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [DisplayNameML("GUI.AccountInformation.Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayNameML("GUI.RegisterModel.ConfirmPassword")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
