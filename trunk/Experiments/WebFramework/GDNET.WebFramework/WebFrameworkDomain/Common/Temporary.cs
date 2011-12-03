using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class Temporary : EntityCreModBase<string>
    {
        #region Properties

        public virtual ListValue EncryptionType
        {
            get;
            set;
        }

        public virtual string Text
        {
            get;
            set;
        }

        #endregion

        protected Temporary() { }
    }
}
