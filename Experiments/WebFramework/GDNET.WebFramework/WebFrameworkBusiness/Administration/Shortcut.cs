using GDNET.Common.Security.Services;
using WebFrameworkBusiness.Base;

namespace WebFrameworkBusiness.Administration
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
