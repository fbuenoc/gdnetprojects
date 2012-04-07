<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ZoneModel>>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    List
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List
    </h2>
    <div>
        <% base.Html.Telerik().Grid<ZoneModel>(base.Model)
                .Name("ZoneModels")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Code).Title("Code");
                    columns.Bound(c => c.Description).Title("Description");
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
