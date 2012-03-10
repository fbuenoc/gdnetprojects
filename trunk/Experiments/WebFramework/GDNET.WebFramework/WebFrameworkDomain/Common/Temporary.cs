using System;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;

namespace WebFramework.Domain.Common
{
    public partial class Temporary : EntityBase<Guid>, IEntityWithLifeCycle
    {
        #region Properties

        public virtual ListValue EncryptionType
        {
            get;
            set;
        }

        public virtual string Text
        {
            get;
            set;
        }

        #endregion

        #region IEntityLifeCycle

        public virtual StatutLifeCycle LifeCycle
        {
            get;
            protected internal set;
        }

        public virtual void ApplyDefaultSettings()
        {
            // OKIE, DO NOTHING
        }

        #endregion

        protected Temporary()
        {
            this.LifeCycle = StatutLifeCycle.Factory.Create();
            this.ApplyDefaultSettings();
        }
    }
}
