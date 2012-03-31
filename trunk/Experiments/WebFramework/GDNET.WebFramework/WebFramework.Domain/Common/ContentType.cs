using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Common.Base.Entities;
using WebFramework.Domain.Base;
using WebFramework.Domain.Extensions;

namespace WebFramework.Domain.Common
{
    public partial class ContentType : EntityWithModification<long>, IEntityWithLifeCycle
    {
        private IList<ContentItem> contentItems = new List<ContentItem>();
        private IList<ContentAttribute> contentAttributes = new List<ContentAttribute>();

        #region Properties

        public virtual Translation Name
        {
            get;
            set;
        }

        public virtual Application Application
        {
            get;
            set;
        }

        public virtual string Code
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

        #region Methods

        public virtual void AddContentAttribute(ContentAttribute attribute)
        {
            if (this.ContentAttributes.Contains(attribute))
            {
                return;
            }

            attribute.ContentType = this;
            this.contentAttributes.Add(attribute);
        }

        public virtual void AddContentAttributes(IList<ContentAttribute> listOfAttributes)
        {
            foreach (var attribute in listOfAttributes)
            {
                this.AddContentAttribute(attribute);
            }
        }

        public virtual void AddContentAttributes(params ContentAttribute[] arrayOfAttributes)
        {
            foreach (var attribute in arrayOfAttributes)
            {
                this.AddContentAttribute(attribute);
            }
        }

        public virtual void RemoveContentAttribute(ContentAttribute attribute)
        {
            if (this.ContentAttributes.Contains(attribute))
            {
                this.contentAttributes.Remove(attribute);
            }
        }

        public virtual void RemoveContentAttributes(params ContentAttribute[] arrayOfAttributes)
        {
            foreach (var attribute in arrayOfAttributes)
            {
                this.RemoveContentAttribute(attribute);
            }
        }

        public virtual void RemoveAllContentAttribute(ContentAttribute attribute)
        {
            this.contentAttributes.Clear();
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
            EntityAssistant.ChangeEditable(this, true);
            EntityAssistant.ChangeDeletable(this, true);
        }

        #endregion

        protected ContentType()
        {
            this.LifeCycle = StatutLifeCycle.Factory.Create();
            this.ApplyDefaultSettings();
        }

    }
}
