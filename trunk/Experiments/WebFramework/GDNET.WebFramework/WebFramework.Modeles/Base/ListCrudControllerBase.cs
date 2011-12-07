using System.Web.Mvc;

namespace WebFramework.Modeles.Base
{
    public abstract class ListCrudControllerBase<TModel> : CrudControllerBase<TModel>
    {
        public ActionResult Index()
        {
            return base.RedirectToAction(ActionList);
        }

        public abstract ActionResult List();
    }
}
