using System.ComponentModel.DataAnnotations;
using GDNET.Domain.Base;

namespace GDNET.FrameworkInfrastructure.Common
{
    public abstract class AbstractModel<T> where T : IEntity
    {
        [Display(Name = "Entity ID")]
        public string Id
        {
            get;
            protected set;
        }

        [Required]
        [Display(Name = "Is active?")]
        public bool IsActive
        {
            get;
            set;
        }

        public abstract void Initialize(T entity);
    }
}
