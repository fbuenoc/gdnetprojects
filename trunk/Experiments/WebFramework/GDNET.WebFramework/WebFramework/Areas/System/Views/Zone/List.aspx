<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<PageModel>>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    List
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List
    </h2>
    <div>
        <% base.Html.Telerik().Grid<PageModel>(base.Model)
                .Name("AllPages")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Name).Title("Name");
                    columns.Bound(c => c.UniqueName).Title("Unique name");
                    columns.Bound(c => c.Id).Title("Actions").Template(template =>
                    {
        %>
        <%= base.Html.WebFramework().HyperLink().HyperLinkActions(new { id = template.Id }, Actions.DetailEdit) %>
        <%
                    });
                })
                .Pageable()
                .Render();
        %>
    </div>
</asp:Content>
