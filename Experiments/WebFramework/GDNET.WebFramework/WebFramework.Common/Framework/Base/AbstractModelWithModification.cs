using System;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;

namespace WebFramework.Common.Framework.Base
{
    public abstract class AbstractModelWithModification<TEntity, TId> : AbstractModelGenericWithActive<TEntity, TId>, IViewModel<TId>
        where TEntity : EntityWithModification<TId>
    {
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

        #region Ctors

        public AbstractModelWithModification()
            : base()
        {
            this.Initialize();
        }

        public AbstractModelWithModification(TEntity entity)
            : base(entity)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            if (this.Entity is IEntityWithLifeCycle)
            {
                var lifeCycle = ((IEntityWithLifeCycle)this.Entity).LifeCycle;

                this.CreatedAt = lifeCycle.CreatedAt;
                this.CreatedBy = lifeCycle.CreatedBy;
                this.LastModifiedAt = lifeCycle.LastModifiedAt;
                this.LastModifiedBy = lifeCycle.LastModifiedBy;

                if (lifeCycle.ActualStatut != null)
                {
                    this.ActualStatut = lifeCycle.ActualStatut.Description.Value;
                }
            }
        }

        #endregion
    }
}
