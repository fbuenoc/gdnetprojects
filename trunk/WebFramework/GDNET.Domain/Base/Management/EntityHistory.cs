using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Domain.Base.SessionManagement;

namespace GDNET.Domain.Base.Management
{
    public partial class EntityHistory : AbstractEntityWithModificationT<Guid>
    {
        private IList<EntityLog> logs = new List<EntityLog>();

        public virtual ReadOnlyCollection<EntityLog> Logs
        {
            get { return new ReadOnlyCollection<EntityLog>(this.logs); }
        }

        public virtual void AddLog(string message, string contentText)
        {
            EntityLog logEntry = new EntityLog
            {
                CreatedAt = DateTime.Now,
                CreatedBy = DomainSessionContext.Instance.CurrentUser.Email,
                LogMessage = message,
                LogContentText = contentText,
                EntityHistory = this
            };
            this.logs.Add(logEntry);
        }
    }
}
