using System;
using GDNET.Common.Base.Entities;

namespace WebFramework.Base.Framework.Base
{
    public abstract class ModelBase<TEntity, TId> : EntityBase<TId>, IViewModel<TId>
        where TEntity : EntityBase<TId>
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

        #region Ctors

        public ModelBase()
            : base()
        {
            this.Initialize();
        }

        public ModelBase(TEntity entity)
            : base(entity)
        {
            this.Id = entity.Id;
            this.Entity = entity;

            this.Initialize();
        }

        private void Initialize()
        {
            this.ModelId = Guid.NewGuid();
        }

        #endregion
    }
}
