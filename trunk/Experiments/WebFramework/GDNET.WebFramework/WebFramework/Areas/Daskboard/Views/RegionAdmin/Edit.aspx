<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RegionModel>" %>

<%@ Import Namespace="GDNET.Web.Mvc.ComponentEditors" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Region administrator
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Region administrator
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
        <% base.Html.GDNet().EditorAssistant().RenderEditorComponent(Editors.HtmlEditor, "RG_Description", base.Model.Description, true); %>
        <% base.Html.WebFramework().WidgetHanlder().DisplayRegionSettings(base.Model); %>
    </table>
    <p>
        <input type="submit" value="<%= base.Html.WebFramework().SystemTranslation().SaveAndContinue %>" />
    </p>
    <% base.Html.EndForm(); %>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="HeadContent" runat="server">
    <% base.Html.WebFramework().WidgetHanlder().RegisterStyleSheets(); %>
</asp:Content>
