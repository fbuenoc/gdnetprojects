﻿using System.Web.Mvc;
using System.Web.Routing;

namespace GDNET.Web.Mvc.Helpers
{
    public partial class GDNetFactory
    {
        public string Image(string id, string url, string alternateText)
        {
            return this.Image(id, url, alternateText, null);
        }

        public string Image(string id, string url, string alternateText, object htmlAttributes)
        {
            // Create tag builder
            var builder = new TagBuilder("img");

            // Create valid id
            builder.GenerateId(id);

            // Add attributes
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("alt", alternateText);
            if (htmlAttributes != null)
            {
                builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            }

            // Render tag
            return builder.ToString(TagRenderMode.SelfClosing);
        }
    }
}