﻿using WebFramework.Common.Framework.Base;
using WebFramework.Domain;

namespace WebFramework.UI.Helpers
{
    public class TranslationFactory
    {
        public string Translate(string codeText)
        {
            return DomainServices.Translation.Translate(codeText);
        }

        public string CreateOrUpdate<TId>(IModel<TId> viewModel)
        {
            string code = viewModel.IsNew ? "SysTranslation.Create" : "SysTranslation.Update";
            return this.Translate(code);
        }

        public string InContentTypeXYZ(string xyz)
        {
            string formatXYZ = DomainServices.Translation.Translate("SysTranslation.ContentItem.InContentTypeXYZ");
            return string.Format(formatXYZ, xyz);
        }
    }
}
