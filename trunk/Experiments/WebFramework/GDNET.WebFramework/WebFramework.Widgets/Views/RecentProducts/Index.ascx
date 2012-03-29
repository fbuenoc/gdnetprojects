<%@ Import Namespace="WebFramework.Business" %>
<%@ Import Namespace="WebFramework.Widgets.Models.RecentProducts" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<RecentProductsModel>" %>
<div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <th class="column_name">
                <%= base.Html.WebFramework().Translate("SysTranslation.Business.Product.NameView")%>
            </th>
            <th class="number">
                <%= base.Html.WebFramework().Translate("SysTranslation.Business.Product.PriceView")%>
            </th>
            <th class="number">
                <%= base.Html.WebFramework().Translate("SysTranslation.Business.Product.DiscountView")%>
            </th>
        </tr>
        <%
            int counter = 0;
            foreach (var productModel in base.Model.Products)
            {
                counter += 1;
                string altCss = ((counter % 2) == 0) ? "normal_row alt_row" : "normal_row";
        %>
        <tr class="<%= altCss %>">
            <td class="column_name">
                <%= base.Html.WebFramework().HyperLink(productModel) %>
            </td>
            <td class="number">
                <%= base.Html.WebFramework().FormatNumber(productModel.GetAttribute<decimal>(BusinessConstants.ProductConstants.Price))%>
            </td>
            <td class="number">
                <%= base.Html.WebFramework().FormatNumber(productModel.GetAttribute<decimal>(BusinessConstants.ProductConstants.Discount))%>
            </td>
        </tr>
        <%
            }
        %>
    </table>
</div>
