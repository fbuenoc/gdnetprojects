<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AccountModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Accounts
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Delete confirmation
    </h2>
    <p>
        Email:
        <%= base.Model.Email %>
        <br />
        Username:
        <%= base.Model.UserName %>
    </p>
    <div>
        <% base.Html.BeginForm(); %>
        <input type="submit" value="Delete and Continue" />
        <%= base.Html.HiddenFor(m => m.UserName) %>
        <% base.Html.EndForm(); %>
    </div>
</asp:Content>
