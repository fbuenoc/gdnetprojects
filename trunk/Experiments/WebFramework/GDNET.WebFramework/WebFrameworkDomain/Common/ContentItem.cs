using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;
using WebFrameworkDomain.Base;
using WebFrameworkDomain.Extensions;

namespace WebFrameworkDomain.Common
{
    public partial class ContentItem : EntityWithModificationBase<long>, IEntityWithLifeCycle
    {
        private IList<ContentItemAttributeValue> attributeValues = new List<ContentItemAttributeValue>();
        private IList<ContentItem> relationItems = new List<ContentItem>();

        #region Properties

        public virtual ContentType ContentType
        {
            get;
            set;
        }

        public virtual Translation Name
        {
            get;
            set;
        }

        public virtual Translation Description
        {
            get;
            set;
        }

        public virtual int Position
        {
            get;
            set;
        }

        public virtual long Views
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<ContentItemAttributeValue> AttributeValues
        {
            get { return new ReadOnlyCollection<ContentItemAttributeValue>(this.attributeValues); }
        }

        public virtual ReadOnlyCollection<ContentItem> RelationItems
        {
            get { return new ReadOnlyCollection<ContentItem>(this.relationItems); }
        }

        #endregion

        #region Methods

        public virtual void AddAttributeValue(ContentItemAttributeValue attributeValue)
        {
            if (this.attributeValues.Contains(attributeValue))
            {
                attributeValue.ContentItem = this;
                this.attributeValues.Add(attributeValue);
            }
        }

        public virtual void RemoveAttributeValue(ContentItemAttributeValue attributeValue)
        {
            if (this.attributeValues.Contains(attributeValue))
            {
                this.attributeValues.Remove(attributeValue);
            }
        }

        public virtual void RemoveAllAttributeValues()
        {
            this.attributeValues.Clear();
        }

        public virtual void AddRelationItem(ContentItem item)
        {
            if (item == this)
            {
                ThrowException.InvalidOperationException("Can not add an item to be its sub items.");
            }

            if (!this.relationItems.Contains(item))
            {
                this.relationItems.Add(item);
            }
        }

        public virtual void RemoveRelationItem(ContentItem item)
        {
            if (this.relationItems.Contains(item))
            {
                this.relationItems.Remove(item);
            }
        }

        public virtual void RemoveRelationItems()
        {
            this.relationItems.Clear();
        }

        #endregion

        #region IEntityLifeCycle

        public virtual StatutLifeCycle LifeCycle
        {
            get;
            private set;
        }

        public void ApplyDefaultSettings()
        {
            EntityAssistant.ChangeActive(this, true);
            EntityAssistant.ChangeDeletable(this, true);
            EntityAssistant.ChangeEditable(this, true);
        }

        #endregion

        protected ContentItem()
        {
            this.LifeCycle = StatutLifeCycle.Factory.Create();
            this.ApplyDefaultSettings();
        }

    }
}
