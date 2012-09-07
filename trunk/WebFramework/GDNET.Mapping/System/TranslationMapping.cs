﻿using System;
using GDNET.Domain.Entities.System;
using GDNET.Mapping.Base;
using GDNET.NHibernate.Mapping;

namespace GDNET.Mapping.System
{
    public class TranslationMapping : AbstractJoinedSubclassMapping<Translation, Guid>, IEntityMapping
    {
        public TranslationMapping()
        {
            base.Property(e => e.Keyword);
            base.Property(e => e.Culture);
            base.Property(e => e.Value);
        }
    }
}
