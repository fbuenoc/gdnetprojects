using System.ComponentModel.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Common.Models
{
    public class UpdateDetailsModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Display name")]
        public string DisplayName { get; set; }

        [Required]
        [Display(Name = "Is active your account?")]
        public bool IsActive { get; set; }
    }
}
