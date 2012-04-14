using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GDNET.jQueryMobileControls;
using GDNET.Common.MVP;
using GDNET.MvpWeb;
using GDNET.Web.Helpers;

using QuyenMua.Data.DTOs;
using QuyenMua.Presenters;
using QuyenMua.Presenters.Views;

namespace QuyenMua.MobileWeb.Views.TransactionDetail
{
    public partial class TransactionDetail : ViewUserControlCrudBase<PresenterTransactionDetail, int>, IViewDetailTransaction
    {
        private DTOTransactionDetail transactionDTO = new DTOTransactionDetail();

        private void ParseInputData()
        {
            var fullNameInput = this.p1.GetContent().FindControlByType<Input>("i1");
            var emailInput = this.p1.GetContent().FindControlByType<Input>("i2");
            var telInput = this.p1.GetContent().FindControlByType<Input>("i3");
            var symbolInput = this.p1.GetContent().FindControlByType<Input>("i4");
            var priceInput = this.p1.GetContent().FindControlByType<Input>("i5");
            var amountInput = this.p1.GetContent().FindControlByType<Input>("i6");
            var contentInput = this.p1.GetContent().FindControlByType<Input>("i10");

            this.transactionDTO.FullName = base.Request.Form[fullNameInput.ClientID];
            this.transactionDTO.Email = base.Request.Form[emailInput.ClientID];
            this.transactionDTO.Tel = base.Request.Form[telInput.ClientID];
            this.transactionDTO.Symbol = base.Request.Form[symbolInput.ClientID];
            this.transactionDTO.Content = base.Request.Form[contentInput.ClientID];

            decimal tempData = 0;
            if (decimal.TryParse(base.Request.Form[priceInput.ClientID], out tempData))
            {
                this.transactionDTO.Price = tempData;
            }
            if (decimal.TryParse(base.Request.Form[amountInput.ClientID], out tempData))
            {
                this.transactionDTO.Amount = tempData;
            }
        }

        #region IViewDetailTransaction Members

        public DTOTransactionDetail Transaction
        {
            get
            {
                this.ParseInputData();
                return this.transactionDTO;
            }
            set
            {
                this.transactionDTO = value;
            }
        }

        #endregion

        public override IViewNotification Notifier
        {
            get { return (IViewNotification)this.p1.GetContent().FindControlById("ntf"); }
        }

        public override void InitializeAdapters()
        {
            throw new NotImplementedException();
        }
    }
}
