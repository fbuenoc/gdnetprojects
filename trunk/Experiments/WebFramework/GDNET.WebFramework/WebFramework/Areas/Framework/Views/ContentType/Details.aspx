<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentTypeModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Translations.EntityNames.ContentType %>
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
        <h3>
            Attributes
        </h3>
        <div>
            <% base.Html.Telerik().Grid<ContentAttributeModel>(base.Model.Attributes)
                .Name("Attributes")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Code).Title("Code");
                    columns.Bound(c => c.DataType).Title("Data type");
                    columns.Bound(c => c.Id).Title("Actions").Template(template =>
                    {
            %>
            <%= base.Html.ActionLink("Details", "Details", ControllerConstants.FrameworkContentAttributeController, new { id = template.Id }, new { })%>
            <%= base.Html.ActionLink("Edit", "Edit", ControllerConstants.FrameworkContentAttributeController, new { id = template.Id }, new { })%>
            <%= base.Html.ActionLink("Delete", "Delete", ControllerConstants.FrameworkContentAttributeController, new { id = template.Id }, new { })%>
            <%
                    });
                })
                .Pageable()
                .Render();
            %>
        </div>
    </div>
    <p>
        <%= base.Html.ActionLink("Return Content Type management", ContentTypeController.ActionList)%>
        <%= base.Html.ActionLink("Add new Attribute", ContentAttributeController.ActionCreate, ControllerConstants.FrameworkContentAttributeController, new { key = base.Model.Id }, new { })%>
        <%= base.Html.ActionLink("Add new Content Item", ContentItemController.ActionCreate, ControllerConstants.FrameworkContentItemController, new { key = base.Model.Id }, new { })%>
    </p>
</asp:Content>
