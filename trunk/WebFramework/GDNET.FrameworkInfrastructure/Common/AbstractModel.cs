using System.ComponentModel.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Common
{
    public abstract class AbstractModel
    {
        [Required]
        [Display(Name = "Is active?")]
        public bool IsActive { get; set; }
    }
}
