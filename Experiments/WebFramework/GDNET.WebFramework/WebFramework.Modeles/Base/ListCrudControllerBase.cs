using System.Web.Mvc;
using GDNET.Web.Mvc.Base;

namespace WebFramework.Modeles.Base
{
    public abstract class ListCrudControllerBase<TModel> : CrudControllerBase<TModel> where TModel : ModelBase
    {
        public const string ActionList = "List";

        public ActionResult Index()
        {
            return base.RedirectToAction("List");
        }

        public abstract ActionResult List();
    }
}
