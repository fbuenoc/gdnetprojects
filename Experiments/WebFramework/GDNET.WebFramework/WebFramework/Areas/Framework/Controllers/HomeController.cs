﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebFramework.Business.Administration;
using WebFramework.Business.Helpers;
using WebFramework.Common.Business.Administration;
using WebFramework.Common.Controllers;
using WebFramework.Common.Security;

namespace WebFramework.Areas.Framework.Controllers
{
    public class HomeController : AbstractController, IRequiredAdministerController
    {
        public ActionResult Index()
        {
            IList<Shortcut> listeShortcuts = BusinessEntityAssistant.GetAllByType<Shortcut>();
            List<ShortcutModel> listeShortcutsModel = listeShortcuts.Select(x => new ShortcutModel(x)).ToList();

            return View(listeShortcutsModel);
        }
    }
}
