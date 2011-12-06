using System;
using System.Web.UI;

using GDNET.Common.MVP;

namespace GDNET.Web.Common
{
    public abstract class PageBase : Page
    {
        protected ViewMode mode = ViewMode.None;

        /// <summary>
        /// Default presenter of page
        /// </summary>
        protected IPresenter presenter;

        /// <summary>
        /// Init the page
        /// </summary>
        public abstract void PageInit();

        /// <summary>
        /// Load the page
        /// </summary>
        public abstract void PageLoad();

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.PageInit();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.PageLoad();
        }

        #endregion

    }
}
