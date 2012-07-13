using System;
using GDNET.Domain.Base.Exceptions;

namespace GDNET.Domain.Base.Management
{
    public partial class EntityLog : AbstractEntityT<Guid>
    {
        private EntityHistory entityHistory;

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

        public virtual EntityHistory EntityHistory
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
