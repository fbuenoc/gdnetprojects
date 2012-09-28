using System.Web;
using GDNET.Domain.Base.SessionManagement;
using GDNET.FrameworkInfrastructure.Common;
using GDNET.FrameworkInfrastructure.Models.System;

namespace GDNET.FrameworkInfrastructure.Services.Storage
{
    public sealed class DataStoredService
    {
        public UserCustomizedInformationModel GetUserCustomizedInfo()
        {
            if (HttpContext.Current.Request.Cookies[FrameworkConstants.UserInfoKey] == null)
            {
                var language = DomainSessionContext.Instance.CurrentUser.Language.Code;
                UserCustomizedInformationModel userCustomized = new UserCustomizedInformationModel(language, false);

                this.SetUserCustomizedInfo(userCustomized);
            }

            var userInfo = HttpContext.Current.Request.Cookies[FrameworkConstants.UserInfoKey];
            UserCustomizedInformationModel info = new UserCustomizedInformationModel(userInfo.Value);

            return info;
        }

        public void SetUserCustomizedInfo(UserCustomizedInformationModel model)
        {
            HttpContext.Current.Request.Cookies.Remove(FrameworkConstants.UserInfoKey);

            HttpCookie cookie = new HttpCookie(FrameworkConstants.UserInfoKey, model.Serialize());
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
