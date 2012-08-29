using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Common;

namespace GDNET.FrameworkInfrastructure.Models.Content
{
    public class ContentPartModel : AbstractModel
    {
        [Required]
        [Display(Name = "Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Details")]
        public string Details
        {
            get;
            set;
        }
    }
}
