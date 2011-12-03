using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class Application : EntityFullControlBase<long>
    {
        #region Properties

        public virtual Translation Name
        {
            get;
            set;
        }

        public virtual Translation Description
        {
            get;
            set;
        }

        public virtual ListValue Category
        {
            get;
            set;
        }

        public virtual string RootUrl
        {
            get;
            set;
        }

        #endregion

        protected Application() { }

    }
}
