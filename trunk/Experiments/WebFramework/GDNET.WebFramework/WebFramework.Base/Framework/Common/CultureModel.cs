using WebFramework.Base.ComponentModel;
using WebFramework.Base.Framework.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Base.Framework.Common
{
    public sealed class CultureModel : AbstractModelGeneric<Culture, int>
    {
        #region Properties

        [RequiredML]
        [DisplayNameML("")]
        public string CultureCode
        {
            get;
            set;
        }

        public bool IsDefault
        {
            get;
            set;
        }

        #endregion

        #region Ctors

        public CultureModel()
            : base()
        { }

        public CultureModel(Culture culture)
            : base(culture)
        {
            this.CultureCode = culture.CultureCode;
            this.IsDefault = culture.IsDefault;
        }

        #endregion
    }
}
