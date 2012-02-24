using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Common.Base.Entities;
using WebFrameworkDomain.Base;
using WebFrameworkDomain.Extensions;

namespace WebFrameworkDomain.Common
{
    public partial class ContentAttribute : EntityWithModificationBase<long>, IEntityWithLifeCycle
    {
        private IList<ContentItem> contentItems = new List<ContentItem>();
        private IList<ContentItemAttributeValue> attributeValues = new List<ContentItemAttributeValue>();

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

        public virtual ReadOnlyCollection<ContentItemAttributeValue> AttributeValues
        {
            get { return new ReadOnlyCollection<ContentItemAttributeValue>(this.attributeValues); }
        }

        #endregion

        #region IEntityLifeCycle

        public virtual StatutLifeCycle LifeCycle
        {
            get;
            protected internal set;
        }

        public virtual void ApplyDefaultSettings()
        {
            EntityAssistant.ChangeActive(this, true);
            EntityAssistant.ChangeDeletable(this, true);
            EntityAssistant.ChangeEditable(this, true);
        }

        #endregion

        protected ContentAttribute()
        {
            this.LifeCycle = StatutLifeCycle.Factory.Create();
            this.ApplyDefaultSettings();
        }
    }
}
