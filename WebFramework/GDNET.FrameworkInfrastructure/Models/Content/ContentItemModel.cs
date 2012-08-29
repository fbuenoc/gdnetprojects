using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Common;

namespace GDNET.FrameworkInfrastructure.Models.Content
{
    public class ContentItemModel : AbstractModel
    {
        [Required]
        [Display(Name = "Name")]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name
        {
            get;
            set;
        }

        [Display(Name = "Description")]
        public string Description
        {
            get;
            set;
        }

        [Display(Name = "Keywords")]
        public string Keywords
        {
            get;
            set;
        }
    }
}
