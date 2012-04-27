<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PageModel>" %>

<%@ Import Namespace="GDNET.Web.Mvc.ComponentEditors" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Page administrator
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Page administrator
    </h2>
    <% base.Html.BeginForm(); %>
    <p>
        <input type="submit" value="<%= base.Html.WebFramework().SystemTranslation().SaveAndContinue %>" />
    </p>
    <table width="100%">
        <tr class="region_admin_header">
            <th width="120px">
                <%= base.Html.WebFramework().Translation().Translate("SysTranslation.RegionAdministerPropertyName") %>
            </th>
            <th>
                <%= base.Html.WebFramework().Translation().Translate("SysTranslation.RegionAdministerPropertyValue")%>
            </th>
        </tr>
        <% base.Html.GDNet().EditorAssistant().RenderEditorComponent(Editors.TextBoxEditor, "RG_Name", base.Model.Name, true); %>
        <% base.Html.GDNet().EditorAssistant().RenderEditorComponent(Editors.TextAreaEditor, "RG_Keyword", base.Model.Keyword, true); %>
        <% base.Html.GDNet().EditorAssistant().RenderEditorComponent(Editors.TextAreaEditor, "RG_Description", base.Model.Description, true); %>
    </table>
    <p>
        <input type="submit" value="<%= base.Html.WebFramework().SystemTranslation().SaveAndContinue %>" />
    </p>
    <% base.Html.EndForm(); %>
    <div>
        <% base.Html.Telerik().Grid<ZoneModel>(base.Model.ZoneModels)
                .Name("ZoneModels")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Code).Title("Code");
                    columns.Bound(c => c.Description).Title("Description");
                    columns.Bound(c => c.Id).Title("Actions").Template(template =>
                    {
        %>
        <%= base.Html.WebFramework().ActionLink().CreateDetailAction(EntityType.Zone, template) %>
        <%= base.Html.WebFramework().ActionLink().ActionEditLink(EntityType.Zone, template) %>
        <%= base.Html.WebFramework().ActionLink().ActionDeleteLink(EntityType.Zone, template) %>
        <%
                    });
                })
                .Sortable(x =>
                {
                    x.Enabled(true).SortMode(GridSortMode.MultipleColumn).OrderBy(y => y.Add(m => m.Code));
                })
                .Render();
        %>
    </div>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="HeadContent" runat="server">
    <% base.Html.WebFramework().WidgetHanlder().RegisterStyleSheets(base.Model); %>
</asp:Content>
