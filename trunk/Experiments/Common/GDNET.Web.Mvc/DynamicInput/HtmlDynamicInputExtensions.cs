using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using GDNET.Common.DesignByContract;

namespace GDNET.Web.Mvc.DynamicInput
{
    public static class HtmlDynamicInputExtensions
    {
        private static readonly char[] ParameterSeparator = new char[] { ';' };
        private static readonly char[] ValueSeparator = new char[] { ':' };

        public static void BuildInput(this HtmlHelper html, string inputParameters)
        {
            if (!string.IsNullOrEmpty(inputParameters))
            {
                inputParameters = inputParameters.Trim();
            }
            Throw.ArgumentExceptionIfNullOrEmpty(inputParameters, "inputParameters", "Parameters are invalid.");

            StringBuilder builder = new StringBuilder();
            builder.Append("<");

            foreach (var parameter in inputParameters.Split(ParameterSeparator))
            {
                var values = parameter.Split(ValueSeparator);
                if (values.Length != 2)
                {
                    continue;
                }

                if (AttributeKey.TagName.IsMatched(values[0]))
                {
                    builder.AppendFormat("{0} ", AttributeValue.Find(values[1]));
                }
                else
                {
                    builder.AppendFormat("{0}='{1}' ", AttributeKey.Find(values[0]), AttributeValue.Find(values[1]));
                }
            }

            builder.Append(">");
        }
    }
}
