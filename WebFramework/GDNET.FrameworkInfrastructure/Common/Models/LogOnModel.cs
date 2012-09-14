using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Common.Models
{
    public class LogOnModel
    {
        [Required]
        [DisplayNameML("GUI.LogOnModel.UserNameName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayNameML("GUI.LogOnModel.PasswordName")]
        public string Password { get; set; }

        [DisplayNameML("GUI.LogOnModel.RememberMeName")]
        public bool RememberMe { get; set; }
    }
}
