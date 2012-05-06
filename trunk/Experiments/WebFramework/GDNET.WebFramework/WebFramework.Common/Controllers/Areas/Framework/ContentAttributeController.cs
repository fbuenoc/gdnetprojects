using System.Linq;
using System.Web.Mvc;
using GDNET.Web.Helpers;
using GDNET.Web.Mvc.Helpers;
using WebFramework.Common.Constants;
using WebFramework.Common.Framework.Base;
using WebFramework.Common.Framework.Common;
using WebFramework.Common.Security;
using WebFramework.Domain;
using WebFramework.Domain.Common;

namespace WebFramework.Common.Controllers.Areas.Framework
{
    public class ContentAttributeController : AbstractListCrudController<ContentAttributeModel>, IRequiredAdministerController
    {
        public override ActionResult List()
        {
            var listOfAttributes = DomainRepositories.ContentAttribute.GetAll().Select(x => new ContentAttributeModel(x));
            return base.View(listOfAttributes);
        }

        protected override ContentAttributeModel OnCreateChecking()
        {
            ContentAttributeModel model = base.OnCreateChecking();

            // Get the content type from query string then passing value to attribute model
            string contentTypeId;
            if (QueryStringAssistant.GetValueAsString(QueryStringConstants.Key, out contentTypeId))
            {
                var contentTypeModel = ModelService.GetModelById<ContentTypeModel>(contentTypeId);
                if (contentTypeModel != null)
                {
                    model.ContentType = contentTypeModel.Name;
                    model.ContentTypeId = contentTypeModel.Id;
                }
            }

            return model;
        }

        protected override object OnCreateExecuting(ContentAttributeModel model, FormCollection collection)
        {
            var caEntity = ContentAttribute.Factory.Create(model.Code, model.Name, model.DataType.Name, model.ContentTypeId, model.Position);
            bool result = DomainRepositories.ContentAttribute.Save(caEntity);
            return result ? (object)caEntity.Id : null;
        }

        protected override bool OnDeleteExecuting(ContentAttributeModel model, FormCollection collection)
        {
            long contentAttributeId = collection.GetItemId<long>();
            return DomainRepositories.ContentAttribute.Delete(contentAttributeId);
        }

        protected override bool OnEditExecuting(ContentAttributeModel model, FormCollection collection)
        {
            var caEntity = DomainRepositories.ContentAttribute.GetById(model.Id);
            caEntity.Code = model.Code;

            if ((caEntity.DataType == null) || (caEntity.DataType.Id != model.DataTypeId))
            {
                caEntity.DataType = DomainRepositories.ListValue.GetById(model.DataTypeId);
            }
            if ((caEntity.ContentType == null) || (caEntity.ContentType.Id != model.ContentTypeId))
            {
                caEntity.ContentType = DomainRepositories.ContentType.GetById(model.ContentTypeId);
            }

            return DomainRepositories.ContentAttribute.Update(caEntity);
        }
    }
}
