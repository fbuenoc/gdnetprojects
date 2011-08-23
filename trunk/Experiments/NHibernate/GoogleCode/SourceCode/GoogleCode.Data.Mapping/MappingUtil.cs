using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace GoogleCode.Data.Mapping
{
    public static class MappingUtil
    {
        /// <summary>
        /// Get HbmMapping from map classes.
        /// </summary>
        /// <returns></returns>
        public static HbmMapping GetHbmMapping()
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(new Type[] { typeof(ProjectMap), typeof(LabelMap), typeof(ProjectLabelLinkMap) });

            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
}
