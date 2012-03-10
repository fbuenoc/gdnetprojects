using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Common.Adapters;
using GDNET.Common.MVP;

namespace WebFrameworkPresenters.Admin.Translation.Views
{
    public interface IViewTranslationList : IView
    {
        IAdapterLinkButton NewTranslation { get; }
        IAdapterListView ListViewTranslation { get; }
        IAdapterDataPager PagerTranslation { get; }
    }
}
