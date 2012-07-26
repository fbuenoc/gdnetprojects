using System.Collections.Generic;
using System.Linq;
using GDNET.Domain.Content;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Models.Content;
using GDNET.Utils;

namespace GDNET.FrameworkInfrastructure.Services.Models
{
    public class ContentModelsService
    {
        public ContentItemModel GetTopContentItemModel(ContentItem contentItem)
        {
            return new ContentItemModel()
            {
                Description = contentItem.Description,
                IsActive = contentItem.IsActive,
                Keywords = contentItem.Keywords,
                Name = contentItem.Name
            };
        }

        public IList<ContentItemModel> GetTopContentItemModels(int maxResults)
        {
            var defaultContentItem = default(ContentItem);
            var propertyCreatedAt = ExpressionAssistant.GetPropertyName(() => defaultContentItem.CreatedAt);
            var listContentItems = DomainRepositories.ContentItem.GetTopByProperty(maxResults, propertyCreatedAt);

            return listContentItems.Select(x => this.GetTopContentItemModel(x)).ToList();
        }
    }
}
