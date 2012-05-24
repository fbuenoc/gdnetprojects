<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    List Articles
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="HeadContent" runat="server">
    <% base.Html.WebFramework().WidgetHanlder().RegisterStyleSheets(); %>
</asp:Content>
