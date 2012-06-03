using System;
using GDNET.Web.Helpers;
using WebFramework.Domain.System;

namespace WebFramework.Widgets.Daskboard.Helpers
{
    public static class DaskboardAssistant
    {
        public static string GetUrlByPage(Page targetPage)
        {
            if (targetPage == null)
            {
                throw new Exception();
            }
            else
            {
                return string.Format("{0}/Daskboard?page={1}", WebAssistant.GetCurrentDomain(), targetPage.UniqueName);
            }
        }
    }
}