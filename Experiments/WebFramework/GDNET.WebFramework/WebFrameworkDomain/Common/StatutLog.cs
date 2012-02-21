using System;
using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class StatutLog : EntityBase<Guid>
    {
        #region Properties

        public virtual ListValue Statut
        {
            get;
            private set;
        }

        public virtual string Description
        {
            get;
            private set;
        }

        public virtual string BackupData
        {
            get;
            set;
        }

        public virtual DateTime CreatedAt
        {
            get;
            protected set;
        }

        public virtual string CreatedBy
        {
            get;
            protected set;
        }

        #endregion

        protected StatutLog() { }
    }
}
