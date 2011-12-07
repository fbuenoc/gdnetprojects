using System;
using System.Web;

using GDNET.Common.Base;
using GDNET.Common.Base.Services;

namespace WebFrameworkNHibernate
{
    /// <summary>
    /// NHibernate session management module interceptor, use to check which request is needed to open/close NHibernate session
    /// </summary>
    public sealed class NHibernateSessionModuleInterceptor : IInterceptorService
    {
        #region IInterceptor Members

        public bool IsPassed()
        {
            switch (HttpContext.Current.Request.CurrentExecutionFilePathExtension)
            {
                case ".aspx":
                    return true;
            }

            return false;
        }

        #endregion
    }
}
