using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GDNET.Common.Base.Entities;

namespace WebFramework.Domain.Common
{
    public partial class StatutLifeCycle : EntityBase<long>
    {
        private IList<StatutLog> statutLogs = new List<StatutLog>();

        #region Properties

        public virtual ReadOnlyCollection<StatutLog> StatutLogs
        {
            get { return new ReadOnlyCollection<StatutLog>(this.statutLogs); }
        }

        public virtual ListValue ActualStatut
        {
            get;
            protected internal set;
        }

        public virtual DateTime CreatedAt
        {
            get
            {
                return (this.StatutLogs.Count > 0) ? this.StatutLogs.OrderBy(x => x.CreatedAt).First().CreatedAt : default(DateTime);
            }
        }

        public virtual string CreatedBy
        {
            get
            {
                return (this.StatutLogs.Count > 0) ? this.StatutLogs.OrderBy(x => x.CreatedAt).First().CreatedBy : default(string);
            }
        }

        public virtual DateTime LastModifiedAt
        {
            get
            {
                return (this.StatutLogs.Count > 1) ? this.StatutLogs.OrderByDescending(x => x.CreatedAt).First().CreatedAt : default(DateTime);
            }
        }

        public virtual string LastModifiedBy
        {
            get
            {
                return (this.StatutLogs.Count > 1) ? this.StatutLogs.OrderByDescending(x => x.CreatedAt).First().CreatedBy : default(string);
            }
        }

        #endregion

        #region Methods

        public virtual void AddStatutLog(StatutLog log)
        {
            if (!this.statutLogs.Contains(log))
            {
                log.LifeCycle = this;
                this.statutLogs.Add(log);
            }
        }

        public virtual void RemoveStatutLog(StatutLog log)
        {
            if (this.statutLogs.Contains(log))
            {
                this.statutLogs.Remove(log);
            }
        }

        public virtual void RemoveStatutLogs()
        {
            this.statutLogs.Clear();
        }

        #endregion

    }
}
