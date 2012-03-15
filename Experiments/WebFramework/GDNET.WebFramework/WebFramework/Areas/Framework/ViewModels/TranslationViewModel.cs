using System.Collections.Generic;
using GDNET.Web.Helpers;
using GDNET.Web.Mvc.Helpers;
using WebFramework.Areas.Framework.Constants;
using WebFramework.Base.Framework.Common;

namespace WebFramework.Areas.Framework.ViewModels
{
    public sealed class TranslationViewModel
    {
        private IEnumerable<TranslationModel> translations = new List<TranslationModel>();
        private IEnumerable<CultureModel> cultures = new List<CultureModel>();
        private IEnumerable<ListValueModel> categories = new List<ListValueModel>();

        public IEnumerable<TranslationModel> Translations
        {
            get { return translations; }
            set { translations = value; }
        }

        public IEnumerable<CultureModel> Cultures
        {
            get { return cultures; }
            set { cultures = value; }
        }

        public IEnumerable<ListValueModel> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public IEnumerable<ListValueDTO> CulturesListValue
        {
            get
            {
                List<ListValueDTO> listValues = new List<ListValueDTO>();

                foreach (var culture in this.Cultures)
                {
                    string url = NavigationAssistant.AddParameter(NavigationAssistant.CurrentUrl, FrameworkConstants.QueryString.Culture, culture.Id.ToString());
                    listValues.Add(new ListValueDTO(url, culture.CultureCode));
                }

                return listValues;
            }
        }

        public IEnumerable<ListValueDTO> CategoriesListValue
        {
            get
            {
                List<ListValueDTO> listValues = new List<ListValueDTO>();

                foreach (var category in this.Categories)
                {
                    string url = NavigationAssistant.AddParameter(NavigationAssistant.CurrentUrl, FrameworkConstants.QueryString.Category, category.Id.ToString());
                    listValues.Add(new ListValueDTO(url, category.Description));
                }

                return listValues;
            }
        }

    }
}