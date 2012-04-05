using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebFramework.Common.Framework.Base;
using WebFramework.Common.Framework.Common;
using WebFramework.Domain;
using WebFramework.UI.Translations;

namespace WebFramework.UI.Helpers
{
    public class ActionLinkFactory
    {
        private HtmlHelper htmlHelper;

        public ActionLinkFactory(HtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        public MvcHtmlString ActionLink(string linkCodeText, string actionName)
        {
            string linkText = DomainServices.Translation.Translate(linkCodeText);
            return this.htmlHelper.ActionLink(linkText, actionName);
        }

        public MvcHtmlString ActionLink(string linkCodeText, string actionName, string controllerName)
        {
            string linkText = DomainServices.Translation.Translate(linkCodeText);
            return this.htmlHelper.ActionLink(linkText, actionName, controllerName);
        }

        public MvcHtmlString ActionLink(string linkCodeText, string actionName, string controllerName, object routeValues)
        {
            string linkText = DomainServices.Translation.Translate(linkCodeText);
            return this.htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, null);
        }

        public MvcHtmlString ActionLinkUpdateValue(ContentItemAttributeValueModel valueModel)
        {
            var routeValues = new { idci = valueModel.ContentItem.Id, id = valueModel.Id };
            return this.ActionLink("SysTranslation.Update", "Edit", "ContentItemAttributeValue", routeValues);
        }

        public MvcHtmlString ActionDetailLink(EntityType objectType, ModelBase modelEntity)
        {
            var routeFramework = new { area = "Framework" };
            var routeSystem = new
            {
                area = "System",
                id = modelEntity.EntityId.ToString()
            };

            switch (objectType)
            {
                case EntityType.Page:
                    return this.htmlHelper.ActionLink("Details", "Details", "Page", routeSystem, null);
                case EntityType.Widget:
                    return this.htmlHelper.ActionLink("Details", "Details", "Widget", routeSystem, null);
                case EntityType.Zone:
                    return this.htmlHelper.ActionLink("Details", "Details", "Zone", routeSystem, null);
            }

            return MvcHtmlString.Create(string.Empty);
        }

        public MvcHtmlString ActionEditLink(EntityType objectType, ModelBase modelEntity)
        {
            var routeFramework = new { area = "Framework" };
            var routeSystem = new
            {
                area = "System",
                id = modelEntity.EntityId.ToString()
            };

            switch (objectType)
            {
                case EntityType.Page:
                    return this.htmlHelper.ActionLink("Edit", "Edit", "Page", routeSystem, null);
                case EntityType.Widget:
                    return this.htmlHelper.ActionLink("Edit", "Edit", "Widget", routeSystem, null);
                case EntityType.Zone:
                    return this.htmlHelper.ActionLink("Edit", "Edit", "Zone", routeSystem, null);
            }

            return MvcHtmlString.Create(string.Empty);
        }

        public MvcHtmlString ActionDeleteLink(EntityType objectType, ModelBase modelEntity)
        {
            var routeFramework = new { area = "Framework" };
            var routeSystem = new
            {
                area = "System",
                id = modelEntity.EntityId.ToString()
            };

            switch (objectType)
            {
                case EntityType.Page:
                    return this.htmlHelper.ActionLink("Delete", "Delete", "Page", routeSystem, null);
                case EntityType.Widget:
                    return this.htmlHelper.ActionLink("Delete", "Delete", "Widget", routeSystem, null);
                case EntityType.Zone:
                    return this.htmlHelper.ActionLink("Delete", "Delete", "Zone", routeSystem, null);
            }

            return MvcHtmlString.Create(string.Empty);
        }

        public MvcHtmlString ActionListLink(EntityType listType)
        {
            var routeFramework = new { area = "Framework" };
            var routeSystem = new { area = "System" };
            var sysTranslation = new SystemTranslation();

            switch (listType)
            {
                case EntityType.Application:
                    return this.htmlHelper.ActionLink(sysTranslation.ReturnToListOfXYZ(sysTranslation.EntityApplication), "List", "Application", routeFramework, null);
                case EntityType.ContentAttribute:
                    return this.htmlHelper.ActionLink(sysTranslation.ReturnToListOfXYZ(sysTranslation.EntityContentAttribute), "List", "ContentAttribute", routeFramework, null);
                case EntityType.ContentItem:
                    return this.htmlHelper.ActionLink(sysTranslation.ReturnToListOfXYZ(sysTranslation.EntityContentItem), "List", "ContentItem", routeFramework, null);
                case EntityType.ContentType:
                    return this.htmlHelper.ActionLink(sysTranslation.ReturnToListOfXYZ(sysTranslation.EntityContentType), "List", "ContentType", routeFramework, null);
                case EntityType.Culture:
                    return this.htmlHelper.ActionLink(sysTranslation.ReturnToListOfXYZ(sysTranslation.EntityCulture), "List", "Culture", routeFramework, null);
                case EntityType.ListValue:
                    return this.htmlHelper.ActionLink(sysTranslation.ReturnToListOfXYZ(sysTranslation.EntityListValue), "List", "ListValue", routeFramework, null);
                case EntityType.Role:
                    return this.htmlHelper.ActionLink(sysTranslation.ReturnToListOfXYZ(sysTranslation.EntityRole), "List", "Role", routeFramework, null);
                case EntityType.Translation:
                    return this.htmlHelper.ActionLink(sysTranslation.ReturnToListOfXYZ(sysTranslation.EntityTranslation), "List", "Translation", routeFramework, null);

                case EntityType.Page:
                    return this.htmlHelper.ActionLink(sysTranslation.ReturnToListOfXYZ(sysTranslation.EntityPage), "List", "Page", routeSystem, null);
                case EntityType.Zone:
                    return this.htmlHelper.ActionLink(sysTranslation.ReturnToListOfXYZ(sysTranslation.EntityZone), "List", "Zone", routeSystem, null);
                case EntityType.Widget:
                    return this.htmlHelper.ActionLink(sysTranslation.ReturnToListOfXYZ(sysTranslation.EntityWidget), "List", "Widget", routeSystem, null);
            }

            return MvcHtmlString.Create(string.Empty);
        }

        public MvcHtmlString ActionListLink(string entityName, string actionName)
        {
            var sysTranslation = new SystemTranslation();
            return this.htmlHelper.ActionLink(sysTranslation.ReturnToListOfXYZ(entityName), actionName);
        }
    }
}
