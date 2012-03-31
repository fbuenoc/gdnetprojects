using WebFramework.Common.Framework.Base;

namespace WebFramework.Common.Controllers
{
    public abstract class AbstractController<TModel> : AbstractController
    {
        protected TModel GetModelById(string id)
        {
            return ModelService.GetModelById<TModel>(id);
        }
    }
}
