using System;
using System.Web.Mvc;
using System.Web.Routing;
using GDNET.Web.Helpers;
using GDNET.Web.Mvc.Adapters;
using WebFramework.Common.Constants;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Security;
using WebFramework.Domain;
using WebFramework.Domain.System;

namespace WebFramework.Widgets.Daskboard.Controllers
{
    public class PageAdminController : AbstractController<PageModel>, IRequiredManagerController
    {
        public const string ActionEdit = "Edit";

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        public ActionResult Index()
        {
            var objet = new
            {
                page = QueryStringAssistant.GetValueAsString(QueryStringConstants.Page)
            };

            return base.RedirectToAction("Edit", objet);
        }

        public ActionResult Edit()
        {
            var pageEntity = this.GetSelectionPage();

            if (pageEntity == null)
            {
                throw new Exception();
            }
            else
            {
                var pageModel = new PageModel(pageEntity);
                return base.View(pageModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            var pageEntity = this.GetSelectionPage();
            PageModel pageModel = null;

            if (pageEntity == null)
            {
                throw new Exception();
            }
            else
            {
                // Name, Keyword & Description
                var nameEditorAdapter = new TextBoxEditorAdapter("RG_Name", collection);
                pageEntity.Name = nameEditorAdapter.Value;

                var keywordEditorAdapter = new TextAreaEditorAdapter("RG_Keyword", collection);
                pageEntity.Keyword = keywordEditorAdapter.Value;

                var descriptionEditorAdapter = new TextAreaEditorAdapter("RG_Description", collection);
                pageEntity.Description = descriptionEditorAdapter.Value;

                pageModel = new PageModel(pageEntity);
            }

            return base.View(pageModel);
        }

        private Page GetSelectionPage()
        {
            string pageName = string.Empty;
            Page pageEntity = null;

            if (QueryStringAssistant.GetValueAsString(QueryStringConstants.Page, out pageName))
            {
                pageEntity = DomainRepositories.Page.GetByUniqueName(pageName);
            }

            return pageEntity;
        }
    }
}
