using System.Web.Mvc;
using GDNET.Domain.Content;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Common;
using GDNET.Utils;

namespace GDNET.FrameworkInfrastructure.Controllers
{
    public class HomeController : AbstractController
    {
        private const int PAGE_SIZE = 10;

        public ActionResult Index()
        {
            var defaultContentItem = default(ContentItem);
            var propertyCreatedAt = ExpressionAssistant.GetPropertyName(() => defaultContentItem.CreatedAt);
            var listeContentItems = DomainRepositories.ContentItem.GetTopByProperty(PAGE_SIZE, propertyCreatedAt);

            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
