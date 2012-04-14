using System;
using System.Linq.Expressions;

namespace GDNET.Common.Helpers
{
    public static class ExpressionAssistant
    {
        public static string GetPropertyName<TObject, TProperty>(this TObject objet, Expression<Func<TObject, TProperty>> expression)
        {
            MemberExpression member = expression.Body as MemberExpression;

            if (member == null)
            {
                UnaryExpression unary = expression.Body as UnaryExpression;
                member = unary.Operand as MemberExpression;
            }

            return member.Member.Name;
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
