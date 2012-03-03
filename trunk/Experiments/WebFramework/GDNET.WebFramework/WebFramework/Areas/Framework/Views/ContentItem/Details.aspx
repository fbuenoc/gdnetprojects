<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Translations.EntityNames.ContentItem %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= Translations.System.DetailOfXYZ(base.Model.Name) %>
    </h2>
    <div>
        <%= Translations.System.CreatedAt %>:
        <%= base.Model.CreatedAt.ToStringEx() %>
        <br />
        <%= Translations.System.CreatedBy %>:
        <%= base.Model.CreatedBy %>
        <br />
        <%= Translations.System.Statut %>:
        <%= base.Model.ActualStatut %>
        <div>
            <%= Translations.System.Description %>:
            <%= base.Model.Description %>
        </div>
        <h3>
            <%= Translations.System.Attributes %>
        </h3>
        <%
            foreach (var attributeValue in base.Model.AttributesValue)
            {
        %>
        <div>
            <%= attributeValue.ContentAttributeName %>
        </div>
        <div>
            <%= attributeValue.Value %>
        </div>
        <%
            }
        %>
    </div>
    <p>
        <%= base.Html.ActionLink(Translations.System.ReturnToListOfXYZ(Translations.EntityNames.ContentItem), ContentItemController.ActionList)%>
        <%= base.Html.ActionLink("Create other Content Item", ContentItemController.ActionCreate, ControllerConstants.FrameworkContentItemController, new { key = base.Model.ContentTypeId }, new { })%>
    </p>
</asp:Content>
