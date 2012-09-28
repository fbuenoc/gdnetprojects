using System.Linq;
using GDNET.Domain.Entities.System.ReferenceData;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Services.Storage;

namespace GDNET.FrameworkInfrastructure.Models.System
{
    public class UserCustomizedInformationModel : UserCustomizedInformation
    {
        public UserCustomizedInformationModel(UserCustomizedInformation info)
            : base(info.Language, info.ApplyForUI)
        {
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

                return string.Empty;
            }
        }
    }
}
