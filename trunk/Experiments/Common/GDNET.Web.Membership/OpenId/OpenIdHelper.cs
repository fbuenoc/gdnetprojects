using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;

using GDNET.Web.Membership.OpenId.Objects;

namespace GDNET.Web.Membership.OpenId
{
    public sealed class OpenIdHelper
    {
        /// <summary>
        /// Get authenticated information from OpenID provider
        /// </summary>
        /// <param name="openIdRelyingParty"></param>
        /// <param name="accountInfo"></param>
        /// <returns></returns>
        public static bool GetResponseInfo(out OpenIdRelyingParty openIdRelyingParty, out OpenIdAccountInfo accountInfo)
        {
            accountInfo = new OpenIdAccountInfo();
            openIdRelyingParty = new OpenIdRelyingParty();

            bool localResult = false;
            var response = openIdRelyingParty.GetResponse();

            if (response != null)
            {
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        // This is where you would look for any OpenID extension responses included
                        // in the authentication assertion.
                        ClaimsResponse claimsResponse = response.GetExtension<ClaimsResponse>();
                        if (claimsResponse != null)
                        {
                        }

                        FetchResponse fetchResponse = response.GetExtension<FetchResponse>();
                        bool parseResult = accountInfo.ParseInfo(fetchResponse);

                        // Store off the "friendly" username to display -- NOT for username lookup
                        accountInfo.FriendlyIdentifier = response.FriendlyIdentifierForDisplay;

                        // Use FormsAuthentication to tell ASP.NET that the user is now logged in,
                        // with the OpenID Claimed Identifier as their username.
                        accountInfo.ClaimedIdentifier = response.ClaimedIdentifier;

                        localResult = true;
                        break;

                    case AuthenticationStatus.Failed:
                        break;

                    case AuthenticationStatus.Canceled:
                        break;
                }
            }

            return localResult;
        }

        /// <summary>
        /// Redirect to provider page to let user signs in or query user information
        /// </summary>
        /// <param name="openIdRelyingParty"></param>
        /// <param name="suppliedIdentifier"></param>
        public static void RedirectToProvider(OpenIdRelyingParty openIdRelyingParty, string suppliedIdentifier)
        {
            IAuthenticationRequest request = openIdRelyingParty.CreateRequest(suppliedIdentifier);

            // This is where you would add any OpenID extensions you wanted
            // to include in the authentication request.
            var fetch = OpenIdHelper.GetFetchRequest(false);
            request.AddExtension(fetch);

            //request.AddExtension(new ClaimsRequest
            //{
            //    Nickname = DemandLevel.Require,
            //    Email = DemandLevel.Require,
            //    FullName = DemandLevel.Require,
            //    BirthDate = DemandLevel.Require,
            //    Gender = DemandLevel.Require,
            //    Country = DemandLevel.Request,
            //    PostalCode = DemandLevel.Request,
            //    TimeZone = DemandLevel.Request,
            //});
            request.RedirectToProvider();
        }

        public static FetchRequest GetFetchRequest(bool useDetails)
        {
            FetchRequest fetchRequest = new FetchRequest();
            fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
            fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.FullName);

            if (useDetails)
            {
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.BirthDate.DayOfMonth);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.BirthDate.Month);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.BirthDate.WholeBirthDate);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.BirthDate.Year);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.HomeAddress.City);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.HomeAddress.Country);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.HomeAddress.PostalCode);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.IM.AOL);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.IM.ICQ);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.IM.Jabber);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.IM.MSN);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.IM.Skype);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.IM.Yahoo);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Phone.Fax);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Phone.Home);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Phone.Mobile);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Phone.Work);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Web.Flickr);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Web.Homepage);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Contact.Web.LinkedIn);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Media.Images.Default);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.First);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.Last);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.Middle);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.Prefix);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Name.Suffix);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Person.Gender);
                fetchRequest.Attributes.AddRequired(WellKnownAttributes.Person.Biography);
            }

            return fetchRequest;
        }
    }
}
