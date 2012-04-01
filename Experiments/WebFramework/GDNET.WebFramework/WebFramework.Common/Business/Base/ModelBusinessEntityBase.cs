using System.ComponentModel.DataAnnotations;
using WebFramework.Common.Framework.Base;
using WebFramework.Business.Base;
using WebFramework.Common.ComponentModel;

namespace WebFramework.Common.Business.Base
{
    public abstract class ModelBusinessEntityBase<TEntity> : AbstractModelWithModification<TEntity, long> where TEntity : BusinessEntityBase
    {
        [Required]
        [DisplayNameML("SysTranslation.Name")]
        public string Name
        {
            get;
            set;
        }

        [DisplayNameML("SysTranslation.Description")]
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
