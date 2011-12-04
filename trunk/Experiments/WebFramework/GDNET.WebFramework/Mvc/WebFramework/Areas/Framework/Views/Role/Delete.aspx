<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RoleModel>" %>

<%@ Import Namespace="WebFramework.Areas.Framework.Controllers" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Delete confirmation
    </h2>
    <p>
        Role to be deleted:
        <%= base.Model.Name %>
    </p>
    <p>
        <% base.Html.BeginForm(); %>
        <input type="submit" name="btnOK" value="Delete and Continue" />
        <%= base.Html.HiddenFor(m => m.Name) %>
        <% base.Html.EndForm(); %>
    </p>
    <p>
        <%= base.Html.ActionLink("Return Role management", RoleController.ActionList) %>
    </p>
</asp:Content>
