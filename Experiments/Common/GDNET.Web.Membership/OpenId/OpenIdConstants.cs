using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;

namespace GDNET.Web.Membership.OpenId
{
    public sealed class OpenIdConstants
    {
        public const string SESSION_ACCOUNT_INFO = "SessionOpenIdAccountInfo";
        public const string GOOGLE = "google";
        public const string GOOGLE_IDENTIFIER = "https://www.google.com/accounts/o8/id";
        public const string YAHOO = "yahoo";
        public const string YAHOO_IDENTIFIER = "https://me.yahoo.com";
        public const string MYOPENID = "myopenid";
        public const string MYOPENID_IDENTIFIER = "http://myopenid.com";
    }
}
