using System;

using GDNET.Common.Security.Services;
using WebFrameworkBusiness.Base;

namespace WebFrameworkBusiness
{
    public sealed class Comment : ContentItemBase
    {
        private const string PropertyTitle = "Title";
        private const string PropertyBody = "Body";
        private const string PropertyVerified = "Verified";
        private const string PropertyFullName = "FullName";
        private const string PropertyEmail = "Email";

        public string Title
        {
            get { return base.GetValue<string>(PropertyTitle); }
            set { base.SetValue(PropertyTitle, value); }
        }

        public string Body
        {
            get { return base.GetValue<string>(PropertyBody); }
            set { base.SetValue(PropertyBody, value); }
        }

        public string FullName
        {
            get { return base.GetValue<string>(PropertyFullName); }
            set { base.SetValue(PropertyFullName, value); }
        }

        public string Email
        {
            get { return base.GetValue<string>(PropertyEmail); }
            set { base.SetValue(PropertyEmail, value); }
        }

        public Comment()
            : this(null, null)
        {
        }

        public Comment(string title, string body)
            : base("N", "D")
        {
            base.RegisterProperty(PropertyTitle, typeof(string));
            base.RegisterProperty(PropertyBody, typeof(string));
            base.RegisterProperty(PropertyFullName, typeof(string));
            base.RegisterProperty(PropertyEmail, typeof(DateTime));

            this.Title = title;
            this.Body = body;
        }
    }
}
