﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebFrameworkDomain.DefaultImpl;
using System.Linq.Expressions;

namespace WebFrameworkExtensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString DropDownListLV(this HtmlHelper html, string lvName, string name)
        {
            return html.DropDownListLV(lvName, name, 0);
        }

        public static MvcHtmlString DropDownListLV(this HtmlHelper html, string lvName, string name, long selectedItem)
        {
            IEnumerable<SelectListItem> selectList = BuildSelectList(lvName, selectedItem);
            return html.DropDownList(name, selectList);
        }

        public static MvcHtmlString DropDownListLV(this HtmlHelper html, string lvName, string name, long selectedItem, string optionLabel)
        {
            IEnumerable<SelectListItem> selectList = BuildSelectList(lvName, selectedItem);
            return html.DropDownList(name, selectList, optionLabel);
        }

        private static IEnumerable<SelectListItem> BuildSelectList(string lvName, long selectedItem)
        {
            if (!string.IsNullOrEmpty(lvName))
            {
                var rootLV = DomainRepositories.ListValue.FindByName(lvName);
                if (rootLV != null)
                {
                    foreach (var item in DomainRepositories.ListValue.GetAllValuesByParent(rootLV, false))
                    {
                        yield return new SelectListItem
                        {
                            Selected = (item.Id == selectedItem),
                            Text = item.Description.Value,
                            Value = item.Id.ToString(),
                        };
                    }
                }
            }
        }
    }
}
