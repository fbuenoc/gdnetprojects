using System.Web.Mvc;
using GDNET.Web.Helpers;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.System;
using WebFramework.Constants;
using WebFramework.Domain;

namespace WebFramework.Controllers
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
