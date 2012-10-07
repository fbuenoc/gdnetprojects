using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using GDNET.Domain.Base;
using GDNET.FrameworkInfrastructure.Common.Base;

namespace GDNET.FrameworkInfrastructure.Common.Extensions
{
    public static class FrameworkExtensions
    {
        public static IList<TModel> ConvertAll<TModel, TEntity>(IList<TEntity> listEntities, bool filterActiveOnly)
            where TModel : AbstractViewModel<TEntity>
            where TEntity : IEntity
        {
            IList<TModel> listModels = new List<TModel>();

            foreach (var anEntity in listEntities)
            {
                TModel model = Activator.CreateInstance<TModel>();
                model.Initialize(anEntity, filterActiveOnly);

                if (!filterActiveOnly || ((anEntity is IEntityWithModificationHistory) && ((IEntityWithModificationHistory)anEntity).IsActive))
                {
                    listModels.Add(model);
                }
            }

            return listModels;
        }

        public static IList<TModel> ConvertAll<TModel, TEntity>(IList<TEntity> listEntities)
            where TModel : AbstractViewModel<TEntity>
            where TEntity : IEntity
        {
            return FrameworkExtensions.ConvertAll<TModel, TEntity>(listEntities, false);
        }

        public static string GetLanguageRoute(this HtmlHelper htmlHelper)
        {
            return HttpContext.Current.Request.RequestContext.RouteData.Values[FrameworkConstants.LanguageRouteKey].ToString();
        }
    }
}
