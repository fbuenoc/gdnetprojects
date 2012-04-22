using System.Web.Mvc;
using GDNET.Web.Helpers;
using GDNET.Web.Mvc.Adapters;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.System;
using WebFramework.Constants;
using WebFramework.Domain;
using WebFramework.Domain.System;

namespace WebFramework.Controllers
{
    public class PageController : AbstractController
    {
        private Page pageEntity = null;

        public ActionResult Index()
        {
            var pageUniqueName = QueryStringAssistant.GetValueAsString(QueryStringConstants.Page);
            var pageObject = DomainRepositories.Page.GetByUniqueName(pageUniqueName);
            if (pageObject != null)
            {
                var pageModel = new PageModel(pageObject);
                return base.View(pageModel);
            }

            return base.View();
        }

        public ActionResult Admin()
        {
            var pageModel = this.GetPageModel();
            if (pageModel != null)
            {
                return base.View(pageModel);
            }

            return base.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Admin(FormCollection collection)
        {
            var pageModel = this.GetPageModel();
            if (pageModel != null)
            {
                // Name, Keyword & Description
                var nameEditorAdapter = new TextBoxEditorAdapter("RG_Name", collection);
                this.pageEntity.Name = nameEditorAdapter.Value;

                var keywordEditorAdapter = new TextAreaEditorAdapter("RG_Keyword", collection);
                this.pageEntity.Keyword = keywordEditorAdapter.Value;

                var descriptionEditorAdapter = new TextAreaEditorAdapter("RG_Description", collection);
                this.pageEntity.Description = descriptionEditorAdapter.Value;

                pageModel = new PageModel(this.pageEntity);
            }

            return base.View(pageModel);
        }

        private PageModel GetPageModel()
        {
            var pageUniqueName = QueryStringAssistant.GetValueAsString(QueryStringConstants.Page);
            pageEntity = DomainRepositories.Page.GetByUniqueName(pageUniqueName);
            if (pageEntity != null)
            {
                return new PageModel(pageEntity);
            }

            return default(PageModel);
        }
    }
}
