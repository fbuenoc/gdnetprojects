<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CultureModel>>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Culture
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List of Cultures
    </h2>
    <div>
        <% base.Html.Telerik().Grid<CultureModel>(base.Model)
                .Name("ListCultures")
                .Columns(columns =>
                {
                    columns.Bound(c => c.CultureCode).Title("Culture code");
                    columns.Bound(c => c.IsDefault).Title("Is default");
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
