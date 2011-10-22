using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDNET.WebFramework.Account
{
    public partial class Register : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.CUW.CreatedUser += new EventHandler(OnCreatedUser);
            this.CUW.CreateUserError += new CreateUserErrorEventHandler(OnCreateUserError);
        }

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CUW.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void OnCreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(this.CUW.UserName, false);

            string continueUrl = this.CUW.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            base.Response.Redirect(continueUrl);
        }

        protected void OnCreateUserError(object sender, CreateUserErrorEventArgs e)
        {
        }

        #endregion

    }
}
