using System.Web.Mvc;
using System.Web.Mvc.Html;
using Finley.Common;
using GDNET.Common.DesignByContract;
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
            return this.ActionDetailLink(objectType, modelEntity, string.Empty);
        }

        public MvcHtmlString ActionDetailLink(EntityType objectType, ModelBase modelEntity, string linkText, object customRoutes)
        {
            object routeValuesFramework = new { area = "Framework" };
            object routeValuesSystem = new { area = "System" };

            if (modelEntity != null)
            {
                object tempRoutes = new
                {
                    id = modelEntity.EntityId.ToString()
                };
                routeValuesSystem = TypeMerger.MergeTypes(routeValuesSystem, tempRoutes);
                routeValuesFramework = TypeMerger.MergeTypes(routeValuesFramework, tempRoutes);
            }

            if (customRoutes != null)
            {
                routeValuesSystem = TypeMerger.MergeTypes(routeValuesSystem, customRoutes);
                routeValuesFramework = TypeMerger.MergeTypes(routeValuesFramework, customRoutes);
            }

            if (string.IsNullOrEmpty(linkText))
            {
                linkText = "Details";
            }

            switch (objectType)
            {
                case EntityType.Page:
                    return this.htmlHelper.ActionLink(linkText, "Details", "Page", routeValuesSystem, null);
                case EntityType.Widget:
                    return this.htmlHelper.ActionLink(linkText, "Details", "Widget", routeValuesSystem, null);
                case EntityType.Zone:
                    return this.htmlHelper.ActionLink(linkText, "Details", "Zone", routeValuesSystem, null);
                case EntityType.Region:
                    return this.htmlHelper.ActionLink(linkText, "Details", "Region", routeValuesSystem, null);
                default:
                    ThrowException.NotImplementedException("");
                    break;
            }

            return MvcHtmlString.Create(string.Empty);
        }

        public MvcHtmlString ActionDetailLink(EntityType objectType, object routeValues, string linkText, object htmlAttributes = null)
        {
            switch (objectType)
            {
                case EntityType.Page:
                    return this.htmlHelper.ActionLink(linkText, "Details", "Page", routeValues, htmlAttributes);
                case EntityType.Widget:
                    return this.htmlHelper.ActionLink(linkText, "Details", "Widget", routeValues, htmlAttributes);
                case EntityType.Zone:
                    return this.htmlHelper.ActionLink(linkText, "Details", "Zone", routeValues, htmlAttributes);
                case EntityType.Region:
                    return this.htmlHelper.ActionLink(linkText, "Details", "Region", routeValues, null);
                default:
                    ThrowException.NotImplementedException("");
                    break;
            }

            return MvcHtmlString.Create(string.Empty);
        }

        public MvcHtmlString CreateActionDelete(EntityType objectType, ModelBase modelEntity, object customRoutes, object htmlAttributes = null)
        {
            string linkText = "Delete";
            object routeValues = TypeMerger.MergeTypes(customRoutes, new { id = modelEntity.EntityId.ToString() });

            switch (objectType)
            {
                case EntityType.Region:
                    return this.htmlHelper.ActionLink(linkText, "Delete", "Region", routeValues, htmlAttributes);

                default:
                    ThrowException.NotImplementedException("");
                    break;
            }

            return MvcHtmlString.Create(string.Empty);
        }

        public MvcHtmlString ActionCreateLink(EntityType objectType, object routeValues = null)
        {
            return this.ActionCreateLink(string.Empty, objectType, routeValues);
        }

        public MvcHtmlString ActionCreateLink(string linkText, EntityType objectType, object routeValues = null)
        {
            object routeValuesFramework = new { area = "Framework" };
            object routeValuesSystem = new { area = "System" };
            if (routeValues != null)
            {
                routeValuesFramework = TypeMerger.MergeTypes(routeValuesFramework, routeValues);
                routeValuesSystem = TypeMerger.MergeTypes(routeValuesSystem, routeValues);
            }
            if (string.IsNullOrEmpty(linkText))
            {
                linkText = "Create";
            }

            switch (objectType)
            {
                case EntityType.Region:
                    return this.htmlHelper.ActionLink(linkText, "Create", "Region", routeValuesSystem, null);
                case EntityType.Zone:
                    return this.htmlHelper.ActionLink(linkText, "Create", "Zone", routeValuesSystem, null);
                default:
                    ThrowException.NotImplementedException("");
                    break;
            }

            return MvcHtmlString.Create(string.Empty);
        }

        public MvcHtmlString ActionEditLink(EntityType objectType, ModelBase modelEntity)
        {
            var routeValuesFramework = new { area = "Framework" };
            var routeValuesSystem = new
            {
                area = "System",
                id = modelEntity.EntityId.ToString()
            };

            switch (objectType)
            {
                case EntityType.Page:
                    return this.htmlHelper.ActionLink("Edit", "Edit", "Page", routeValuesSystem, null);
                case EntityType.Widget:
                    return this.htmlHelper.ActionLink("Edit", "Edit", "Widget", routeValuesSystem, null);
                case EntityType.Zone:
                    return this.htmlHelper.ActionLink("Edit", "Edit", "Zone", routeValuesSystem, null);
                default:
                    ThrowException.NotImplementedException("");
                    break;
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
                default:
                    ThrowException.NotImplementedException("");
                    break;
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

                default:
                    ThrowException.NotImplementedException("");
                    break;
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
