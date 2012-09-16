using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Common.Models
{
    public sealed class LogOnModel
    {
        [Required]
        [Email("GUI.Common.InvalidFormat.Email")]
        [DisplayNameML("GUI.LogOnModel.UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayNameML("GUI.AccountInformation.Password")]
        public string Password { get; set; }

        [DisplayNameML("GUI.LogOnModel.RememberMe")]
        public bool RememberMe { get; set; }
    }
}
