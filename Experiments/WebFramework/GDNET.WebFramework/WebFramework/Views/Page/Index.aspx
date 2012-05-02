<%@ Import Namespace="WebFramework.Common.Framework.System" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PageModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Model.Name %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="LeftContent">
        <% base.Html.WebFramework().WidgetHanlder().DisplayContent(base.Model, "LeftContent"); %>
    </div>
    <div class="RightContent">
        <% base.Html.WebFramework().WidgetHanlder().DisplayContent(base.Model, "RightContent"); %>
    </div>
    <% base.Html.RenderPartial("PageAdminister", base.Model); %>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="HeadContent" runat="server">
    <meta name="keyword" content="<%= base.Model.Keyword %>" />
    <% base.Html.WebFramework().WidgetHanlder().RegisterStyleSheets(base.Model); %>
</asp:Content>
