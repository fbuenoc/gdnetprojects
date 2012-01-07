<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Content Item
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Delete confirmation
    </h2>
    <p>
        Content Item to be deleted:
        <%= base.Model.Name %>
    </p>
    <p>
        <% base.Html.BeginForm(); %>
        <input type="submit" name="btnOK" value="Delete and Continue" />
        <%= base.Html.HiddenFor(m => m.Id) %>
        <% base.Html.EndForm(); %>
    </p>
    <p>
        <%= base.Html.ActionLink("Return to current Content Item", ContentItemController.ActionDetails, new { id = base.Model.Id })%>
    </p>
</asp:Content>
