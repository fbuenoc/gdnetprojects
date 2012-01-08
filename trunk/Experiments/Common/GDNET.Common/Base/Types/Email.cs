using System;
using GDNET.Common.Domain;

namespace GDNET.Common.Base.Types
{
    [Serializable]
    public class Email : ISrerializable
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

        public Email(string userName, string hostName)
        {
            this.UserName = userName;
            this.HostName = hostName;
        }

        public Email(string email)
            : this(email.Substring(0, email.IndexOf("@")), email.Substring(email.IndexOf("@") + 1))
        {
        }

        public string Serialize()
        {
            return string.Format("{0}@{1}", this.UserName, this.HostName);
        }
    }
}
