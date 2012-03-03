using System.Linq;
using System.Web.Mvc;
using GDNET.Web.Helpers;
using GDNET.Web.Mvc.Helpers;
using WebFramework.Constants;
using WebFramework.Modeles.Base;
using WebFramework.Modeles.Framework.Base;
using WebFramework.Modeles.Framework.Common;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.DefaultImpl;
using WebFramework.Common;

namespace WebFramework.Areas.Framework.Controllers
{
    public class ContentItemController : ListCrudControllerBase<ContentItemModel>
    {
        public override ActionResult List()
        {
            var listOfItems = DomainRepositories.ContentItem.GetAll().Select(x => new ContentItemModel(x));
            return base.View(listOfItems);
        }

        protected override ContentItemModel OnDetailsChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override ContentItemModel OnCreateChecking()
        {
            ContentItemModel itemModel = base.OnCreateChecking();

            // When create new Content Item, we have to look which Content Type contains this one
            string contentTypeId;
            if (QueryStringAssistant.GetValueAsString(QueryStringConstants.Key, out contentTypeId))
            {
                var typeModel = ModelService.GetModelById<ContentTypeModel>(contentTypeId);
                itemModel.InitializeContentType(typeModel);
            }

            return itemModel;
        }

        protected override object OnCreateExecuting(ContentItemModel model, FormCollection collection)
        {
            object entityId = null;
            var contentType = DomainRepositories.ContentType.GetById(model.ContentTypeId);
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

        protected override ContentItemModel OnDeleteChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override bool OnDeleteExecuting(ContentItemModel model, FormCollection collection)
        {
            long contentItemId = collection.GetItemId<long>();
            return DomainRepositories.ContentItem.Delete(contentItemId);
        }

        protected override ContentItemModel OnEditChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override bool OnEditExecuting(ContentItemModel model, FormCollection collection)
        {
            var ciEntity = DomainRepositories.ContentItem.GetById(model.Id);
            if (ciEntity.Name != null)
            {
                ciEntity.Name.Value = model.Name;
            }
            if (ciEntity.Description != null)
            {
                ciEntity.Description.Value = model.Description;
            }
            ciEntity.Position = model.Position;

            return DomainRepositories.ContentItem.Update(ciEntity);
        }
    }
}
