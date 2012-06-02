using System.Web.Mvc;

namespace WebFramework.Common.Controllers
{
    public abstract class AbstractListCrudController<TModel> : AbstractCrudController<TModel>
    {
        public virtual ActionResult Index()
        {
            return base.RedirectToAction(ActionList);
        }

        public abstract ActionResult List();
    }
}
