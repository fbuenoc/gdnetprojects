using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GDNET.jQueryMobileControls;

namespace QuyenMua.MobileWeb.Views.TransactionDetail
{
    public partial class TransactionDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var currentForm = this.p1.GetContent().FindControlByType<Form>("f1");
            var fullNameInput = this.GetControlById("i1");
            var emailInput = this.GetControlById("i2");
            var telInput = this.GetControlById("i3");
            var symbolInput = this.GetControlById("i4");
            var priceInput = this.GetControlById("i5");
            var amountInput = this.GetControlById("i6");
            var contentInput = this.GetControlById("i10");

            var fullName = base.Request[fullNameInput.ClientID];
            var email = base.Request[emailInput.ClientID];
            var tel = base.Request[telInput.ClientID];
            var symbol = base.Request[symbolInput.ClientID];
            var price = base.Request[priceInput.ClientID];
            var amount = base.Request[amountInput.ClientID];
            var content = base.Request[contentInput.ClientID];

            currentForm.Action = Request.RawUrl;
        }

        private Input GetControlById(string id)
        {
            return this.p1.GetContent().FindControlByType<Input>(id);
        }
    }
}
