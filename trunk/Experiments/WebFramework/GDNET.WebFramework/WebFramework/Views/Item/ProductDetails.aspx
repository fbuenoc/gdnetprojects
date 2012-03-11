<%@ Import Namespace="WebFramework.ViewModels" %>
<%@ Import Namespace="WebFramework.Business" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ItemViewModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= TranslationAssistant.Translate("SysTranslation.Business.Product.ProductDetail")%>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="HeadContent" runat="server">
    <%= base.Html.GDNet().RegisterStyleSheet("ContentItem/ProductDetails.css") %>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content_left">
        <div class="title_focus">
            <%= base.Model.Item.Name %>
        </div>
        <div class="detail_description">
            <%= base.Model.Item.Description %>
        </div>
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr class="normal_row">
                <td>
                    <%= TranslationAssistant.Translate("SysTranslation.Business.Product.PriceView")%>
                </td>
                <td>
                    <%= FormatterAssistant.FormatNumber(base.Model.Item.GetAttribute<decimal>(BusinessConstants.ProductConstants.Price)) %>
                </td>
            </tr>
            <tr class="normal_row alt_row">
                <td>
                    <%= TranslationAssistant.Translate("SysTranslation.Business.Product.DiscountView")%>
                </td>
                <td>
                    <%= FormatterAssistant.FormatNumber(base.Model.Item.GetAttribute<decimal>(BusinessConstants.ProductConstants.Discount)) %>
                </td>
            </tr>
            <tr class="normal_row">
                <td>
                    <%= TranslationAssistant.Translate("SysTranslation.Business.Product.RealPrice")%>
                </td>
                <td>
                    <%= FormatterAssistant.FormatNumber(base.Model.Item.GetAttribute<decimal>(BusinessConstants.ProductConstants.RealPrice)) %>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
