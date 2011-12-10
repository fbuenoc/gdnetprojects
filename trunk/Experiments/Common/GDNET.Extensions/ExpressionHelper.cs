using System;
using System.Linq.Expressions;

namespace GDNET.Extensions
{
    public static class ExpressionHelper
    {
        public static string GetPropertyName(Expression<Func<object>> propertyLambda)
        {
            MemberExpression member = propertyLambda.Body as MemberExpression;

            if (member == null)
            {
                UnaryExpression unary = propertyLambda.Body as UnaryExpression;
                member = unary.Operand as MemberExpression;
            }

            return member.Member.Name;
        }
    }
}
