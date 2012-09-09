using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using GDNET.Utils;

namespace GDNET.Web.Extensions
{
    public static class MvcRepeater
    {
        public static string Repeater(this HtmlHelper html, string name, IList entities, params string[] properties)
        {
            return html.Repeater(name, false, entities, properties.ToList());
        }

        public static string Repeater(this HtmlHelper html, string name, bool enableHeader, IList entities, params string[] properties)
        {
            return html.Repeater(name, enableHeader, entities, properties.ToList());
        }

        public static string Repeater(this HtmlHelper html, string name, IList entities, IList<string> properties)
        {
            return html.Repeater(name, false, entities, properties);
        }

        public static string Repeater(this HtmlHelper html, string name, bool enableHeader, IList entities, IList<string> properties)
        {
            List<string> repeaterHeader = new List<string>();
            List<string> repeaterBody = new List<string>();

            if (enableHeader)
            {
                if ((properties != null) && (properties.Count > 0))
                {
                    foreach (string aProperty in properties)
                    {
                        TagBuilder aTag = new TagBuilder(HtmlTags.Div);
                        aTag.Attributes.Add(HtmlAttributes.Name, aProperty);
                        aTag.SetInnerText(aProperty);

                        repeaterHeader.Add(aTag.ToString());
                    }
                }
            }

            if ((entities != null) && (entities.Count > 0))
            {
                foreach (var anEntity in entities)
                {
                    StringBuilder entityHtml = new StringBuilder();
                    foreach (string aProperty in properties)
                    {
                        TagBuilder aTag = new TagBuilder(HtmlTags.Div);
                        aTag.Attributes.Add(HtmlAttributes.Name, aProperty);

                        var fieldValue = ReflectionAssistant.GetPropertyValue(anEntity, aProperty);
                        if (fieldValue != null)
                        {
                            aTag.SetInnerText(fieldValue.ToString());
                        }

                        entityHtml.Append(aTag.ToString());
                    }

                    TagBuilder entityTag = new TagBuilder(HtmlTags.Div);
                    entityTag.Attributes.Add(HtmlAttributes.Name, "line");
                    entityTag.InnerHtml = entityHtml.ToString();

                    repeaterBody.Add(entityTag.ToString());
                }
            }

            StringBuilder repeaterContent = new StringBuilder();

            if (repeaterHeader.Count > 0)
            {
                TagBuilder header = new TagBuilder(HtmlTags.Div);
                header.MergeAttribute(HtmlAttributes.Name, "header");
                header.InnerHtml = string.Join(string.Empty, repeaterHeader.ToArray());
                repeaterContent.Append(header.ToString());
            }

            if (repeaterBody.Count > 0)
            {
                TagBuilder body = new TagBuilder(HtmlTags.Div);
                body.MergeAttribute(HtmlAttributes.Name, "body");
                body.InnerHtml = string.Join(Environment.NewLine, repeaterBody.ToArray());
                repeaterContent.Append(body.ToString());
            }

            TagBuilder repeater = new TagBuilder(HtmlTags.Div);
            repeater.MergeAttribute(HtmlAttributes.Name, name);
            repeater.InnerHtml = string.Concat(repeaterContent.ToString());

            return repeater.ToString();
        }
    }
}
