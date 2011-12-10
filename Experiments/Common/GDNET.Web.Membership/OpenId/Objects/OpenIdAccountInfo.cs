using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;

namespace GDNET.Web.Membership.OpenId.Objects
{
    public partial class OpenIdAccountInfo
    {
        public bool ParseInfo(FetchResponse fetch)
        {
            bool localResult = false;

            if ((fetch != null) && (fetch.Attributes != null))
            {
                if (fetch.Attributes.Contains(WellKnownAttributes.Contact.Email))
                {
                    this.EmailAddress = fetch.Attributes[WellKnownAttributes.Contact.Email].Values[0];
                }
                if (fetch.Attributes.Contains(WellKnownAttributes.Name.FullName))
                {
                    this.FullName = fetch.Attributes[WellKnownAttributes.Name.FullName].Values[0];
                }
            }

            return localResult;
        }
    }
}
