using GDNET.Common.Base.Entities;

namespace WebFramework.Common.Framework.Base
{
    public abstract class ModelEntityBase<TEntity, TId> : ModelEntityBase, IModel<TId>
        where TEntity : EntityBase<TId>
    {
        #region Properties

        protected TEntity Entity
        {
            get;
            private set;
        }

        public TId Id
        {
            get
            {
                if (base.EntityId != null)
                {
                    return (TId)base.EntityId;
                }
                return default(TId);
            }
            set { base.EntityId = value; }
        }

        public bool IsNew
        {
            get { return (this.Id == null || this.Id.Equals(default(TId))) ? true : false; }
        }

        public string EntityInfo
        {
            get { return string.Format("{0}|{1}", typeof(TEntity).FullName, this.Id); }
        }

        #endregion

        #region Ctors

        public ModelEntityBase()
            : base()
        {
        }

        public ModelEntityBase(TEntity entity)
            : base()
        {
            this.Id = entity.Id;
            this.Entity = entity;
        }

        #endregion
    }
}
