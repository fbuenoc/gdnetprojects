using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

using GDNET.Common.MVP;

using TVNFramework.Extensions;
using TVNFramework.Extensions.DateTimeEx;
using TVNFramework.InterWeb.Common;
using TVNFramework.Modules.GenericContent;
using TVNFramework.Modules.GenericContent.Models;
using TVNFramework.Modules.GenericContent.BLL;
using TVNFramework.Modules.Transactions;
using TVNFramework.Modules.Transactions.BLL;

using QuyenMua.Data.DTOs;
using QuyenMua.Presenters.Views;

namespace QuyenMua.Presenters
{
    public class PresenterTransactionList : PresenterBase<IViewListTransaction>
    {
        private GenericTransactionEntity genericTransactionEntity = null;

        /// <summary>
        /// Instantiate a presenter
        /// </summary>
        /// <param name="view"></param>
        /// <param name="mode"></param>
        public PresenterTransactionList(IViewListTransaction view, ViewMode mode) : base(view, mode) { }

        /// <summary>
        /// Initializes presenter
        /// </summary>
        public override void Initlialize()
        {
            this.genericTransactionEntity = new GenericTransactionEntity();

            if (HttpContext.Current.Session[SessionConstants.CATEGORY_ALL] == null)
            {
                var listOfItems = new List<ItemModel>();

                // Stores items into session to reduce loading time
                if (HttpContext.Current.Session[SessionConstants.CATEGORY_HOSE] == null)
                {
                    var items = ItemEntity.GetList(SpecialCategories.HOSE_ID, -1, -1, false, false);
                    listOfItems.AddRange(items);

                    HttpContext.Current.Session[SessionConstants.CATEGORY_HOSE] = items;
                }
                if (HttpContext.Current.Session[SessionConstants.CATEGORY_HNX] == null)
                {
                    var items = ItemEntity.GetList(SpecialCategories.HNX_ID, -1, -1, false, false);
                    listOfItems.AddRange(items);

                    HttpContext.Current.Session[SessionConstants.CATEGORY_HNX] = items;
                }
                if (HttpContext.Current.Session[SessionConstants.CATEGORY_UPCOM] == null)
                {
                    var items = ItemEntity.GetList(SpecialCategories.UPCOM_ID, -1, -1, false, false);
                    listOfItems.AddRange(items);

                    HttpContext.Current.Session[SessionConstants.CATEGORY_UPCOM] = items;
                }

                HttpContext.Current.Session[SessionConstants.CATEGORY_ALL] = listOfItems;
            }

            var allItems = HttpContext.Current.Session[SessionConstants.CATEGORY_ALL] as List<ItemModel>;
            int totalItems = 0;
            var listOfTransactions = this.genericTransactionEntity.GetTopTransactionsByCategoryItems(allItems, TransactionTypes.None, StatusInfo.Active, 0, 20, out totalItems);

            if (listOfTransactions != null)
            {
                CultureInfo culture = new CultureInfo("vi-VN");
                listOfTransactions.ApplyFormat(culture);
                listOfTransactions.ApplyDateStyle(DateTimeHelper.DisplayStyles.DayMonth);
            }

            base.CurrentView.Transactions = listOfTransactions.Select(m => new DTOTransaction(m)).ToList();
        }

        public override bool Perform(bool isPostBack)
        {
            throw new NotImplementedException();
        }
    }
}
