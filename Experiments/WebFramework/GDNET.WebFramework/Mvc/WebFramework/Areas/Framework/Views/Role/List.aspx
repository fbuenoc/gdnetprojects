<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<RoleModel>>" %>

<%@ Import Namespace="WebFramework.Areas.Framework.Controllers" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Roles
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List of roles
    </h2>
    <div>
        <% base.Html.Telerik().Grid<RoleModel>(base.Model)
                .Name("AllRoles")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Name).Title("Role name");
                    columns.Bound(c => c.Name).Title("Actions").Template(template =>
                    {
        %>
        <%= base.Html.ActionLink("Details", "Details", new { role = template.Name }) %>
        <%= base.Html.ActionLink("Delete", "Delete", new { role = template.Name }) %>
        <%
                    });
                })
                .Pageable()
                .Render();
        %>
    </div>
    <p>
        <%= base.Html.ActionLink("Return Role index", RoleController.ActionList) %>
        |
        <%= base.Html.ActionLink("Add new", RoleController.ActionCreate)%>
    </p>
</asp:Content>
