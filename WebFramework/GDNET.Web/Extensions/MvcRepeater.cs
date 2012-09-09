using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using GDNET.Utils;

namespace GDNET.Web.Extensions
{
    public static class MvcRepeater
    {
        public static string Repeater(this HtmlHelper html, IList entities, IList<string> properties)
        {
            List<string> repeaterHeader = new List<string>();
            List<string> repeaterBody = new List<string>();

            if ((properties != null) && (properties.Count > 0))
            {
                foreach (string aProperty in properties)
                {
                    TagBuilder aTag = new TagBuilder("div");
                    aTag.Attributes.Add("name", aProperty);
                    aTag.SetInnerText(aProperty);

                    repeaterHeader.Add(aTag.ToString());
                }
            }

            if ((entities != null) && (entities.Count > 0))
            {
                foreach (var anEntity in entities)
                {
                    StringBuilder entityHtml = new StringBuilder();
                    foreach (string aProperty in properties)
                    {
                        TagBuilder aTag = new TagBuilder("div");
                        aTag.Attributes.Add("name", aProperty);

                        var fieldValue = ReflectionAssistant.GetPropertyValue(anEntity, aProperty);
                        if (fieldValue != null)
                        {
                            aTag.SetInnerText(fieldValue.ToString());
                        }

                        entityHtml.Append(aTag.ToString());
                    }

                    repeaterBody.Add(entityHtml.ToString());
                }
            }

            TagBuilder header = new TagBuilder("div");
            header.MergeAttribute("name", "header");
            header.InnerHtml = string.Join(string.Empty, repeaterHeader.ToArray());

            TagBuilder body = new TagBuilder("div");
            body.MergeAttribute("name", "body");
            body.InnerHtml = string.Join(string.Empty, repeaterBody.ToArray());

            return string.Concat(header.ToString(), body.ToString());
        }
    }
}
