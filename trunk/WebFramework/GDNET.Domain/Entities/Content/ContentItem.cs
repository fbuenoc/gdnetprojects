using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GDNET.Domain.Base.Management;

namespace GDNET.Domain.Content
{
    public partial class ContentItem : EntityHistoryComplex
    {
        private IList<ContentPart> parts = new List<ContentPart>();

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Description
        {
            get;
            set;
        }

        public virtual string Keywords
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<ContentPart> Parts
        {
            get { return new ReadOnlyCollection<ContentPart>(this.parts); }
        }

        public virtual ContentPart GetPart(Guid partId)
        {
            return this.parts.FirstOrDefault(x => x.Id == partId);
        }

        public virtual ContentItem AddPart(ContentPart part)
        {
            if (!this.parts.Contains(part))
            {
                part.ContentItem = this;
                this.parts.Add(part);
            }

            return this;
        }

        public virtual ContentItem RemovePart(ContentPart part)
        {
            if (this.parts.Contains(part))
            {
                this.parts.Remove(part);
            }

            return this;
        }
    }
}
