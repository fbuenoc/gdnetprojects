<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RegionModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index
    </h2>
    <% base.Html.BeginForm(); %>
    <table width="100%">
        <tr class="region_admin_header">
            <th width="120px">
                <%= base.Html.WebFramework().Translation().Translate("SysTranslation.RegionAdministerPropertyName") %>
            </th>
            <th>
                <%= base.Html.WebFramework().Translation().Translate("SysTranslation.RegionAdministerPropertyValue")%>
            </th>
        </tr>
        <% base.Html.WebFramework().WidgetHanlder().DisplayRegionSettings(base.Model); %>
    </table>
    <p>
        <input type="submit" value="<%= base.Html.WebFramework().SystemTranslation().SaveAndContinue %>" />
    </p>
    <% base.Html.EndForm(); %>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
