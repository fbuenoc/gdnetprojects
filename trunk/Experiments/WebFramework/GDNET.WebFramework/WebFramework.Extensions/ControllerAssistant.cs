using GDNET.Web.Helpers;
using WebFramework.Common.Constants;
using WebFramework.Domain;
using WebFramework.Domain.System;

namespace WebFramework.Extensions
{
    public static class ControllerAssistant
    {
        public static Region GetCurrentRegion()
        {
            var zoneId = QueryStringAssistant.ParseInteger(QueryStringConstants.ZoneId);
            var regionId = QueryStringAssistant.ParseInteger(QueryStringConstants.RegionId);

            if (zoneId.HasValue && regionId.HasValue)
            {
                var zone = DomainRepositories.Zone.GetById(zoneId.Value);
                if (zone != null)
                {
                    return zone.GetRegionById(regionId.Value);
                }
            }

            return null;
        }
    }
}
