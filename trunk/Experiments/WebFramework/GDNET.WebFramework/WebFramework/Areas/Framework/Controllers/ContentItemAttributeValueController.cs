using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GDNET.Extensions;
using GDNET.Web.Helpers;
using GDNET.Web.Mvc.Adapters;
using WebFramework.Common.Common;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.Base;
using WebFramework.Common.Framework.Common;
using WebFramework.Common.Security;
using WebFramework.Domain;
using WebFramework.Domain.Common;
using WebFramework.UI;

namespace WebFramework.Areas.Framework.Controllers
{
    public class ContentItemAttributeValueController : AbstractCrudController<ContentItemAttributeValueModel>, IRequiredAdministerController
    {
        protected override object OnCreateExecuting(ContentItemAttributeValueModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        protected override bool OnDeleteExecuting(ContentItemAttributeValueModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        protected override ContentItemAttributeValueModel OnEditChecking(string id)
        {
            var contentItemId = QueryStringAssistant.ParseInteger(EntityQueryString.ContentItemId);
            if (contentItemId.HasValue)
            {
                IDictionary<object, object> parameters = DictionaryAssistant.BuildDictionary(EntityQueryString.ContentItemId, contentItemId.Value);
                return ModelService.GetModelById<ContentItemAttributeValueModel>(id, parameters);
            }

            return default(ContentItemAttributeValueModel);
        }

        protected override bool OnEditExecuting(ContentItemAttributeValueModel model, FormCollection collection)
        {
            var contentItemId = QueryStringAssistant.ParseInteger(EntityQueryString.ContentItemId);
            if (contentItemId.HasValue)
            {
                var contentItemObject = DomainRepositories.ContentItem.GetById(contentItemId.Value);
                var attributeValue = contentItemObject.AttributeValues.FirstOrDefault(x => x.Id == model.Id);
                HtmlEditorAdapter htmlEditor = new HtmlEditorAdapter(attributeValue.ContentAttribute.Code, collection);

                if (attributeValue.ContentAttribute.IsMultilingual)
                {
                    if (attributeValue.ValueTranslation == null)
                    {
                        Translation valueTranslation = Translation.Factory.Create(htmlEditor.Value);
                        attributeValue.SetValueTranslation(valueTranslation);
                    }
                    else
                    {
                        attributeValue.ValueTranslation.Value = htmlEditor.Value;
                    }
                }
                else
                {
                    attributeValue.SetValueText(htmlEditor.Value);
                }

                DomainRepositories.RepositoryAssistant.Flush();
                return true;
            }

            return false;
        }

        protected override ActionResult AfterEdited(ContentItemAttributeValueModel model, FormCollection collection)
        {
            var contentItemId = QueryStringAssistant.ParseInteger(EntityQueryString.ContentItemId);
            return base.RedirectToAction(ActionDetails, WebFrameworkConstants.Controllers.FrameworkContentItem.ToString(), new { id = contentItemId.Value });
        }
    }
}
