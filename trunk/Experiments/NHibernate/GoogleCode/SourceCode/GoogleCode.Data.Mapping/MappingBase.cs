using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.Mapping.ByCode.Conformist;

using GoogleCode.Core.Domain;
using NHibernate.Mapping.ByCode;
using GDNET.Common.Domain;

namespace GoogleCode.Data.Mapping
{
    public abstract class MappingBase<TObject, TId> : ClassMapping<TObject> where TObject : DomainBase<TId>
    {
        public MappingBase()
        {
            base.Id<TId>(entity => entity.Id, map => map.Generator(Generators.Native));
        }
    }
}
