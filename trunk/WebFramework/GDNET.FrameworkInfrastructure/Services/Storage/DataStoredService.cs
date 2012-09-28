using System.Web;
using GDNET.Domain.Base.SessionManagement;

namespace GDNET.FrameworkInfrastructure.Services.Storage
{
    public sealed class DataStoredService
    {
        private static readonly string _userInfoKey = "myinfo";

        public UserCustomizedInformation GetSectionInfo()
        {
            if (HttpContext.Current.Request.Cookies[_userInfoKey] == null)
            {
                var language = DomainSessionContext.Instance.CurrentUser.Language.Code;
                UserCustomizedInformation sectionInfo = new UserCustomizedInformation(language, false);

                HttpCookie cookie = new HttpCookie(_userInfoKey, sectionInfo.Serialize());
                HttpContext.Current.Request.Cookies.Add(cookie);
            }

            UserCustomizedInformation info = new UserCustomizedInformation(HttpContext.Current.Request.Cookies[_userInfoKey].ToString());
            return info;
        }
    }
}
