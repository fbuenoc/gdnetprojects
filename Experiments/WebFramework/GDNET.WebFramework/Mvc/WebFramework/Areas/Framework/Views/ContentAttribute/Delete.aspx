<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentAttributeModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Content Attribute
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Delete confirmation
    </h2>
    <p>
        Content Attribute to be deleted:
        <%= base.Model.Code %>
        in the Content Type:
        <%= base.Model.ContentType %>
    </p>
    <p>
        <% base.Html.BeginForm(); %>
        <input type="submit" name="btnOK" value="Delete and Continue" />
        <%= base.Html.HiddenFor(m => m.Id) %>
        <% base.Html.EndForm(); %>
    </p>
    <p>
        <%= base.Html.ActionLink("Return Content Type management", ContentTypeController.ActionDetails, ControllerConstants.FrameworkContentTypeController, new { id = base.Model.ContentTypeId }, new { })%>
    </p>
</asp:Content>
