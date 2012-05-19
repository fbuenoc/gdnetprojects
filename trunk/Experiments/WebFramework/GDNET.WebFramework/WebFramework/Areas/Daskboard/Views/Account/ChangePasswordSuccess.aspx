<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Change Password
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Change Password</h2>
    <p>
        Your password has been changed successfully.
    </p>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="HeadContent" runat="server">
    <% base.Html.WebFramework().WidgetHanlder().RegisterStyleSheets(); %>
</asp:Content>
