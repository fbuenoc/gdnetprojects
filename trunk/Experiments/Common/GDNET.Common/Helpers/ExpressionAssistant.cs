using System;
using System.Linq.Expressions;

namespace GDNET.Common.Helpers
{
    public static class ExpressionAssistant
    {
        public static string GetPropertyName(Expression<Func<object>> propertyNameExpression)
        {
            return ExpressionAssistant.GetPropertyName<object>(propertyNameExpression);
        }

        public static string GetPropertyName<T>(Expression<Func<T>> property)
        {
            MemberExpression member = property.Body as MemberExpression;

            if (member == null)
            {
                UnaryExpression unary = property.Body as UnaryExpression;
                member = unary.Operand as MemberExpression;
            }

            return member.Member.Name;
        }

        public static string GetTypeFullName<T>(Expression<Func<T>> property)
        {
            MemberExpression member = property.Body as MemberExpression;

            if (member == null)
            {
                UnaryExpression unary = property.Body as UnaryExpression;
                member = unary.Operand as MemberExpression;
            }

            return member.Member.DeclaringType.FullName;
        }
    }
}
