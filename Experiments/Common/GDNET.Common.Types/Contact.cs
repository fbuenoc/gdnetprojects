using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GDNET.Common.DesignByContract;
using GDNET.Common.Domain;
using GDNET.Common.Helpers;
using GDNET.Extensions;

namespace GDNET.Common.Types
{
    [Serializable]
    public partial class Contact : ISerializable
    {
        private List<Email> emails = new List<Email>();
        private List<string> phoneNumbers = new List<string>();

        public Name ContactName
        {
            get;
            set;
        }

        public ReadOnlyCollection<Email> Emails
        {
            get { return new ReadOnlyCollection<Email>(this.emails); }
        }

        public ReadOnlyCollection<string> PhoneNumbers
        {
            get { return new ReadOnlyCollection<string>(this.phoneNumbers); }
        }

        #region Ctors

        public Contact()
        {
        }

        public Contact(string serializedContact)
        {
            foreach (var propertyValues in serializedContact.Split(';'))
            {
                if (string.IsNullOrEmpty(propertyValues))
                {
                    continue;
                }

                var pValues = propertyValues.Split(':');
                if (pValues[0] == ExpressionAssistant.GetPropertyName(() => this.ContactName))
                {
                    this.ContactName = new Name(Base64Assistant.Decrypt(pValues[1]));
                }
                else if (pValues[0] == ExpressionAssistant.GetPropertyName(() => this.Emails))
                {
                    this.AddEmails(Base64Assistant.Decrypt(pValues[1]).Split(',').Select(em => new Email(em)).ToList());
                }
                else if (pValues[0] == ExpressionAssistant.GetPropertyName(() => this.PhoneNumbers))
                {
                    this.AddPhoneNumbers(Base64Assistant.Decrypt(pValues[1]).Split(',').ToList());
                }
                else
                {
                    ThrowException.NotImplementedException(string.Format("Property {0} is not handled.", pValues[0]));
                }
            }
        }

        #endregion

        #region Emails

        public void AddEmail(Email em)
        {
            if (!this.Emails.Contains(em))
            {
                this.emails.Add(em);
            }
        }

        public void AddEmails(IList<Email> emails)
        {
            foreach (Email em in emails)
            {
                this.AddEmail(em);
            }
        }

        public void DeleteEmail(Email em)
        {
            if (this.Emails.Contains(em))
            {
                this.emails.Remove(em);
            }
        }

        public void DeleteEmails()
        {
            this.emails.Clear();
        }

        #endregion

        #region PhoneNumbers

        public void AddPhoneNumber(string pn)
        {
            if (!this.PhoneNumbers.Contains(pn))
            {
                this.phoneNumbers.Add(pn);
            }
        }

        public void AddPhoneNumbers(IList<string> phoneNumbers)
        {
            foreach (string pn in phoneNumbers)
            {
                this.AddPhoneNumber(pn);
            }
        }

        public void DeletePhoneNumber(string pn)
        {
            if (this.PhoneNumbers.Contains(pn))
            {
                this.phoneNumbers.Remove(pn);
            }
        }

        public void DeletePhoneNumbers()
        {
            this.phoneNumbers.Clear();
        }

        #endregion

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder();

            string contactName = Base64Assistant.Encrypt(this.ContactName.Serialize());
            sb.AppendFormat("{0}:{1};", ExpressionAssistant.GetPropertyName(() => this.ContactName), contactName);

            if (this.Emails.Count > 0)
            {
                string emails = Base64Assistant.Encrypt(string.Join(",", this.Emails.Select(x => x.Serialize()).ToArray()));
                sb.AppendFormat("{0}:{1};", ExpressionAssistant.GetPropertyName(() => this.Emails), emails);
            }

            if (this.PhoneNumbers.Count > 0)
            {
                string phoneNumbers = Base64Assistant.Encrypt(string.Join(",", this.PhoneNumbers.ToArray()));
                sb.AppendFormat("{0}:{1};", ExpressionAssistant.GetPropertyName(() => this.PhoneNumbers), phoneNumbers);
            }

            return sb.ToString();
        }
    }
}
