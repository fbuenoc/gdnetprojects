using GDNET.FrameworkInfrastructure.Services.Models;

namespace GDNET.FrameworkInfrastructure.Services
{
    public class WebFrameworkServices
    {
        public static AccountModelsService AccountModels
        {
            get { return new AccountModelsService(); }
        }

        public static ContentModelsService ContentModels
        {
            get { return new ContentModelsService(); }
        }
    }
}
