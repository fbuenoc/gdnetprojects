using System.ComponentModel.DataAnnotations;
using GDNET.Domain.Base;

namespace GDNET.FrameworkInfrastructure.Common
{
    public abstract class AbstractModel<T> where T : IEntity
    {
        [Required]
        [Display(Name = "Is active?")]
        public bool IsActive { get; set; }

        public abstract void Initialize(T entity);
    }
}
