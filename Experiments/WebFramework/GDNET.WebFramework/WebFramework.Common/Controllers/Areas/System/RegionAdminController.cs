using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GDNET.Web.Helpers;
using WebFramework.Common.Common;
using WebFramework.Common.Constants;
using WebFramework.Common.Framework.Base;
using WebFramework.Common.Framework.System;
using WebFramework.Domain;
using WebFramework.Domain.System;

namespace WebFramework.Common.Controllers.Areas.System
{
    public class RegionAdminController : AbstractListCrudController<RegionModel>
    {
        private Zone zoneEntity = null;

        public override ActionResult List()
        {
            throw new NotImplementedException();
        }

        protected override RegionModel OnDetailsChecking(string id)
        {
            return this.GetRegionModel(id);
        }

        #region Create methods

        protected override RegionModel OnCreateChecking()
        {
            RegionModel regionModel = base.OnCreateChecking();

            if (this.GetZoneEntity())
            {
                regionModel.InitializeZone(this.zoneEntity);
            }

            return regionModel;
        }

        protected override object OnCreateExecuting(RegionModel model, FormCollection collection)
        {
            if (this.GetZoneEntity())
            {
                model.InitializeZone(this.zoneEntity);

                Widget widget = DomainRepositories.Widget.GetByCode(model.WidgetSelection);
                Region region = Region.Factory.Create(model.Name, widget);
                region.Description = model.Description;
                region.IsActive = model.IsActive;
                this.zoneEntity.AddRegion(region);

                DomainServices.Region.ApplyDefaultProperties(region);
                DomainRepositories.RepositoryAssistant.Flush();

                return region.Id;
            }

            return null;
        }

        protected override ActionResult AfterCreated(object objectId)
        {
            var zoneId = QueryStringAssistant.ParseInteger(EntityQueryString.ZoneId);
            return base.RedirectToAction(ActionDetails, new { id = objectId.ToString(), idzn = zoneId.Value });
        }

        #endregion

        #region Delete methods

        protected override RegionModel OnDeleteChecking(string id)
        {
            return this.GetRegionModel(id);
        }

        protected override bool OnDeleteExecuting(RegionModel model, FormCollection collection)
        {
            if (this.GetZoneEntity())
            {
                zoneEntity.RemoveRegionById(model.Id);
                DomainRepositories.RepositoryAssistant.Flush();
                return true;
            }

            return false;
        }

        public override ActionResult AfterDeleted()
        {
            var zoneId = QueryStringAssistant.ParseInteger(EntityQueryString.ZoneId);
            return base.RedirectToAction(ActionDetails, WebFrameworkConstants.Controllers.SystemZone, new { id = zoneId });
        }

        #endregion

        #region Edit methods

        protected override RegionModel OnEditChecking(string id)
        {
            return this.GetRegionModel(id);
        }

        protected override bool OnEditExecuting(RegionModel model, FormCollection collection)
        {
            if (this.GetZoneEntity())
            {
                var region = this.zoneEntity.GetRegionById(model.Id);
                region.Name = model.Name;
                region.Description = model.Description;
                region.IsActive = model.IsActive;

                DomainRepositories.RepositoryAssistant.Flush();
                return true;
            }

            return false;
        }

        protected override ActionResult AfterEdited(RegionModel model, FormCollection collection)
        {
            var zoneId = QueryStringAssistant.ParseInteger(EntityQueryString.ZoneId);
            return base.RedirectToAction(ActionDetails, WebFrameworkConstants.Controllers.SystemRegion, new { id = model.Id, idzn = zoneId });
        }

        #endregion

        #region Internal behaviors

        private bool GetZoneEntity()
        {
            if (this.zoneEntity == null)
            {
                var zoneId = QueryStringAssistant.ParseInteger(EntityQueryString.ZoneId);
                if (!zoneId.HasValue)
                {
                    return false;
                }

                this.zoneEntity = DomainRepositories.Zone.GetById(zoneId.Value);
            }

            return true;
        }

        private RegionModel GetRegionModel(string id)
        {
            RegionModel regionModel = default(RegionModel);

            var zoneId = QueryStringAssistant.ParseInteger(EntityQueryString.ZoneId);
            if (zoneId.HasValue)
            {
                IDictionary<object, object> parameters = new Dictionary<object, object>();
                parameters.Add(EntityQueryString.ZoneId, zoneId.Value);

                regionModel = ModelService.GetModelById<RegionModel>(id, parameters);
            }

            return regionModel;
        }

        #endregion

    }
}
