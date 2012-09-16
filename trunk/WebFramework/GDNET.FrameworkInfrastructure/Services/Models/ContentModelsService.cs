using System;
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

        public ContentItemModel GetContentItemModel(string id)
        {
            Guid guid = Guid.Empty;
            ContentItemModel model = null;

            if (Guid.TryParse(id, out guid))
            {
                ContentItem ci = DomainRepositories.ContentItem.GetById(guid);
                if (ci != null)
                {
                    model = this.GetContentItemModel(ci);
                }
            }

            return model;
        }

        public ContentItemModel GetContentItemModel(ContentItem contentItem)
        {
            var model = new ContentItemModel();
            model.Initialize(contentItem);

            return model;
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

        public ContentPart CreateContentPart(ContentPartModel partModel)
        {
            return new ContentPart()
            {
                Name = partModel.Name,
                Details = partModel.Details,
                IsActive = partModel.IsActive,
            };
        }

        #endregion

        #region ContentPart

        public ContentPart GetContentPart(string contentPartId, string contentItemId)
        {
            ContentPart cp = null;
            Guid guid = new Guid(contentItemId);

            ContentItem ci = DomainRepositories.ContentItem.GetById(guid);
            if (ci != null)
            {
                cp = ci.GetPart(new Guid(contentPartId));
            }

            return cp;
        }

        public void UpdateContentPart(ContentPart contentPart, ContentPartModel partModel)
        {
            contentPart.Name = partModel.Name;
            contentPart.Details = partModel.Details;
            contentPart.IsActive = partModel.IsActive;
        }

        public ContentPartModel GetContentPartModel(string contentPartId, string contentItemId)
        {
            ContentPartModel model = null;
            ContentPart cp = this.GetContentPart(contentPartId, contentItemId);

            if (cp != null)
            {
                model = this.GetContentPartModel(cp);
            }

            return model;
        }

        public ContentPartModel GetContentPartModel(ContentPart contentPart)
        {
            var model = new ContentPartModel();
            model.Initialize(contentPart);

            return model;
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

        public ContentItemPartsModel GetContentItemParts(ContentItem contentItem)
        {
            ContentItemPartsModel model = new ContentItemPartsModel(contentItem);
            model.AddContentParts(this.GetAllContentParts(contentItem));

            return model;
        }

        public void UpdateContentItem(ContentItem contentItem, ContentItemModel contentModel)
        {
            contentItem.Name = contentModel.Name;
            contentItem.Description = contentModel.Description;
            contentItem.Keywords = contentModel.Keywords;
            contentItem.IsActive = contentModel.IsActive;
        }

        #endregion
    }
}
