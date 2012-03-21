using System;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;

namespace WebFramework.Base.Framework.Base
{
    public abstract class AbstractModelWithModification : AbstractModel
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
    }

    public abstract class AbstractModelWithModification<TEntity, TId> : AbstractModelWithModification, IViewModel<TId>
        where TEntity : EntityWithModificationBase<TId>
    {
        protected TEntity Entity
        {
            get;
            private set;
        }

        public TId Id
        {
            get
            {
                if (base.id != null)
                {
                    return (TId)base.id;
                }
                return default(TId);
            }
            set { base.id = value; }
        }

        #region Ctors

        public AbstractModelWithModification()
            : base()
        {
            this.Initialize();
        }

        public AbstractModelWithModification(TEntity entity)
            : base()
        {
            base.id = entity.Id;
            this.Entity = entity;
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
