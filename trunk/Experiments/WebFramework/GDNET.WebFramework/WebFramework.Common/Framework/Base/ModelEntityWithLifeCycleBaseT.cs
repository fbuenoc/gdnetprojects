using System;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;

namespace WebFramework.Common.Framework.Base
{
    public abstract class ModelEntityWithLifeCycleBase<TEntity, TId> : ModelEntityWithActiveBase<TEntity, TId>, IModel<TId>, IModelWithLifeCycle
        where TEntity : EntityWithActive<TId>
    {
        #region IModelWithModification members

        public string ActualStatut
        {
            get;
            protected set;
        }

        public DateTime CreatedAt
        {
            get;
            protected set;
        }

        public string CreatedBy
        {
            get;
            protected set;
        }

        public DateTime LastModifiedAt
        {
            get;
            protected set;
        }

        public string LastModifiedBy
        {
            get;
            protected set;
        }

        #endregion

        #region Ctors

        public ModelEntityWithLifeCycleBase()
            : base()
        {
            this.Initialize();
        }

        public ModelEntityWithLifeCycleBase(TEntity entity)
            : base(entity)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            if (this.Entity == null)
            {
                return;
            }

            var lifeCycleEntity = ((IEntityWithLifeCycle)this.Entity).LifeCycle;

            this.CreatedAt = lifeCycleEntity.CreatedAt;
            this.CreatedBy = lifeCycleEntity.CreatedBy;
            this.LastModifiedAt = lifeCycleEntity.LastModifiedAt;
            this.LastModifiedBy = lifeCycleEntity.LastModifiedBy;

            if (lifeCycleEntity.ActualStatut != null)
            {
                this.ActualStatut = lifeCycleEntity.ActualStatut.Description.Value;
            }
        }

        #endregion
    }
}
