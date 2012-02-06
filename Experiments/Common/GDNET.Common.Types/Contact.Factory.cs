using System;
using System.Collections.Generic;

namespace GDNET.Common.Types
{
    public partial class Contact
    {
        public static ContactFactory Factory
        {
            get { return new ContactFactory(); }
        }

        public class ContactFactory
        {
            public Contact Create()
            {
                return new Contact { };
            }

            public Contact Create(Name name, IList<Email> emails, IList<string> phoneNumbers)
            {
                Contact contact = this.Create();
                contact.ContactName = name;
                contact.AddEmails(emails);
                contact.AddPhoneNumbers(phoneNumbers);

                return contact;
            }
        }
    }
}
