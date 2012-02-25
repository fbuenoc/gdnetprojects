<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ListValueModel>>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    List Value
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List of Values
    </h2>
    <div>
        <% base.Html.Telerik().Grid<ListValueModel>(base.Model)
                .Name("ListValues")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Name).Title("Value name");
                    columns.Bound(c => c.Description).Title("Description");
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
        <%= base.Html.ActionLink("Add new", ListValueController.ActionCreate)%>
    </p>
</asp:Content>
