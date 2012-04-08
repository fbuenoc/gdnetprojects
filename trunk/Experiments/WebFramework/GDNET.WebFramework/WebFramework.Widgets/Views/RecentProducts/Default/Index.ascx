<%@ Import Namespace="WebFramework.Business" %>
<%@ Import Namespace="WebFramework.Widgets.Models.RecentProducts" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<RecentProductsModel>" %>
<div class="widget_container">
    <h3 class="title">
        <%= base.Model.Name %>
    </h3>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <th class="column_name">
                <%= base.Html.WebFramework().Translation().Translate("SysTranslation.Business.Product.NameView")%>
            </th>
            <th class="number">
                <%= base.Html.WebFramework().Translation().Translate("SysTranslation.Business.Product.PriceView")%>
            </th>
            <th class="number">
                <%= base.Html.WebFramework().Translation().Translate("SysTranslation.Business.Product.DiscountView")%>
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
                <%= base.Html.WebFramework().WidgetHanlder().ActionLinkContentItem(productModel, base.Model.DetailConnection)%>
            </td>
            <td class="number">
                <%= base.Html.WebFramework().NumberFormat().FormatNumber(productModel.GetAttribute<decimal>(BusinessConstants.ProductConstants.Price))%>
            </td>
            <td class="number">
                <%= base.Html.WebFramework().NumberFormat().FormatNumber(productModel.GetAttribute<decimal>(BusinessConstants.ProductConstants.Discount))%>
            </td>
        </tr>
        <%
            }
        %>
    </table>
    <div class="management_space">
        <%= base.Html.WebFramework().WidgetHanlder().ActionLinkAdminister(base.Model) %>
    </div>
</div>
