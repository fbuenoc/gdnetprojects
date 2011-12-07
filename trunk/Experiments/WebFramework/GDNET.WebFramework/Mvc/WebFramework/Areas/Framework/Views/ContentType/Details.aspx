<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentTypeModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Content Type
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details information:
        <%= base.Model.Name %>
    </h2>
    <div>
        <div>
            Created at:
            <%= base.Model.CreatedAt.ToStringEx() %>
        </div>
        <div>
            Created by:
            <%= base.Model.CreatedBy %>
        </div>
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
        <%= base.Html.ActionLink("Add new Attribute", ContentTypeController.ActionCreate, ControllerConstants.FrameworkContentAttributeController, new { key = base.Model.Id }, new { })%>
    </p>
</asp:Content>
