using System;
using GDNET.Common.Security.Services;
using GDNET.Common.Types;
using WebFrameworkBusiness.Base;

namespace WebFrameworkBusiness
{
    public sealed class Article : BusinessItemBase
    {
        #region Properties

        public Contact Author
        {
            get { return this.GetValue<Contact>(() => this.Author); }
            set { this.SetValue<Contact>(() => this.Author, value); }
        }

        public string SourceName
        {
            get { return this.GetValue<string>(() => this.SourceName); }
            set { this.SetValue<string>(() => this.SourceName, value); }
        }

        public string SourceUrl
        {
            get { return this.GetValue<string>(() => this.SourceUrl); }
            set { this.SetValue<string>(() => this.SourceUrl, value); }
        }

        public DateTime PublishedDate
        {
            get { return this.GetValue<DateTime>(() => this.PublishedDate); }
            set { this.SetValue<DateTime>(() => this.PublishedDate, value); }
        }

        #endregion

        public Article()
            : base(EncryptionOption.Base64)
        {
        }

    }
}
