using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDNET.Common.DesignByContract;
using GDNET.Common.Domain;
using GDNET.Common.Utils;
using GDNET.Extensions;

namespace GDNET.Common.Types
{
    [Serializable]
    public class Contact : ISerializable
    {
        public Name ContactName
        {
            get;
            set;
        }

        public IList<Email> Emails
        {
            get;
            private set;
        }

        public IList<string> PhoneNumbers
        {
            get;
            private set;
        }

        #region Ctors

        public Contact()
        {
            this.Initialize();
        }

        public Contact(string serializedContact)
        {
            this.Initialize();

            foreach (var propertyValues in serializedContact.Split(';'))
            {
                if (string.IsNullOrEmpty(propertyValues))
                {
                    continue;
                }

                var pValues = propertyValues.Split(':');
                if (pValues[0] == ExpressionUtil.GetPropertyName(() => this.ContactName))
                {
                    this.ContactName = new Name(Base64String.Decrypt(pValues[1]));
                }
                else if (pValues[0] == ExpressionUtil.GetPropertyName(() => this.Emails))
                {
                    this.Emails = Base64String.Decrypt(pValues[1]).Split(',').Select(em => new Email(em)).ToList();
                }
                else if (pValues[0] == ExpressionUtil.GetPropertyName(() => this.PhoneNumbers))
                {
                    this.PhoneNumbers = Base64String.Decrypt(pValues[1]).Split(',');
                }
                else
                {
                    ThrowException.NotImplementedException(string.Format("Property {0} is not handled.", pValues[0]));
                }
            }
        }

        private void Initialize()
        {
            this.Emails = new List<Email>();
            this.PhoneNumbers = new List<string>();
        }

        #endregion

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder();

            string contactName = Base64String.Encrypt(this.ContactName.Serialize());
            sb.AppendFormat("{0}:{1};", ExpressionUtil.GetPropertyName(() => this.ContactName), contactName);

            if (this.Emails.Count > 0)
            {
                string emails = Base64String.Encrypt(string.Join(",", this.Emails.Select(x => x.Serialize()).ToArray()));
                sb.AppendFormat("{0}:{1};", ExpressionUtil.GetPropertyName(() => this.Emails), emails);
            }

            if (this.PhoneNumbers.Count > 0)
            {
                string phoneNumbers = Base64String.Encrypt(string.Join(",", this.PhoneNumbers.ToArray()));
                sb.AppendFormat("{0}:{1};", ExpressionUtil.GetPropertyName(() => this.PhoneNumbers), phoneNumbers);
            }

            return sb.ToString();
        }
    }
}
