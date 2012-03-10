using System.Collections.Generic;
using WebFramework.Base.Framework.Common;

namespace WebFramework.ViewModels
{
    public sealed class HomeViewModel
    {
        public IList<ContentItemModel> Products
        {
            get;
            set;
        }
    }
}