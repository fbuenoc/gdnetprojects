using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebFramework.Business.Administration;
using WebFramework.Business.Helpers;
using WebFramework.Common.Business.Administration;
using WebFramework.Common.Controllers;
using WebFramework.Common.Security;

namespace WebFramework.Common.Controllers.Areas.Framework
{
    public class HomeController : AbstractController, IRequiredAdministratorController
    {
        public ActionResult Index()
        {
            IList<Shortcut> listeShortcuts = BusinessEntityAssistant.GetAllByType<Shortcut>();
            List<ShortcutModel> listeShortcutsModel = listeShortcuts.Select(x => new ShortcutModel(x)).ToList();

            return View(listeShortcutsModel);
        }
    }
}
