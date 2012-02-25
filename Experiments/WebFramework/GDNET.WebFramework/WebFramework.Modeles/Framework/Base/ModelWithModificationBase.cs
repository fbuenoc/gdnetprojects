using System;
using GDNET.Common.Base.Entities;
using WebFrameworkDomain.Base;

namespace WebFramework.Modeles.Framework.Base
{
    public abstract class ModelWithModificationBase<TEntity, TId> : EntityWithModificationBase<TId>
        where TEntity : EntityWithModificationBase<TId>
    {
        protected TEntity Entity
        {
            get;
            private set;
        }

        public Guid ModelId
        {
            get;
            private set;
        }

        public DateTime CreatedAt
        {
            get;
            private set;
        }

        public string CreatedBy
        {
            get;
            private set;
        }

        public DateTime LastModifiedAt
        {
            get;
            private set;
        }

        public string LastModifiedBy
        {
            get;
            private set;
        }

        #region Ctors

        public ModelWithModificationBase() : this(null) { }

        public ModelWithModificationBase(TEntity entity)
            : base(entity)
        {
            this.Entity = entity;
            this.Initialize();
        }

        private void Initialize()
        {
            this.ModelId = Guid.NewGuid();

            if (this.Entity is IEntityWithLifeCycle)
            {
                var lifeCycle = ((IEntityWithLifeCycle)this.Entity).LifeCycle;

                this.CreatedAt = lifeCycle.CreatedAt;
                this.CreatedBy = lifeCycle.CreatedBy;
                this.LastModifiedAt = lifeCycle.LastModifiedAt;
                this.LastModifiedBy = lifeCycle.LastModifiedBy;
            }
        }

        #endregion
    }
}
