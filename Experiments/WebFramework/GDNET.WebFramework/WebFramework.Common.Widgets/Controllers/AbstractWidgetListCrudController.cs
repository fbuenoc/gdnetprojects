using System.Web.Routing;
using WebFramework.Common.Controllers;

namespace WebFramework.Common.Widgets.Controllers
{
    public abstract class AbstractWidgetListCrudController<TModel> : AbstractListCrudController<TModel>
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
    }
}
