using System.Collections.Generic;
using System.Collections.ObjectModel;

using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class ContentAttribute : EntityFullControlBase<long>
    {
        private IList<ContentItem> contentItems = new List<ContentItem>();

        #region Properties

        public virtual ContentType ContentType
        {
            get;
            set;
        }

        public virtual ListValue DataType
        {
            get;
            set;
        }

        public virtual string Code
        {
            get;
            set;
        }

        public virtual int Position
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<ContentItem> ContentItems
        {
            get { return new ReadOnlyCollection<ContentItem>(this.contentItems); }
        }

        #endregion

        protected ContentAttribute() { }
    }
}
