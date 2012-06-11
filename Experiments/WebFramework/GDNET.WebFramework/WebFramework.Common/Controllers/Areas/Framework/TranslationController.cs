using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GDNET.Extensions;
using GDNET.Web.Helpers;
using GDNET.Web.Mvc.Helpers;
using WebFramework.Common.Framework.Common;
using WebFramework.Common.ViewModels.Framework;
using WebFramework.Domain;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;

namespace WebFramework.Common.Controllers.Areas.Framework
{
    public class TranslationController : AbstractListCrudController<TranslationModel>
    {
        public override ActionResult List()
        {
            var viewModel = new TranslationViewModel();
            List<string> propertiesConditions = new List<string>() { MetaInfos.Common.IsEditable };
            List<object> propertiesValues = new List<object>() { true };

            int cultureId = 0;
            long categoryId = 0;
            bool resultCulture = QueryStringAssistant.GetValueAs<int>(FrameworkConstants.QueryString.Culture, out cultureId);
            bool resultCategory = QueryStringAssistant.GetValueAs<long>(FrameworkConstants.QueryString.Category, out categoryId);

            if (resultCulture || resultCategory)
            {
                var culture = DomainRepositories.Culture.GetById(cultureId);
                var category = DomainRepositories.ListValue.GetById(categoryId);

                List<TranslationModel> listTranslations = new List<TranslationModel>();

                if (resultCulture && resultCategory)
                {
                    propertiesConditions.AddRange(MetaInfos.TranslationMeta.Culture, MetaInfos.TranslationMeta.Category);
                    propertiesValues.AddRange(culture, category);
                    listTranslations = DomainRepositories.Translation.FindByProperties(propertiesConditions.ToArray(), propertiesValues.ToArray()).Select(x => new TranslationModel(x)).ToList();
                }
                else if (resultCulture)
                {
                    propertiesConditions.AddRange(MetaInfos.TranslationMeta.Culture);
                    propertiesValues.AddRange(culture);
                    listTranslations = DomainRepositories.Translation.FindByProperties(propertiesConditions.ToArray(), propertiesValues.ToArray()).Select(x => new TranslationModel(x)).ToList();
                }
                else if (resultCategory)
                {
                    propertiesConditions.AddRange(MetaInfos.TranslationMeta.Category);
                    propertiesValues.AddRange(category);
                    listTranslations = DomainRepositories.Translation.FindByProperties(propertiesConditions.ToArray(), propertiesValues.ToArray()).Select(x => new TranslationModel(x)).ToList();
                }

                viewModel.Translations = listTranslations;
            }
            else
            {
                var listTranslations = DomainRepositories.Translation.FindByProperties(propertiesConditions.ToArray(), propertiesValues.ToArray()).Select(x => new TranslationModel(x)).ToList();
                viewModel.Translations = listTranslations;
            }

            var listCategories = DomainRepositories.ListValue.GetAllRootValues().Select(x => new ListValueModel(x)).ToList();
            viewModel.Categories = listCategories;

            var listCultures = DomainRepositories.Culture.GetAll().Select(x => new CultureModel(x)).ToList();
            viewModel.Cultures = listCultures;

            return base.View(viewModel);
        }

        protected override object OnCreateExecuting(TranslationModel model, FormCollection collection)
        {
            var translation = Translation.Factory.Create(model.Code, model.Value, model.CultureCode);
            var result = DomainRepositories.Translation.Save(translation);
            return result ? (object)translation.Id : null;
        }

        protected override bool OnDeleteExecuting(TranslationModel model, FormCollection collection)
        {
            long appId = collection.GetItemId<long>();
            return DomainRepositories.Translation.Delete(appId);
        }

        protected override bool OnEditExecuting(TranslationModel model, FormCollection collection)
        {
            try
            {
                var entity = DomainRepositories.Translation.GetById(model.Id);
                entity.Value = model.Value;

                return DomainRepositories.Translation.Update(entity);
            }
            catch
            {
                return false;
            }
        }
    }
}
