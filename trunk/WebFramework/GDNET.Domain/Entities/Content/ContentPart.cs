﻿using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Content
{
    public partial class ContentPart : EntityHistoryComplex
    {
        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Details
        {
            get;
            set;
        }

        public virtual ContentItem ContentItem
        {
            get;
            set;
        }
    }
}