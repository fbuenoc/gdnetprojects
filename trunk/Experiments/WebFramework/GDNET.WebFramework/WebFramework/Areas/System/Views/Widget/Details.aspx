<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WidgetModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SystemTranslation().EntityPage %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().SystemTranslation().DetailOfXYZ(base.Model.Name)%>
    </h2>
    <div>
        <% base.Html.RenderPartial("InfoModificationControl", base.Model); %>
    </div>
    <br />
    <div>
        <% base.Html.Telerik().Grid<WidgetPropertyModel>(base.Model.PropertiesModel)
                .Name("ZoneModels")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Code).Title("Code");
                    columns.Bound(c => c.Value).Title("Value");
                    columns.Bound(c => c.Id).Title("Actions").Template(template =>
                    {
        %>
        <%= base.Html.WebFramework().ActionLink().CreateDetailAction(EntityType.Zone, template) %>
        <%= base.Html.WebFramework().ActionLink().ActionEditLink(EntityType.Zone, template) %>
        <%= base.Html.WebFramework().ActionLink().ActionDeleteLink(EntityType.Zone, template) %>
        <%
                    });
                })
                .Pageable()
                .Sortable(x =>
                {
                    x.Enabled(true).SortMode(GridSortMode.MultipleColumn).OrderBy(y => y.Add(m => m.Code));
                })
                .Render();
        %>
    </div>
    <p>
        <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.Page) %>
    </p>
</asp:Content>
