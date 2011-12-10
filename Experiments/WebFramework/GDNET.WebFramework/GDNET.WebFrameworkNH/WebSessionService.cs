﻿using System.Security.Principal;
using System.Web;

using GDNET.Common.Base;
using GDNET.Common.Security;

namespace WebFrameworkNHibernate
{
    public class WebSessionService : SessionService
    {
        private static readonly WebSessionService _instance = new WebSessionService();

        public WebSessionService()
            : base(_instance)
        {
            base.User = (HttpContext.Current.User == null) ? new FakePrincipal() : HttpContext.Current.User;
            base.IsAuthenticated = (HttpContext.Current.User != null);
        }
    }
}