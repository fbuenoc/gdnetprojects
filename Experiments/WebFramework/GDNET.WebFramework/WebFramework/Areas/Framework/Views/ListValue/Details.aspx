<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ListValueModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    List Value
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details of List Value:
        <%= base.Model.Name %>
    </h2>
    <div>
        <% base.Html.RenderPartial("InfoModificationControl", base.Model); %>
    </div>
    <div>
        Parent:
        <%= base.Model.Parent %>
    </div>
    <h3>
        Sub Values
    </h3>
    <div>
        <% base.Html.Telerik().Grid<ListValueModel>(base.Model.SubValues)
                .Name("SubValues")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Name).Title("Value name");
                    columns.Bound(c => c.Description).Title("Description");
                    columns.Bound(c => c.Name).Title("Actions").Template(template =>
                    {
        %>
        <%= base.Html.ActionLink("Details", "Details", new { id = template.Id })%>
        <%= base.Html.ActionLink("Edit", "Edit", new { id = template.Id })%>
        <%= base.Html.ActionLink("Delete", "Delete", new { id = template.Id })%>
        <%
                    });
                })
                .Pageable()
                .Sortable(x =>
                {
                    x.Enabled(true).SortMode(GridSortMode.MultipleColumn).OrderBy(y => y.Add(m => m.Description));
                })
                .Render();
        %>
    </div>
    <p>
        <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.ListValue) %>
        <% if (base.Model.ParentId != 0)
           {
        %>
        <%= base.Html.ActionLink("Return " + base.Model.Parent, ListValueController.ActionDetails, new { id = base.Model.ParentId }) %>
        <%
           }
        %>
        <%= base.Html.ActionLink("Add new", ListValueController.ActionCreate, new { key = base.Model.Id }) %>
    </p>
</asp:Content>
