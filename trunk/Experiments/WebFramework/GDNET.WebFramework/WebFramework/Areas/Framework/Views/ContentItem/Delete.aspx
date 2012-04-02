<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SystemTranslation().DeleteConfirmation %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= base.Html.WebFramework().SystemTranslation().DeleteConfirmationXYZ(base.Html.WebFramework().SystemTranslation().EntityContentItem)%>
    </div>
    <div>
        <%= base.Model.Name %>
    </div>
    <div>
        <% base.Html.RenderPartial("InfoModificationControl", base.Model); %>
    </div>
    <p>
        <% base.Html.BeginForm(); %>
        <input type="submit" name="btnOK" value="<%= base.Html.WebFramework().SystemTranslation().DeleteAndContinue %>" />
        <%= base.Html.HiddenFor(m => m.Id) %>
        <% base.Html.EndForm(); %>
    </p>
    <p>
        <%= base.Html.WebFramework().ActionLink().ActionListLink(ListType.ContentItems) %>
        <%= base.Html.ActionLink("Return to current Content Item", ContentItemController.ActionDetails, new { id = base.Model.Id })%>
    </p>
</asp:Content>
