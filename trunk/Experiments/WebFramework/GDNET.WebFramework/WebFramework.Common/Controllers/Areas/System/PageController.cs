using System.Linq;
using System.Web.Mvc;
using GDNET.Web.Mvc.Helpers;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Security;
using WebFramework.Domain;
using WebFramework.Domain.Common;
using WebFramework.Domain.System;

namespace WebFramework.Common.Controllers.Areas.System
{
    public class PageController : AbstractListCrudController<PageModel>, IRequiredAdministerController
    {
        public override ActionResult List()
        {
            var listOfPages = DomainRepositories.Page.GetAll().Select(page => new PageModel(page)).ToList();
            return base.View(listOfPages);
        }

        protected override object OnCreateExecuting(PageModel model, FormCollection collection)
        {
            Application app = null;
            var page = Page.Factory.Create(model.Name, model.UniqueName, app, app.CultureDefault);
            var result = DomainRepositories.Page.Save(page);
            return result ? (object)page.Id : null;
        }

        protected override bool OnDeleteExecuting(PageModel model, FormCollection collection)
        {
            long pageId = collection.GetItemId<long>();
            return DomainRepositories.Page.Delete(pageId);
        }

        protected override bool OnEditExecuting(PageModel model, FormCollection collection)
        {
            try
            {
                var pageEntity = DomainRepositories.Page.GetById(model.Id);
                pageEntity.Name = model.Name;
                pageEntity.Description = model.Description;
                pageEntity.Keyword = model.Keyword;

                return DomainRepositories.Page.Update(pageEntity);
            }
            catch
            {
                return false;
            }
        }
    }
}
