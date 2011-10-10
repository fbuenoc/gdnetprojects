using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GDNET.jQueryMobileControls;
using GDNET.MvpWeb;

using QuyenMua.Data.DTOs;
using QuyenMua.Presenters;
using QuyenMua.Presenters.Views;

namespace QuyenMua.MobileWeb.Views.TransactionList
{
    public partial class TransactionList : ViewUserControlBase<PresenterListTransaction>, IViewListTransaction
    {
        #region IViewListTransaction members

        /// <summary>
        /// All available transactions
        /// </summary>
        public List<DTOTransaction> Transactions
        {
            set
            {
                if (this.transactionRepeater != null)
                {
                    this.transactionRepeater.DataSource = value;
                    this.transactionRepeater.DataBind();
                }
            }
        }

        #endregion

        #region ViewUserControlBase

        public override void HandleError(Exception ex)
        {
            base.HandleError(ex);
            base.Response.Redirect("~/e.aspx");
        }

        #endregion

        #region Fields

        private MobRepeater transactionRepeater = null;

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.transactionRepeater = this.p1.GetContent().FindControlByType<MobRepeater>("rp1");
            if (this.transactionRepeater != null)
            {
                this.transactionRepeater.ItemDataBound += new RepeaterItemEventHandler(transactionRepeater_ItemDataBound);
            }
        }

        void transactionRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            {
                return;
            }

            DTOTransaction transaction = e.Item.DataItem as DTOTransaction;
            Literal litSymbol = e.Item.FindControl("lS") as Literal;
            Literal litType = e.Item.FindControl("lT") as Literal;
            Literal litPrice = e.Item.FindControl("lP") as Literal;
            Literal litAmount = e.Item.FindControl("lA") as Literal;
            Literal litDate = e.Item.FindControl("lD") as Literal;

            litSymbol.Text = transaction.Symbol;
            litType.Text = transaction.Type;
            litPrice.Text = transaction.PriceView;
            litAmount.Text = transaction.AmountView;
            litDate.Text = transaction.UpdatedTime;
        }

        #endregion
    }
}