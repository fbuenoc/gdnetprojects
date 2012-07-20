﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Domain.Base.SessionManagement;

namespace GDNET.Domain.Base.Management
{
    public class EntityHistoryComplex : AbstractEntityWithModificationHistoryT<Guid>
    {
        protected IList<EntityLog> logs = new List<EntityLog>();

        public virtual ReadOnlyCollection<EntityLog> Logs
        {
            get { return new ReadOnlyCollection<EntityLog>(this.logs); }
        }

        public virtual bool IsActive
        {
            get;
            set;
        }

        #region Methods

        public override void AddLog(string message, string contentText)
        {
            EntityLog logEntry = new EntityLog
            {
                CreatedAt = DateTime.Now,
                CreatedBy = DomainSessionContext.Instance.CurrentUser.Email,
                LogMessage = message,
                LogContentText = contentText,
                EntityHistory = this
            };

            if (this.FirstLog == null)
            {
                this.FirstLog = logEntry;
            }
            else
            {
                this.LastLog = logEntry;
            }

            this.logs.Add(logEntry);
        }

        #endregion
    }
}
