using System;

using GDNET.Common.Base.Types;
using GDNET.Common.Security.Services;
using WebFrameworkBusiness.Base;

namespace WebFrameworkBusiness
{
    public sealed class Article : ContentItemBase
    {
        private const string PropertyAuthor = "Author";
        private const string PropertyPublishedDate = "PublishedDate";
        private const string PropertySourceName = "SourceName";
        private const string PropertySourceUrl = "SourceUrl";

        #region Properties

        public Contact Author
        {
            get { return this.GetValue<Contact>(PropertyAuthor); }
            set { this.SetValue<Contact>(PropertyAuthor, value); }
        }

        public string SourceName
        {
            get { return this.GetValue<string>(PropertySourceName); }
            set { this.SetValue<string>(PropertySourceName, value); }
        }

        public string SourceUrl
        {
            get { return this.GetValue<string>(PropertySourceUrl); }
            set { this.SetValue<string>(PropertySourceUrl, value); }
        }

        public DateTime PublishedDate
        {
            get { return this.GetValue<DateTime>(PropertyPublishedDate); }
            set { this.SetValue<DateTime>(PropertyPublishedDate, value); }
        }

        #endregion

        public Article()
            : base("N", "D", EncryptionOption.Base64)
        {
            base.RegisterProperty(PropertyAuthor, typeof(Contact));
            base.RegisterProperty(PropertySourceName, typeof(string));
            base.RegisterProperty(PropertySourceUrl, typeof(string));
            base.RegisterProperty(PropertyPublishedDate, typeof(DateTime));
        }

    }
}
