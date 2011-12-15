using System;

using GDNET.Common.Security.Services;
using WebFrameworkBusiness.Base;

namespace WebFrameworkBusiness
{
    public sealed class Article : ContentItemBase
    {
        private const string PropertySourceName = "SourceName";
        private const string PropertySourceUrl = "SourceUrl";
        private const string PropertyPublishedDate = "PublishedDate";

        #region Properties

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
            : base(EncryptionOption.Base64)
        {
            base.RegisterProperty(PropertySourceName, typeof(string));
            base.RegisterProperty(PropertySourceUrl, typeof(string));
            base.RegisterProperty(PropertyPublishedDate, typeof(DateTime));
        }

    }
}
