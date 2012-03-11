using System.ComponentModel.DataAnnotations;
using WebFramework.Base.Framework.Base;
using WebFramework.Business.Base;
using WebFramework.Base.ComponentModel;

namespace WebFramework.Base.Business.Base
{
    public abstract class ModelBusinessEntityBase<TEntity> : ModelWithModificationBase<TEntity, long> where TEntity : BusinessEntityBase
    {
        [Required]
        [DisplayNameML("ApplicationCategories.SysTranslation.Name")]
        public string Name
        {
            get;
            set;
        }

        [DisplayNameML("ApplicationCategories.SysTranslation.Description")]
        public string Description
        {
            get;
            set;
        }

        #region Ctors

        public ModelBusinessEntityBase() : base() { }

        public ModelBusinessEntityBase(TEntity entity)
            : base(entity)
        {
            this.Name = entity.Name;
            this.Description = entity.Description;
        }

        #endregion
    }
}
