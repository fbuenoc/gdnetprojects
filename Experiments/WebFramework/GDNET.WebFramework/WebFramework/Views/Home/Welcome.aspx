<%@ Import Namespace="WebFramework.ViewModels" %>
<%@ Import Namespace="WebFramework.Business" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HomeViewModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Welcome
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="HeadContent" runat="server">
    <%= base.Html.GDNet().RegisterStyleSheet("Home/Welcome.css") %>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content_left">
        <div class="title_focus">
            <%= base.Html.WebFramework().Translate("SysTranslation.Business.Product.AvailableProducts")%>
        </div>
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
    </div>
    <div class="content_right">
        <table>
            <%
                foreach (var articleModel in base.Model.Articles)
                {
            %>
            <tr>
                <td>
                    <%= base.Html.WebFramework().HyperLink(articleModel)%>
                </td>
            </tr>
            <%
                }
            %>
        </table>
    </div>
    <div class="clear">
    </div>
</asp:Content>
