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
        <div>
            Created at:
            <%= base.Model.CreatedAt.ToStringEx() %>
        </div>
        <div>
            Created by:
            <%= base.Model.CreatedBy %>
        </div>
        <div>
            Parent:
            <%= base.Model.Parent %>
        </div>
        <div>
            Sub Values
        </div>
        <div>
            <% base.Html.Telerik().Grid<ListValueModel>(base.Model.SubValues)
                .Name("SubValues")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Name).Title("Value name");
                    columns.Bound(c => c.Description).Title("Description");
                    columns.Bound(c => c.Name).Title("Category").Template(template =>
                    {
            %>
            <%= base.Html.ActionLink("Details", "Details", new { id = template.Id }) %>
            <%= base.Html.ActionLink("Delete", "Delete", new { id = template.Id })%>
            <%
                    });
                })
                .Pageable()
                .Render();
            %>
        </div>
    </div>
    <p>
        <%= base.Html.ActionLink("Return ListValue management", ListValueController.ActionList)%>
    </p>
</asp:Content>
