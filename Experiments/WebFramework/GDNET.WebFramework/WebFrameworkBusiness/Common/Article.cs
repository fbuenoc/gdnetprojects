using System;
using GDNET.Common.Security.Services;
using GDNET.Common.Types;
using WebFrameworkBusiness.Base;

namespace WebFrameworkBusiness.Common
{
    public sealed partial class Article : BusinessEntityBase, IBusinessEntity
    {
        #region Properties

        public Contact Author
        {
            get { return this.GetValue<Contact>(() => this.Author); }
            set { this.SetValue<Contact>(() => this.Author, value); }
        }

        public Website SourceInfo
        {
            get { return this.GetValue<Website>(() => this.SourceInfo); }
            set { this.SetValue<Website>(() => this.SourceInfo, value); }
        }

        public DateTime PublishedDate
        {
            get { return this.GetValue<DateTime>(() => this.PublishedDate); }
            set { this.SetValue<DateTime>(() => this.PublishedDate, value); }
        }

        public string MainContent
        {
            get { return this.GetValue<string>(() => this.MainContent); }
            set { this.SetValue<string>(() => this.MainContent, value); }
        }

        #endregion

        protected Article()
            : base(EncryptionOption.Base64)
        {
        }
    }
}
