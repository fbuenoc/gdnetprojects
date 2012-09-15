using System.ComponentModel.DataAnnotations;
using GDNET.Domain.Base;
using GDNET.FrameworkInfrastructure.Common.DataAnnotations;

namespace GDNET.FrameworkInfrastructure.Common.Base
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
        [DisplayNameML("GUI.Entity.IsActive")]
        public bool IsActive
        {
            get;
            set;
        }

        public abstract void Initialize(T entity);
    }
}
