using System.Web.Mvc;
using System.Web.Mvc.Html;
using Finley.Common;
using GDNET.Common.DesignByContract;
using GDNET.Web.Helpers;
using WebFramework.Common.Constants;
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

        public MvcHtmlString ActionLinkCreate(string widget, string controllerName, string actionName)
        {
            return this.ActionLinkCreate(widget, controllerName, actionName, null);
        }

        public MvcHtmlString ActionLinkCreate(string widget, string controllerName, string actionName, object htmlAttributes)
        {
            var zoneId = QueryStringAssistant.ParseInteger(QueryStringConstants.ZoneId);
            var regionId = QueryStringAssistant.ParseInteger(QueryStringConstants.RegionId);
            var routeValues = new { zid = zoneId, rid = regionId };
            string linkText = DomainServices.Translation.Translate("SysTranslation.Create");
            return this.htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
        }

        public MvcHtmlString ActionLinkUpdate(string controllerName, string actionName, object entityId)
        {
            var zoneId = QueryStringAssistant.ParseInteger(QueryStringConstants.ZoneId);
            var regionId = QueryStringAssistant.ParseInteger(QueryStringConstants.RegionId);
            var routeValues = new { zid = zoneId, rid = regionId, eid = entityId.ToString() };
            string linkText = DomainServices.Translation.Translate("SysTranslation.Update");
            return this.htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues);
        }

        public MvcHtmlString ActionLinkUpdateValue(ContentItemAttributeValueModel valueModel)
        {
            var routeValues = new { idci = valueModel.ContentItem.Id, id = valueModel.Id };
            return this.ActionLink("SysTranslation.Update", "Edit", "ContentItemAttributeValue", routeValues);
        }

        #region Detail actions

        public MvcHtmlString CreateDetailAction(EntityType objectType, ModelEntityBase modelEntity)
        {
            string linkText = "Details";
            return this.CreateDetailAction(objectType, modelEntity, null, linkText);
        }

        public MvcHtmlString CreateDetailAction(EntityType objectType, ModelEntityBase modelEntity, object customRoutes)
        {
            string linkText = "Details";
            return this.CreateDetailAction(objectType, modelEntity, customRoutes, linkText);
        }

        public MvcHtmlString CreateDetailAction(EntityType objectType, ModelEntityBase modelEntity, object customRoutes, string linkText)
        {
            object routeValuesFramework = new
            {
                area = "Framework",
                id = modelEntity.EntityId.ToString()
            };
            object routeValuesSystem = new
            {
                area = "System",
                id = modelEntity.EntityId.ToString()
            };

            if (customRoutes != null)
            {
                routeValuesSystem = TypeMerger.MergeTypes(routeValuesSystem, customRoutes);
                routeValuesFramework = TypeMerger.MergeTypes(routeValuesFramework, customRoutes);
            }

            object routeValues = null;
            switch (objectType)
            {
                case EntityType.Page:
                case EntityType.Widget:
                case EntityType.Zone:
                case EntityType.Region:
                    routeValues = routeValuesSystem;
                    break;

                default:
                    ThrowException.NotImplementedException("");
                    break;
            }

            return this.CreateDetailActionInternal(objectType, routeValues, null, linkText);
        }

        private MvcHtmlString CreateDetailActionInternal(EntityType objectType, object routeValues, object htmlAttributes, string linkText)
        {
            string controllerName = string.Empty;

            switch (objectType)
            {
                case EntityType.Page:
                    controllerName = WebFrameworkConstants.Controllers.SystemPage;
                    break;

                case EntityType.Widget:
                    controllerName = WebFrameworkConstants.Controllers.SystemWidget;
                    break;

                case EntityType.Zone:
                    controllerName = WebFrameworkConstants.Controllers.SystemZone;
                    break;

                case EntityType.Region:
                    controllerName = WebFrameworkConstants.Controllers.SystemRegion;
                    break;

                default:
                    ThrowException.NotImplementedException("");
                    break;
            }

            return this.htmlHelper.ActionLink(linkText, "Details", controllerName, routeValues, htmlAttributes);
        }

        #endregion

        #region Delete actions

        public MvcHtmlString CreateActionDelete(EntityType objectType, ModelEntityBase modelEntity, object customRoutes, object htmlAttributes = null)
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

        #endregion

        #region Create actions

        public MvcHtmlString CreateActionCreate(EntityType objectType, object routeValues = null)
        {
            return this.CreateActionCreate(string.Empty, objectType, routeValues);
        }

        #endregion

        public MvcHtmlString CreateActionCreate(string linkText, EntityType objectType, object routeValues = null)
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

        public MvcHtmlString ActionEditLink(EntityType objectType, ModelEntityBase modelEntity)
        {
            return this.CreateEditAction(objectType, modelEntity, null);
        }

        public MvcHtmlString CreateEditAction(EntityType objectType, ModelEntityBase modelEntity, object customRouteValues, object htmlAttributes = null)
        {
            string linkText = "Edit";

            object routeValuesFramework = new
            {
                area = "Framework",
                id = modelEntity.EntityId.ToString()
            };
            object routeValuesSystem = new
            {
                area = "System",
                id = modelEntity.EntityId.ToString()
            };

            if (customRouteValues != null)
            {
                routeValuesFramework = TypeMerger.MergeTypes(routeValuesFramework, customRouteValues);
                routeValuesSystem = TypeMerger.MergeTypes(routeValuesSystem, customRouteValues);
            }

            switch (objectType)
            {
                case EntityType.Page:
                    return this.htmlHelper.ActionLink(linkText, "Edit", "Page", routeValuesSystem, htmlAttributes);
                case EntityType.Widget:
                    return this.htmlHelper.ActionLink(linkText, "Edit", "Widget", routeValuesSystem, htmlAttributes);
                case EntityType.Region:
                    return this.htmlHelper.ActionLink(linkText, "Edit", "Region", routeValuesSystem, htmlAttributes);
                case EntityType.Zone:
                    return this.htmlHelper.ActionLink(linkText, "Edit", "Zone", routeValuesSystem, htmlAttributes);
                default:
                    ThrowException.NotImplementedException("");
                    break;
            }

            return MvcHtmlString.Create(string.Empty);
        }

        public MvcHtmlString ActionDeleteLink(EntityType objectType, ModelEntityBase modelEntity)
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
