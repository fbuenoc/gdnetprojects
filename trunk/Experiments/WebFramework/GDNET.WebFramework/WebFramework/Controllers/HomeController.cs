using System.Linq;
using System.Web.Mvc;
using WebFramework.Base.Framework.Common;
using WebFramework.Business.Common;
using WebFramework.Business.Helpers;
using WebFramework.Common.Controllers;
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

            var listeProducts = BusinessEntityAssistant.GetAllByType<Product>();
            var listeProductsModel = listeProducts.Select(x => new ContentItemModel(x)).ToList();
            var viewModel = new HomeViewModel
            {
                Products = listeProductsModel,
            };

            return base.View(viewModel);
        }
    }
}
