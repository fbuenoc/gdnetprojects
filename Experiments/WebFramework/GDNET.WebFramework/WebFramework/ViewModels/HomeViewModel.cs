﻿using System.Collections.Generic;
using WebFramework.Common.Framework.Common;

namespace WebFramework.ViewModels
{
    public sealed class HomeViewModel
    {
        public IList<ContentItemModel> Products
        {
            get;
            set;
        }

        public IList<ContentItemModel> Articles
        {
            get;
            set;
        }
    }
}