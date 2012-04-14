using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Common.MVP;

using QuyenMua.Data.DTOs;

namespace QuyenMua.Presenters.Views
{
    public interface IViewListTransaction : IView<PresenterTransactionList, string>
    {
        /// <summary>
        /// Sets available transactions
        /// </summary>
        List<DTOTransaction> Transactions
        {
            set;
        }
    }
}
