using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Common.Adapters;
using GDNET.Common.MVP;

namespace WebFrameworkPresenters.Admin.Translation.Views
{
    public interface IViewTranslationDetail : IViewCrud
    {
        IAdapterLiteral BlocTitle { get; }
        IAdapterLiteral CodeLabel { get; }
        IAdapterTextBox CodeInput { get; }
        IAdapterLiteral TextLabel { get; }
        IAdapterTextBox TextInput { get; }
    }
}
