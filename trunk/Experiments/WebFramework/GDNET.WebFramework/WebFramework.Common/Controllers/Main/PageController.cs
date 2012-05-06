using System.Web.Mvc;
using GDNET.Web.Helpers;
using WebFramework.Common.Constants;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.System;
using WebFramework.Domain;

namespace WebFramework.Controllers.Main
{
    public class PageController : AbstractController
    {
        public ActionResult Index()
        {
            var pageUniqueName = QueryStringAssistant.GetValueAsString(QueryStringConstants.Page);
            var pageEntity = DomainRepositories.Page.GetByUniqueName(pageUniqueName);
            if (pageEntity != null)
            {
                var pageModel = new PageModel(pageEntity);
                return base.View(pageModel);
            }

            return base.View();
        }
    }
}
