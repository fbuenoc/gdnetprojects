using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GDNET.Base;
using GDNET.Domain.Entities.System;

namespace GDNET.Mapping.Common
{
    public static class MappingAssistant
    {
        private static readonly User DefaultUser = default(User);

        public static string GetForeignKeyColumn<T>(Expression<Func<T>> property)
        {
            string propertyId = ExpressionAssistant.GetPropertyName(() => DefaultUser.Id);
            string propertyName = ExpressionAssistant.GetPropertyName(property);
            return (propertyName + propertyId);
        }

        public static string GetForeignKeyColumn<T>()
        {
            string propertyId = ExpressionAssistant.GetPropertyName(() => DefaultUser.Id);
            return (typeof(T).Name + propertyId);
        }

        public static string GetStrongTableByType(Type type)
        {
            List<string> sqlObjectNames = new List<string>
            {
                "user",
            };

            if (sqlObjectNames.Contains(type.Name.ToLower()))
            {
                return string.Format("[{0}]", type.Name);
            }

            return type.Name;
        }
    }
}
