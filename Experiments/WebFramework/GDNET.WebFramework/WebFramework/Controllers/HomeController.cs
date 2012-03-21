using System.Linq;
using System.Web.Mvc;
using WebFramework.Base.Framework.Common;
using WebFramework.Business.Common;
using WebFramework.Common.Controllers;
using WebFramework.Domain;
using WebFramework.ViewModels;

namespace WebFramework.Controllers
{
    public class HomeController : AbstractController
    {
        public ActionResult Index()
        {
            return base.RedirectToAction("Welcome");
        }

        public ActionResult Welcome()
        {
            base.ViewBag.Message = "Welcome to ASP.NET MVC!";

            var listeProducts = DomainRepositories.ContentItem.GetByContentType(typeof(Product));
            var listeArticles = DomainRepositories.ContentItem.GetByContentType(typeof(Article));

            var viewModel = new HomeViewModel
            {
                Products = listeProducts.Select(x => new ContentItemModel(x)).ToList(),
                Articles = listeArticles.Select(x => new ContentItemModel(x)).ToList()
            };

            return base.View(viewModel);
        }
    }
}
