<%@ Import Namespace="WebFramework.Common.Framework.System" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PageModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Model.Name %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="LeftContent">
            <% base.Html.WebFramework().WidgetHanlder().DisplayContent(base.Model, "LeftContent"); %>
        </div>
        <div class="RightContent">
        </div>
    </div>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="HeadContent" runat="server">
    <meta name="keyword" content="<%= base.Model.Keyword %>" />
</asp:Content>
