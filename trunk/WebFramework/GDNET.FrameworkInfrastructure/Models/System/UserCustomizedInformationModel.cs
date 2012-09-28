using System;
using System.Linq;
using GDNET.Domain.Entities.System.ReferenceData;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Models.System
{
    public class UserCustomizedInformationModel
    {
        public bool ApplyForUI
        {
            get;
            set;
        }

        public string Language
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
                    var languageEntity = catalogLanguages.Lines.FirstOrDefault(x => x.Code == this.Language);
                    if (languageEntity != null)
                    {
                        return languageEntity.Name;
                    }
                }

                return WebFrameworkServices.Translation.GetByKeyword("GUI.UserCustomizedInformation.LanguageNotSelected");
            }
        }

        public UserCustomizedInformationModel()
        {
        }

        public UserCustomizedInformationModel(string serialized)
        {
            if (!string.IsNullOrEmpty(serialized))
            {
                var infos = serialized.Split('|');
                this.Language = infos[0];
                this.ApplyForUI = Convert.ToBoolean(infos[1]);
            }
        }

        public UserCustomizedInformationModel(string language, bool applyForUI)
        {
            this.Language = language;
            this.ApplyForUI = applyForUI;
        }

        public string Serialize()
        {
            return string.Format("{0}|{1}|{2}", this.Language, this.ApplyForUI, this.LanguageName);
        }
    }
}
