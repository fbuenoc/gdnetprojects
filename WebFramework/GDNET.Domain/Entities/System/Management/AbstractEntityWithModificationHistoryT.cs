﻿using System;
using GDNET.Base.DomainAbstraction;

namespace GDNET.Domain.Entities.System.Management
{
    public abstract class AbstractEntityWithModificationHistoryT<TId> : AbstractEntityWithModificationT<TId>, IEntityWithModificationHistoryT<TId>
    {
        public virtual EntityLog FirstLog
        {
            get;
            protected internal set;
        }

        public virtual EntityLog LastLog
        {
            get;
            protected internal set;
        }

        public virtual bool IsActive
        {
            get;
            set;
        }

        public virtual Int64 Views
        {
            get;
            set;
        }

        public virtual void AddLogCreation()
        {
            this.AddLog("Creation", string.Empty);
        }

        public abstract void AddLog(string message, string contentText);
    }
}