using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Models.System
{
    public sealed class LogOnModel
    {
        [Required]
        [Email("GUI.Common.InvalidFormat.Email")]
        [DisplayNameML("GUI.User.UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayNameML("GUI.User.Password")]
        public string Password { get; set; }

        [DisplayNameML("GUI.LogOnModel.RememberMe")]
        public bool RememberMe { get; set; }
    }
}
