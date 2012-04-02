<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RoleModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SystemTranslation().DeleteConfirmation %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().SystemTranslation().DeleteConfirmationXYZ(base.Html.WebFramework().SystemTranslation().EntityRole); %>
    </h2>
    <p>
        Role to be deleted:
        <%= base.Model.Name %>
    </p>
    <p>
        <% base.Html.BeginForm(); %>
        <input type="submit" name="btnOK" value="<%= base.Html.WebFramework().SystemTranslation().DeleteAndContinue %>" />
        <%= base.Html.HiddenFor(m => m.Name) %>
        <% base.Html.EndForm(); %>
    </p>
    <p>
        <%= base.Html.WebFramework().ActionLink().ActionListLink(ListType.ContentTypes) %>
    </p>
</asp:Content>
