using System;
using GDNET.Common.Domain;

namespace GDNET.Common.Types
{
    public class Email : IObjectSerialization
    {
        public string HostName
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public Email(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                this.UserName = email.Substring(0, email.IndexOf("@"));
                this.HostName = email.Substring(email.IndexOf("@") + 1);
            }
        }

        public Email(string userName, string hostName)
        {
            this.UserName = userName;
            this.HostName = hostName;
        }

        public string Serialize()
        {
            return string.Format("{0}@{1}", this.UserName, this.HostName);
        }
    }
}
