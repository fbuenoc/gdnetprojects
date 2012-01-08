using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Common.Domain;
using GDNET.Common.DesignByContract;

namespace GDNET.Common.Base.Types
{
    [Serializable]
    public class Contact : ISrerializable
    {
        private const string PropertyContactName = "1efb240c-1044-42c3-a918-7cb349e660b6";
        private const string PropertyEmails = "95394fc8-1deb-4da0-8d39-6664bc932497";
        private const string PropertyPhoneNumbers = "57f8a2bc-8efe-47ff-8e76-a9f4d377aa86";

        public Name ContactName
        {
            get;
            set;
        }

        public IList<Email> Emails
        {
            get;
            set;
        }

        public IList<string> PhoneNumbers
        {
            get;
            set;
        }

        public Contact(string contact)
        {
            foreach (var propertyValues in contact.Split(';'))
            {
                if (string.IsNullOrEmpty(propertyValues))
                {
                    continue;
                }

                var pValues = propertyValues.Split(':');
                switch (pValues[0])
                {
                    case PropertyContactName:
                        this.ContactName = new Name(pValues[1]);
                        break;

                    case PropertyEmails:
                        this.Emails = pValues[1].Split(',').Select(e => new Email(e)).ToList();
                        break;

                    case PropertyPhoneNumbers:
                        this.PhoneNumbers = pValues[1].Split(',');
                        break;

                    default:
                        ThrowException.NotImplementedException(string.Format("Property {0} is not handled", pValues[0]));
                        break;
                }
            }
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}:{1};", PropertyContactName, this.ContactName);
            sb.AppendFormat("{0}:{1};", PropertyEmails, string.Join(",", this.Emails.Select(x => x.Serialize()).ToArray()));
            sb.AppendFormat("{0}:{1};", PropertyPhoneNumbers, string.Join(",", this.PhoneNumbers.ToArray()));

            return sb.ToString();
        }
    }
}
