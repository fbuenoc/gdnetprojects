using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using GDNET.Common.MVP;

using TVNFramework.Extensions;
using TVNFramework.InterWeb.Common;
using TVNFramework.Modules.GenericContent;
using TVNFramework.Modules.GenericContent.BLL;
using TVNFramework.Modules.Transactions.BLL;

using QuyenMua.Presenters.Views;
using QuyenMua.Data.DTOs;
using TVNFramework.Modules.GenericContent.Models;
using TVNFramework.Modules.Transactions;
using System.Globalization;
using TVNFramework.Extensions.DateTimeEx;

namespace QuyenMua.Presenters
{
    public class PresenterListTransaction : PresenterBase<IViewListTransaction>
    {
        private GenericTransactionEntity genericTransactionEntity = null;

        /// <summary>
        /// Instantiate a presenter
        /// </summary>
        /// <param name="view"></param>
        public PresenterListTransaction(IViewListTransaction view)
            : base(view)
        {
            this.CurrentView.AttachPresenter(this);
        }

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

        private void T()
        {
            //StringBuilder conditionBuilder = new StringBuilder();
            //List<ConditionObject> conditionValues = new List<ConditionObject>();
            //conditionValues.Add(new ConditionObject
            //{
            //    AttributeCode = AttributeCodes.FROM_DATE,
            //    Value = DateTime.Today,
            //    Operation = Operations.GreaterOrEqual
            //});
            //conditionValues.Add(new ConditionObject
            //{
            //    AttributeCode = AttributeCodes.TO_DATE,
            //    Value = DateTime.Today.AddMonths(3),
            //    Operation = Operations.LessOrEqual
            //});

            //conditionBuilder.Append("(");
            //conditionBuilder.AppendFormat("(Attribute.AttributeCode = \"{0}\")", AttributeCodes.FROM_DATE.ToString());
            //conditionBuilder.Append(" || ");
            //conditionBuilder.AppendFormat("(Attribute.AttributeCode = \"{0}\")", AttributeCodes.TO_DATE.ToString());
            //conditionBuilder.Append(")");

            //var hoseRelatedItems = ItemEntity.GetList(SpecialCategories.HOSE_ID, 0, 20, true, true, conditionBuilder.ToString(), conditionValues);
            //var hnxRelatedItems = ItemEntity.GetList(SpecialCategories.HNX_ID, 0, 20, true, true, conditionBuilder.ToString(), conditionValues);
            //var upComRelatedItems = ItemEntity.GetList(SpecialCategories.UPCOM_ID, 0, 20, true, true, conditionBuilder.ToString(), conditionValues);

            //var listOfTransactions = new List<TransactionDTO>();
            //foreach (var item in hoseRelatedItems)
            //{
            //    listOfTransactions.Add(new TransactionDTO(item));
            //}
            //base.CurrentView.Transactions = listOfTransactions;
        }
    }
}
