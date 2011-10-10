using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using GDNET.Common.MVP;

using TVNFramework.Modules.Transactions;
using TVNFramework.Modules.Transactions.BLL;

using QuyenMua.Presenters.Views;
using QuyenMua.Data.DTOs;

namespace QuyenMua.Presenters
{
    public class PresenterDetailTransaction : PresenterBase<IViewDetailTransaction>
    {
        private GenericTransactionEntity genericTransactionEntity = null;
        private CultureInfo currentCulture = new CultureInfo("vi-VN");

        public PresenterDetailTransaction(IViewDetailTransaction view)
            : base(view)
        {
            base.CurrentView.AttachPresenter(this);
        }

        /// <summary>
        /// Initalizes view
        /// </summary>
        public override void Initlialize()
        {
            this.genericTransactionEntity = new GenericTransactionEntity();

            decimal friendlyNumber = 0;
            bool hasError = false;

            if (base.HasParameters)
            {
                if (decimal.TryParse(this.Parameters.ToString(), out friendlyNumber))
                {
                    var myTransactionModel = this.genericTransactionEntity.GetModelByFriendlyNumber(friendlyNumber, true);
                    if (myTransactionModel == null)
                    {
                        hasError = true;
                    }
                    else
                    {
                        // Apply format for this transaction
                        myTransactionModel.ApplyFormat(this.currentCulture);

                        DTOTransaction transaction = new DTOTransaction(myTransactionModel);
                        base.CurrentView.Transaction = transaction;
                    }
                }
                else
                {
                    hasError = true;
                }
            }

            // Error handling
            if (hasError)
            {
                base.CurrentView.HandleError(null);
            }
        }
    }
}
