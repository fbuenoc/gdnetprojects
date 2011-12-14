using System;
using System.Linq.Expressions;

namespace GDNET.Common.Base
{
    public static class ExpressionUtil
    {
        public static string GetPropertyName(Expression<Func<object>> property)
        {
            MemberExpression member = property.Body as MemberExpression;

            if (member == null)
            {
                UnaryExpression unary = property.Body as UnaryExpression;
                member = unary.Operand as MemberExpression;
            }

            return member.Member.Name;
        }
    }
}
