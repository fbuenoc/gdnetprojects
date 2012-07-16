using System;
using GDNET.Domain.Base.Exceptions;

namespace GDNET.Domain.Base.Management
{
    public class EntityLog : AbstractEntityT<Guid>
    {
        private EntityHistoryComplex entityHistory;

        public virtual DateTime CreatedAt
        {
            get;
            set;
        }

        public virtual string CreatedBy
        {
            get;
            set;
        }

        public virtual string LogMessage
        {
            get;
            set;
        }

        public virtual string LogContentText
        {
            get;
            set;
        }

        public virtual EntityHistoryComplex EntityHistory
        {
            get { return entityHistory; }
            set
            {
                if (entityHistory != null)
                {
                    ExceptionsManager.BusinessException.Throw("Could not modify entity history");
                }
                entityHistory = value;
            }
        }
    }
}
