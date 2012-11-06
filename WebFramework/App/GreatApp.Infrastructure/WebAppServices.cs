using GreatApp.Infrastructure.Services;

namespace GreatApp.Infrastructure
{
    public sealed class WebAppServices
    {
        public static ContentModelsService ContentModels
        {
            get { return new ContentModelsService(); }
        }
    }
}
