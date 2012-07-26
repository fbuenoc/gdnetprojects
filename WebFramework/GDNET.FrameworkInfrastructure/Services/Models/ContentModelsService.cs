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
        #region ContentItem

        public ContentItemModel GetContentItemModel(ContentItem contentItem)
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

            return listContentItems.Select(x => this.GetContentItemModel(x)).ToList();
        }

        public ContentItem CreateContentItem(ContentItemModel itemModel)
        {
            return new ContentItem()
            {
                Description = itemModel.Description,
                Keywords = itemModel.Keywords,
                IsActive = itemModel.IsActive,
                Name = itemModel.Name
            };
        }

        #endregion

        #region

        public ContentPartModel GetContentPartModel(ContentPart contentPart)
        {
            return new ContentPartModel()
            {
                Details = contentPart.Details,
                IsActive = contentPart.IsActive,
                Name = contentPart.Name
            };
        }

        public IList<ContentPartModel> GetAllContentParts(ContentItem contentItem)
        {
            List<ContentPartModel> contentParts = new List<ContentPartModel>();
            foreach (var contentPart in contentItem.Parts)
            {
                var partModel = this.GetContentPartModel(contentPart);
                contentParts.Add(partModel);
            }

            return contentParts;
        }

        #endregion
    }
}
