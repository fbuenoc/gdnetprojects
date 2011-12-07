<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ContentAttributeModel>>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Content Attribute
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List of Content Attributes
    </h2>
    <div>
        <% base.Html.Telerik().Grid<ContentAttributeModel>(base.Model)
                .Name("ContentAttributes")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Code).Title("Code");
                    columns.Bound(c => c.ContentType).Title("Content type");
                    columns.Bound(c => c.DataType).Title("Data type");
                    columns.Bound(c => c.Id).Title("Actions").Template(template =>
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
        <%= base.Html.ActionLink("Add new", ListValueController.ActionCreate)%>
    </p>
</asp:Content>
