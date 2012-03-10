<%@ Import Namespace="WebFramework.ViewModels" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ItemViewModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= TranslationAssistant.Translate("ApplicationCategories.SysTranslation.Business.ProductDetail") %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        ProductDetails
    </h2>
</asp:Content>
