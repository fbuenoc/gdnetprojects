using GDNET.FrameworkInfrastructure.Services.General;
using GDNET.FrameworkInfrastructure.Services.Models;
using GDNET.FrameworkInfrastructure.Services.Storage;

namespace GDNET.FrameworkInfrastructure.Services
{
    public sealed class WebFrameworkServices
    {
        public static AccountModelsService AccountModels
        {
            get { return new AccountModelsService(); }
        }

        public static ContentModelsService ContentModels
        {
            get { return new ContentModelsService(); }
        }

        public static TranslationService Translation
        {
            get { return new TranslationService(); }
        }

        public static DataStoredService DataStored
        {
            get { return new DataStoredService(); }
        }
    }
}
