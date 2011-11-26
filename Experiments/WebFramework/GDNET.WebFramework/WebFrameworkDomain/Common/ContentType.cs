using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class ContentType : EntityFullControlBase<long>
    {
        private IList<ContentItem> contentItems = new List<ContentItem>();
        private IList<ContentAttribute> contentAttributes = new List<ContentAttribute>();

        #region Properties

        public virtual Translation Name
        {
            get;
            set;
        }

        public virtual string TypeName
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<ContentItem> ContentItems
        {
            get { return new ReadOnlyCollection<ContentItem>(this.contentItems); }
        }

        public virtual ReadOnlyCollection<ContentAttribute> ContentAttributes
        {
            get { return new ReadOnlyCollection<ContentAttribute>(this.contentAttributes); }
        }

        #endregion

        protected ContentType() { }
    }
}
