using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using GDNET.Framework.Models;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Models.PageModels
{
    public class AccountChangePasswordModel : AbstractPageModel
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayNameML("GUI.ChangePasswordModel.OldPassword")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [DisplayNameML("GUI.ChangePasswordModel.NewPassword")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayNameML("GUI.ChangePasswordModel.ConfirmNewPassword")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
