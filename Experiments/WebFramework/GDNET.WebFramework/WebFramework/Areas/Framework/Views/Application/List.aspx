<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ApplicationModel>>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Applications
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List of applications
    </h2>
    <div>
        <% base.Html.Telerik().Grid<ApplicationModel>(base.Model)
                .Name("AllApplications")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Name).Title("Application name");
                    columns.Bound(c => c.Category).Title("Category");
                    columns.Bound(c => c.Name).Title("Category").Template(template =>
                    {
        %>
        <%= base.Html.WebFramework().HyperLinkActions(new { id = template.Id }, Actions.DetailEdit) %>
        <%
                    });
                })
                .Pageable()
                .Render();
        %>
    </div>
    <p>
        <%= base.Html.ActionLink("Add new", ApplicationController.ActionCreate)%>
    </p>
</asp:Content>
