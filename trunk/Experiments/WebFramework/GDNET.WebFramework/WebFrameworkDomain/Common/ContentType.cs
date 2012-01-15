using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using GDNET.Common.Base.Entities;
using WebFrameworkDomain.Extensions;

namespace WebFrameworkDomain.Common
{
    public partial class ContentType : EntityWithFullInfoBase<long>
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

        protected ContentType() { }

    }
}
