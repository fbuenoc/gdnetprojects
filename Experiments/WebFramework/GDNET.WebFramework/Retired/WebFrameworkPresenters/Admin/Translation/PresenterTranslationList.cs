using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Common.Adapters;
using GDNET.Common.MVP;

using WebFrameworkData;
using WebFrameworkDomainDto.Common;
using WebFrameworkPresenters.Admin.Translation.Views;
using WebFrameworkDomain;

namespace WebFrameworkPresenters.Admin.Translation
{
    public class PresenterTranslationList : PresenterBase
    {
        public IViewTranslationList CurrentView
        {
            get { return (IViewTranslationList)base.View; }
        }

        public PresenterTranslationList(IViewTranslationList view, ViewMode mode)
            : base(view, mode)
        {
        }

        public override void Initlialize(bool isPostBack)
        {
            if (!isPostBack)
            {
                var translations = DomainRepositories.Translation.GetAll();
                var translationsDtos = translations.Select(t => new TranslationDTO(t)).ToList();
                this.CurrentView.ListViewTranslation.DataSource = translationsDtos;
            }
        }
    }
}
