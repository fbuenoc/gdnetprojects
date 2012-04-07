using System;
using System.Web.Mvc;
using GDNET.Web.Helpers;
using WebFramework.Common.Common;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.System;

namespace WebFramework.Areas.System.Controllers
{
    public class RegionController : AbstractListCrudController<RegionModel>
    {
        public override ActionResult List()
        {
            throw new NotImplementedException();
        }

        protected override RegionModel OnCreateChecking()
        {
            RegionModel regionModel = base.OnCreateChecking();

            var zoneId = QueryStringAssistant.ParseInteger(EntityQueryString.ZoneId);
            regionModel.InitializeZone(zoneId);

            return regionModel;
        }

        protected override object OnCreateExecuting(RegionModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        protected override bool OnDeleteExecuting(RegionModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }

        protected override bool OnEditExecuting(RegionModel model, FormCollection collection)
        {
            throw new NotImplementedException();
        }
    }
}
