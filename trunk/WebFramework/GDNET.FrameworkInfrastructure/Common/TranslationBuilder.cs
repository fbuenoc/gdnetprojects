using System.CodeDom;
using System.Threading;
using System.Web.Compilation;
using System.Web.UI;
using GDNET.Domain.Repositories;

namespace GDNET.FrameworkInfrastructure.Common
{
    public class TranslationBuilder : ExpressionBuilder
    {
        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            CodeTypeReferenceExpression thisType = new CodeTypeReferenceExpression(base.GetType());
            CodePrimitiveExpression expression = new CodePrimitiveExpression(entry.Expression.Trim().ToString());

            return new CodeMethodInvokeExpression(thisType, "GetTranslation", expression);
        }

        public static string GetTranslation(string expression)
        {
            var translation = DomainRepositories.Translation.GetByKeyword(expression, Thread.CurrentThread.CurrentUICulture);
            return (translation == null) ? string.Format("! {0} !", expression) : translation.Value;
        }

        public override bool SupportsEvaluate
        {
            get
            {
                return true;
            }
        }
    }
}
