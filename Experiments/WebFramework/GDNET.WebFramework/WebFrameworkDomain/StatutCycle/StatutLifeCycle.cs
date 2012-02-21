using System.Collections.Generic;
using GDNET.Common.Base.Entities;
using WebFrameworkDomain.Common;

namespace WebFrameworkDomain.StatutCycle
{
    public class StatutLifeCycle : EntityBase<long>
    {
        private IList<StatutLog> statutLogs = new List<StatutLog>();

        public IList<StatutLog> StatutLogs
        {
            get { return statutLogs; }
            protected set { statutLogs = value; }
        }

        public virtual ListValue ActualStatut
        {
            get;
            protected set;
        }

    }
}
