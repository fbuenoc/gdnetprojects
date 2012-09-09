using System;
using System.Collections.Generic;
using GDNET.Domain.Base;

namespace GDNET.FrameworkInfrastructure.Common.Extensions
{
    public static class FrameworkExtensions
    {
        public static IList<TModel> ConvertAll<TModel, TEntity>(IList<TEntity> listEntities)
            where TModel : AbstractModel<TEntity>
            where TEntity : IEntity
        {
            List<TModel> listModels = new List<TModel>();

            if (listEntities != null)
            {
                foreach (var entity in listEntities)
                {
                    TModel model = Activator.CreateInstance<TModel>();
                    model.Initialize(entity);

                    listModels.Add(model);
                }
            }

            return listModels;
        }
    }
}
