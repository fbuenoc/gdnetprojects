using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class Translation : EntityWithFullInfoBase<long>
    {
        #region Properties

        public virtual ListValue Category
        {
            get;
            set;
        }

        public virtual Culture Culture
        {
            get;
            set;
        }

        public virtual bool IsGeneric
        {
            get;
            set;
        }

        public virtual string Code
        {
            get;
            set;
        }

        public virtual string Value
        {
            get;
            set;
        }

        #endregion

        protected Translation() { }
    }
}
