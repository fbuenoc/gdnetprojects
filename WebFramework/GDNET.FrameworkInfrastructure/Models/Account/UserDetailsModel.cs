using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Common.Models
{
    public enum UserDetailsMode
    {
        Basic,
        Medium,
    }

    public class UserDetailsModel : UpdateDetailsModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        [Email("GUI.Common.InvalidFormat")]
        [DisplayNameML("GUI.User.Email")]
        public string Email { get; set; }

        public UserDetailsMode DisplayMode
        {
            get;
            set;
        }

        public UserDetailsModel()
            : base()
        {
            this.DisplayMode = UserDetailsMode.Basic;
        }
    }
}
