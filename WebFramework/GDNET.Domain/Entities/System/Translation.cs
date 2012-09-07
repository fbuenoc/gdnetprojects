using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Entities.System
{
    public partial class Translation : EntityHistoryComplex
    {
        #region Properties

        public virtual string Keyword
        {
            get;
            protected set;
        }

        public virtual string Culture
        {
            get;
            protected set;
        }

        public virtual string Value
        {
            get;
            set;
        }

        #endregion

        internal protected Translation() { }
    }
}
