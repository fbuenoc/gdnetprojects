﻿using System;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;

namespace WebFramework.Base.Framework.Base
{
    public abstract class ModelWithModificationBase<TEntity, TId> : EntityWithModificationBase<TId>, IViewModel<TId>
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

        public new TId Id
        {
            get;
            set;
        }

        public string ActualStatut
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

        public ModelWithModificationBase()
            : base()
        {
            this.Initialize();
        }

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

                if (lifeCycle.ActualStatut != null)
                {
                    this.ActualStatut = lifeCycle.ActualStatut.Description.Value;
                }
            }
        }

        #endregion
    }
}