using System.Linq;
using GDNET.Domain.Entities.System.ReferenceData;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Models.System
{
    public class UserCustomizedInformationModel
    {
        #region Properties

        public string Language
        {
            get;
            set;
        }

        public string LanguageUI
        {
            get;
            set;
        }

        public string LanguageName
        {
            get
            {
                var catalogLanguages = DomainRepositories.Catalog.FindByCode(SystemCatalogs.Languages);
                if (catalogLanguages != null)
                {
                    var languageEntity = catalogLanguages.Lines.FirstOrDefault(x => x.Code == this.LanguageUI);
                    if (languageEntity != null)
                    {
                        return languageEntity.Name;
                    }
                }

                return WebFrameworkServices.Translation.GetByKeyword("GUI.UserCustomizedInformation.LanguageNotSelected");
            }
        }

        #endregion

        #region Methods

        public UserCustomizedInformationModel()
        {
        }

        public UserCustomizedInformationModel(string serialized)
        {
            if (!string.IsNullOrEmpty(serialized))
            {
                var infos = serialized.Split('|');
                this.Language = infos[0];
                this.LanguageUI = infos[1];
            }
        }

        public UserCustomizedInformationModel(string language, string languageUI)
        {
            this.Language = language;
            this.LanguageUI = languageUI;
        }

        public string Serialize()
        {
            return string.Format("{0}|{1}|{2}", this.Language, this.LanguageUI, this.LanguageName);
        }

        #endregion
    }
}
