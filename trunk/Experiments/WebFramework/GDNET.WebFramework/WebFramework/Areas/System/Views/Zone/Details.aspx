<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ZoneModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SystemTranslation().EntityZone %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().SystemTranslation().DetailOfXYZ(base.Model.Code)%>
    </h2>
    <div>
        <% base.Html.RenderPartial("InfoModificationControl", base.Model); %>
    </div>
    <br />
    <div>
        <% base.Html.Telerik().Grid<RegionModel>(base.Model.Regions)
                .Name("Regions")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Name).Title("Name");
                    columns.Bound(c => c.Widget.Name).Title("Widget");
                    columns.Bound(c => c.Description).Title("Description");
                    columns.Bound(c => c.Id).Title("Actions").Template(template =>
                    {
        %>
        <%
                    });
                })
                .Pageable()
                .Sortable(x =>
                {
                    x.Enabled(true).SortMode(GridSortMode.MultipleColumn).OrderBy(y => y.Add(m => m.Name));
                })
                .Render();
        %>
    </div>
    <p>
        <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.Zone) %>
        <%= base.Html.WebFramework().ActionLink().ActionCreateLink(base.Html.WebFramework().Translation().Translate("SysTranslation.Zone.CreateRegion"), EntityType.Region, new { idzn = base.Model.Id })%>
    </p>
</asp:Content>
