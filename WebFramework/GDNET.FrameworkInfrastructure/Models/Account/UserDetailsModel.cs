using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Common.Models
{
    public class UserDetailsModel : UpdateDetailsModel
    {
        public UserDetailsModel()
            : base()
        {
        }

        [DataType(DataType.EmailAddress)]
        [Required]
        [Email("GUI.Common.InvalidFormat")]
        [DisplayNameML("GUI.User.Email")]
        public string Email { get; set; }
    }
}
