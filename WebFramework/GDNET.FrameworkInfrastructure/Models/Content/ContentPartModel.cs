using System.ComponentModel.DataAnnotations;
using GDNET.FrameworkInfrastructure.Common;

namespace GDNET.FrameworkInfrastructure.Models.Content
{
    public class ContentPartModel : AbstractModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string Name
        {
            get;
            set;
        }

        [DataType(DataType.Text)]
        [Display(Name = "Details")]
        public string Details
        {
            get;
            set;
        }
    }
}
