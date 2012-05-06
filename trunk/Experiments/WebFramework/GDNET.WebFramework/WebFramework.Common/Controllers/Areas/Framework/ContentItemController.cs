using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GDNET.Web.Helpers;
using GDNET.Web.Mvc.Helpers;
using WebFramework.Common.Common;
using WebFramework.Common.Constants;
using WebFramework.Common.Framework.Common;
using WebFramework.Common.Security;
using WebFramework.Domain;
using WebFramework.Domain.Common;

namespace WebFramework.Common.Controllers.Areas.Framework
{
    public class ContentItemController : AbstractListCrudController<ContentItemModel>, IRequiredAdministerController
    {
        public override ActionResult List()
        {
            IList<ContentItemModel> listOfItems = new List<ContentItemModel>();

            string key;
            if (QueryStringAssistant.GetValueAsString(QueryStringConstants.Key, out key))
            {
                long contentTypeId = 0;
                if (long.TryParse(key, out contentTypeId))
                {
                    var contentType = DomainRepositories.ContentType.GetById(contentTypeId);
                    listOfItems = DomainRepositories.ContentItem.GetByContentType(contentType).Select(x => new ContentItemModel(x)).ToList();
                }
            }
            else
            {
                listOfItems = DomainRepositories.ContentItem.GetAll().Select(x => new ContentItemModel(x)).ToList();
            }

            return base.View(listOfItems);
        }

        protected override ContentItemModel OnDetailsChecking(string id)
        {
            ContentItemModel itemModel = base.OnDetailsChecking(id);

            // Check to add empty value for new attribute of content type
            if (itemModel.ContentType != null)
            {
                if (itemModel.AttributesValue.Any(x => itemModel.ContentType.Attributes.Any(y => y.Id != x.ContentAttribute.Id)))
                {
                    ContentItem itemEntity = DomainRepositories.ContentItem.GetById(itemModel.Id);
                    foreach (var attribute in itemEntity.ContentType.ContentAttributes.Where(x => !itemModel.AttributesValue.Any(y => x.Id == y.ContentAttribute.Id)))
                    {
                        ContentItemAttributeValue attributeValue = ContentItemAttributeValue.Factory.Create(attribute, string.Empty);
                        itemEntity.AddAttributeValue(attributeValue);
                    }

                    DomainRepositories.RepositoryAssistant.Flush();
                    itemModel = new ContentItemModel(itemEntity);
                }
            }

            return itemModel;
        }

        protected override ContentItemModel OnCreateChecking()
        {
            ContentItemModel itemModel = base.OnCreateChecking();

            long? contentTypeId = QueryStringAssistant.ParseInteger(QueryStringConstants.Key);
            if (contentTypeId.HasValue)
            {
                var contentType = DomainRepositories.ContentType.GetById(contentTypeId.Value);
                itemModel.InitializeContentType(contentType);
            }

            return itemModel;
        }

        protected override object OnCreateExecuting(ContentItemModel model, FormCollection collection)
        {
            ContentType contentType = null;
            long? contentTypeId = QueryStringAssistant.ParseInteger(QueryStringConstants.Key);
            if (contentTypeId.HasValue)
            {
                contentType = DomainRepositories.ContentType.GetById(contentTypeId.Value);
                model.InitializeContentType(contentType);
            }

            object entityId = null;
            var attributesInfo = DomainServices.ContentType.GetAttributesInformation(contentType);

            string errorMessages = string.Empty;
            if (FrameworkServices.Validation.ValidateInput(attributesInfo, collection, out errorMessages))
            {
                var itemEntity = ContentItem.Factory.Create(model.Name, model.Description, contentType, model.Position);

                if (DomainRepositories.ContentItem.Save(itemEntity))
                {
                    DomainServices.ContentType.BuildAttributesValue(contentType, itemEntity, collection.ToDictionary());
                    DomainRepositories.RepositoryAssistant.Flush();

                    entityId = itemEntity.Id;
                }
            }

            return entityId;
        }

        protected override bool OnDeleteExecuting(ContentItemModel model, FormCollection collection)
        {
            long contentItemId = collection.GetItemId<long>();
            return DomainRepositories.ContentItem.Delete(contentItemId);
        }

        protected override bool OnEditExecuting(ContentItemModel model, FormCollection collection)
        {
            var ciEntity = DomainRepositories.ContentItem.GetById(model.Id);
            ciEntity.Name.Value = model.Name;
            ciEntity.Description.Value = model.Description;

            return DomainRepositories.ContentItem.Update(ciEntity);
        }
    }
}
