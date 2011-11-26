using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class ContentItem : EntityFullControlBase<long>
    {
        #region Properties

        public virtual ContentType ContentType
        {
            get;
            set;
        }

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

        public virtual int Position
        {
            get;
            set;
        }

        #endregion

        protected ContentItem() { }
    }
}
