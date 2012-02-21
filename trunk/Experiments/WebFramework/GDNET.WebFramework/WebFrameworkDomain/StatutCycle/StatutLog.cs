using GDNET.Common.Base;
using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.StatutCycle
{
    public partial class StatutLog : EntityWithModificationBase<long>
    {
        #region Properties

        public virtual string Description
        {
            get;
            set;
        }

        public virtual string TechnicalLog
        {
            get;
            set;
        }

        #endregion

        protected StatutLog() { }
    }
}
