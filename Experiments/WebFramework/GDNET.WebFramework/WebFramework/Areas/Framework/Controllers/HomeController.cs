using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebFramework.Base.Business.Administration;
using WebFramework.Business.Administration;
using WebFramework.Business.Helpers;
using WebFramework.Common.Controllers;

namespace WebFramework.Areas.Framework.Controllers
{
    public class HomeController : AbstractController
    {
        public ActionResult Index()
        {
            IList<Shortcut> listeShortcuts = BusinessEntityAssistant.GetByType<Shortcut>();
            List<ShortcutModel> listeShortcutsModel = listeShortcuts.Select(x => new ShortcutModel(x)).ToList();

            return View(listeShortcutsModel);
        }

    }
}
