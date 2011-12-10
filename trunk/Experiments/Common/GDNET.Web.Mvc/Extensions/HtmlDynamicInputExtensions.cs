using System;
using System.Text;
using System.Web.Mvc;

using GDNET.Common.DesignByContract;
using GDNET.Web.Mvc.DynamicInput;

namespace GDNET.Web.Mvc.Extensions
{
    public static class HtmlDynamicInputExtensions
    {
        private static readonly char[] ParameterSeparator = new char[] { ';' };
        private static readonly char[] ValueSeparator = new char[] { ':' };

        private static bool Is(this string text, AttributeInfo info)
        {
            return info.IsMatched(text);
        }

        public static MvcHtmlString BuildInput(this HtmlHelper html, string inputParameters)
        {
            if (!string.IsNullOrEmpty(inputParameters))
            {
                inputParameters = inputParameters.Trim();
            }
            Throw.ArgumentExceptionIfNullOrEmpty(inputParameters, "inputParameters", "Parameters are invalid.");

            string tagKey = string.Empty;
            StringBuilder builder = new StringBuilder();
            builder.Append("<");

            foreach (var attributeKeyValuePair in inputParameters.Split(ParameterSeparator))
            {
                if (string.IsNullOrEmpty(attributeKeyValuePair))
                {
                    continue;
                }

                var keyAndValue = attributeKeyValuePair.Split(ValueSeparator);
                if (keyAndValue.Length != 2)
                {
                    continue;
                }

                if (keyAndValue[0].Is(AttributeKey.TagName))
                {
                    tagKey = keyAndValue[1];
                    builder.AppendFormat("{0} ", AttributeValue.Find(keyAndValue[1]));
                }
                else
                {
                    var attributeValue = keyAndValue[1].StartsWith(AttributeValue.DistinguistCharacter) ? AttributeValue.Find(keyAndValue[1]) : keyAndValue[1];
                    builder.AppendFormat("{0}='{1}' ", AttributeKey.Find(keyAndValue[0]), attributeValue);
                }
            }

            if (tagKey.Is(AttributeValue.TagInput))
            {
                // Value of input box will be filled into {0}
                builder.Append("{0} />");
            }
            else if (tagKey.Is(AttributeValue.TagTextArea))
            {
                // Value of input box will be filled into {0}
                builder.Append(">{0}");
                builder.AppendFormat("</{0}>", AttributeValue.Find(tagKey));
            }

            return MvcHtmlString.Create(builder.ToString());
        }
    }
}
