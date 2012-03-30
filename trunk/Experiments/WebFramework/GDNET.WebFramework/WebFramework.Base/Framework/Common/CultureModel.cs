using WebFramework.Common.ComponentModel;
using WebFramework.Common.Framework.Base;
using WebFramework.Domain.Common;

namespace WebFramework.Common.Framework.Common
{
    public sealed class CultureModel : AbstractModelGenericWithActive<Culture, int>
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
