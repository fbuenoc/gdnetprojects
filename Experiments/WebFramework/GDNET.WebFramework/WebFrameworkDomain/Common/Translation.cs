using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class Translation : EntityFullControlBase<long>
    {
        #region Properties

        public virtual string Code
        {
            get;
            set;
        }

        public virtual string Text
        {
            get;
            set;
        }

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

        #endregion

        protected Translation() { }
    }
}
