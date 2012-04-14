using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Common.MVP;
using QuyenMua.Data.DTOs;

namespace QuyenMua.Presenters.Views
{
    public interface IViewDetailTransaction : IViewCrud<PresenterTransactionDetail, int>
    {
        /// <summary>
        /// Current transaction
        /// </summary>
        DTOTransactionDetail Transaction
        {
            get;
            set;
        }
    }
}
