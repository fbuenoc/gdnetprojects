<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ContentTypeModel>>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Content Type
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List of Content Type
    </h2>
    <div>
        <% base.Html.Telerik().Grid<ContentTypeModel>(base.Model)
                .Name("ContentTypes")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Name).Title("Name");
                    columns.Bound(c => c.TypeName).Title("Type name");
                    columns.Bound(c => c.Name).Title("Actions").Template(template =>
                    {
        %>
        <%= base.Html.ActionLink("Details", "Details", new { id = template.Id }) %>
        <%= base.Html.ActionLink("Edit", "Edit", new { id = template.Id })%>
        <%= base.Html.ActionLink("Delete", "Delete", new { id = template.Id })%>
        <%
                    });
                })
                .Pageable()
                .Render();
        %>
    </div>
    <p>
        <%= base.Html.ActionLink("Add new", ContentTypeController.ActionCreate)%>
    </p>
</asp:Content>
