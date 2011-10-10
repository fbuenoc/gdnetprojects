using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TVNFramework.Modules.GenericContent.Models;
using TVNFramework.Modules.Transactions.Models;

namespace QuyenMua.Data.DTOs
{
    public class DTOTransaction
    {
        public DTOTransaction(GenericTransactionModel model)
        {
            this.Number = model.FriendlyNumber.ToString();
            this.Symbol = model.SymbolItem.Name;
            this.Type = model.TransactionTypeView;
            this.AmountView = model.AmountView;
            this.PriceView = model.PriceView;
            this.UpdatedTime = model.UpdatedTime;
        }

        public string Number
        {
            get;
            private set;
        }

        public string Symbol
        {
            get;
            private set;
        }

        public string Type
        {
            get;
            private set;
        }

        public string AmountView
        {
            get;
            private set;
        }

        public string PriceView
        {
            get;
            private set;
        }

        public string UpdatedTime
        {
            get;
            private set;
        }
    }
}
