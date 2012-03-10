using GDNET.Common.Security.Services;
using WebFramework.Business.Base;

namespace WebFramework.Business.Administration
{
    public sealed partial class Shortcut : BusinessEntityBase, IBusinessEntity
    {
        #region Properties

        public string TargetUrl
        {
            get { return this.GetValue<string>(() => this.TargetUrl); }
            set { this.SetValue<string>(() => this.TargetUrl, value); }
        }

        #endregion

        protected Shortcut()
            : base(EncryptionOption.Base64)
        {
        }

    }
}
