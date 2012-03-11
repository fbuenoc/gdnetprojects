﻿using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebFramework.Base.Helpers
{
    public class WebFrameworkFactory
    {
        private HtmlHelper htmlHelper;

        public WebFrameworkFactory(HtmlHelper html)
        {
            this.htmlHelper = html;
        }

        public MvcHtmlString ActionLink(string linkCodeText, string actionName, string controllerName)
        {
            string linkText = TranslationAssistant.Translate(linkCodeText);
            return this.htmlHelper.ActionLink(linkText, actionName, controllerName);
        }
    }
}
