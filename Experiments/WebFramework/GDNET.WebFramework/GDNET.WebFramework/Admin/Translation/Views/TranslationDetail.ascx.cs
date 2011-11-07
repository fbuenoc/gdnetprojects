using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GDNET.Common.Adapters;
using GDNET.Common.MVP;
using GDNET.MvpWeb;
using GDNET.Web.Adapters;

using WebFrameworkPresenters.Admin.Translation;
using WebFrameworkPresenters.Admin.Translation.Views;

namespace WebFramework.Admin.Translation.Views
{
    public partial class TranslationDetail : ViewUserControlCrudBase<PresenterTranslationDetail, long>, IViewTranslationDetail
    {
        #region Fields

        private AdapterLiteral blocTitle;
        private AdapterLiteral codeLabel;
        private AdapterTextBox codeInput;
        private AdapterLiteral textLabel;
        private AdapterTextBox textInput;

        #endregion

        public override void InitializeAdapters()
        {
            base.actionReset = new AdapterButton(this.R);
            base.actionSubmit = new AdapterButton(this.S);
            base.actionDelete = new AdapterButton(this.D);
            base.actionEdit = new AdapterButton(this.E);
            base.actionReturn = new AdapterLinkButton(this.RT);

            this.blocTitle = new AdapterLiteral(this.LitBlocTitle);
            this.codeLabel = new AdapterLiteral(this.LitCode);
            this.codeInput = new AdapterTextBox(this.IC);
            this.textLabel = new AdapterLiteral(this.LitText);
            this.textInput = new AdapterTextBox(this.IT);
        }

        #region IViewTranslationDetail Members

        public override IViewNotification Notifier
        {
            get { return this.NF; }
        }

        public IAdapterLiteral BlocTitle
        {
            get { return this.blocTitle; }
        }
        public IAdapterLiteral CodeLabel
        {
            get { return this.codeLabel; }
        }
        public IAdapterTextBox CodeInput
        {
            get { return this.codeInput; }
        }
        public IAdapterLiteral TextLabel
        {
            get { return this.textLabel; }
        }
        public IAdapterTextBox TextInput
        {
            get { return this.textInput; }
        }

        #endregion

    }
}