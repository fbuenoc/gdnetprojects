<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Content Item
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create or update
    </h2>
    <h3>
        In Content Type:
        <%= base.Model.ContentType %>
    </h3>
    <div>
        <% base.Html.BeginForm(); %>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.Name) %>
        </div>
        <div>
            <%= base.Html.TextBoxFor(m => m.Name)%>
        </div>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.Description)%>
        </div>
        <div>
            <%= base.Html.TextBoxFor(m => m.Description)%>
        </div>
        <p>
            <%= base.Html.HiddenFor(m => m.ContentTypeId) %>
            <input type="submit" value="Save & Continue" />
        </p>
        <% base.Html.EndForm(); %>
    </div>
    <p>
        <%= base.Html.ActionLink("Return Content Item management", ContentItemController.ActionList)%>
        <%= base.Html.ActionLink("Return current Content Type", ContentTypeController.ActionDetails, ControllerConstants.FrameworkContentTypeController, new { id = base.Model.ContentTypeId }, new { })%>
    </p>
</asp:Content>
