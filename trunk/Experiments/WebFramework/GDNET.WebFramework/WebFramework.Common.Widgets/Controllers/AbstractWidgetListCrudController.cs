using System.Web.Routing;
using WebFramework.Common.Controllers;
using WebFramework.Domain.System;

namespace WebFramework.Common.Widgets.Controllers
{
    public abstract class AbstractWidgetListCrudController<TModel> : AbstractListCrudController<TModel>
    {
        protected Widget currentWidget = null;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
    }
}
