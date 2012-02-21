using System;
using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;
using WebFrameworkDomain.Base;

namespace WebFrameworkDomain.Common
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
            private set;
        }

        public void ApplyDefaultSettings()
        {
            ThrowException.NotImplementedException(string.Empty);
        }

        #endregion

        protected Temporary()
        {
            this.LifeCycle = StatutLifeCycle.Factory.Create();
            this.ApplyDefaultSettings();
        }
    }
}
