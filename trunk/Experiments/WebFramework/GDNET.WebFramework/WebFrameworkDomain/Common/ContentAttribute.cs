using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class ContentAttribute : EntityFullControlBase<long>
    {
        #region Properties

        public virtual ContentType ContentType
        {
            get;
            set;
        }

        public virtual ListValue DataType
        {
            get;
            set;
        }

        public virtual string Code
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

        protected ContentAttribute() { }
    }
}
