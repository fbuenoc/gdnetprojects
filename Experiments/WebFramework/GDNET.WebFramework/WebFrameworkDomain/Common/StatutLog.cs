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
            protected internal set;
        }

        public virtual string Description
        {
            get;
            protected internal set;
        }

        public virtual string BackupData
        {
            get;
            set;
        }

        public virtual DateTime CreatedAt
        {
            get;
            protected internal set;
        }

        public virtual string CreatedBy
        {
            get;
            protected internal set;
        }

        public virtual StatutLifeCycle LifeCycle
        {
            get;
            set;
        }

        #endregion

        protected StatutLog() { }
    }
}
