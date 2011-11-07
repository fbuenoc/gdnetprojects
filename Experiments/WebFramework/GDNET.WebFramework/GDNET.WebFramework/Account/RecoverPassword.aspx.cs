using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFramework.Account
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.RP.AnswerLookupError += new EventHandler(OnAnswerLookupError);
            this.RP.SendMailError += new SendMailErrorEventHandler(OnSendMailError);
            this.RP.UserLookupError += new EventHandler(OnUserLookupError);
        }

        protected void OnAnswerLookupError(object sender, EventArgs e)
        {

        }

        protected void OnSendMailError(object sender, SendMailErrorEventArgs e)
        {

        }

        protected void OnUserLookupError(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}