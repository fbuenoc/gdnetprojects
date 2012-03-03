using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Common.MVP;

using WebFrameworkData;
using WebFrameworkDomain;
using WebFrameworkDomain.Common;
using WebFrameworkPresenters.Admin.Translation.Views;

using TranslationDomain = WebFrameworkDomain.Common.Translation;

namespace WebFrameworkPresenters.Admin.Translation
{
    public class PresenterTranslationDetail : PresenterCrudBase
    {
        protected new IViewTranslationDetail View
        {
            get { return (IViewTranslationDetail)base.View; }
        }

        public PresenterTranslationDetail(IViewTranslationDetail view, ViewMode mode)
            : base(view, mode)
        {
        }

        /// <summary>
        /// Create new translation
        /// </summary>
        /// <returns></returns>
        public override bool Create()
        {
            var translation = TranslationDomain.Factory.Create();
            translation.Code = this.View.CodeInput.Text;
            translation.Value = this.View.TextInput.Text;

            DomainRepositories.Translation.Save(translation);
            base.View.ElementId = translation.Id;

            return (translation.Id > 0);
        }

        public override bool Modify()
        {
            var translation = DomainRepositories.Translation.GetById((long)this.View.ElementId);
            translation.Code = this.View.CodeInput.Text;
            translation.Value = this.View.TextInput.Text;

            DomainRepositories.Translation.Save(translation);

            return true;
        }

        public override bool Delete()
        {
            DomainRepositories.Translation.Delete((long)this.View.ElementId);
            return true;
        }

        public override void Initlialize(bool isPostBack)
        {
            if (isPostBack || !this.View.HasElementId)
            {
                return;
            }

            var translation = DomainRepositories.Translation.GetById((long)this.View.ElementId);
            if (translation == null)
            {
                return;
            }

            this.View.CodeInput.Text = translation.Code;
            this.View.TextInput.Text = translation.Value;
        }

        public override void ChangeMode(ViewMode mode)
        {
            base.ChangeMode(mode);

            this.View.CodeInput.Enable = base.IsCreatationOrModification;
            this.View.TextInput.Enable = base.IsCreatationOrModification;
        }
    }
}
