using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GDNET.Domain.Entities.System;
using GDNET.Utils;

namespace GDNET.Mapping.Common
{
    public static class MappingAssistant
    {
        public static string GetForeignKeyColumn<T>(Expression<Func<T>> property)
        {
            User DefaultUser = default(User);
            string propertyId = ExpressionAssistant.GetPropertyName(() => DefaultUser.Id);
            string propertyName = ExpressionAssistant.GetPropertyName(property);
            return (propertyName + propertyId);
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
