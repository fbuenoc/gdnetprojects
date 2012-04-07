<%@ Import Namespace="WebFramework.Common.Business.Administration" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ShortcutModel>>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index
    </h2>
    <table width="100%">
        <tr>
            <td valign="top">
                <div>
                    <ul>
                        <li>
                            <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.Zone)%>
                        </li>
                        <li>
                            <%= base.Html.ActionLink("Accounts", "List", "Account") %>
                        </li>
                    </ul>
                    <ul>
                        <li>
                            <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.Application)%>
                        </li>
                        <li>
                            <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.Culture)%>
                        </li>
                        <li>
                            <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.ContentType)%>
                        </li>
                        <li>
                            <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.ListValue)%>
                        </li>
                    </ul>
                    <ul>
                        <li>
                            <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.ContentItem)%>
                        </li>
                        <li>
                            <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.Translation)%>
                        </li>
                        <li>
                            <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.Page)%>
                        </li>
                        <li>
                            <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.Widget)%>
                        </li>
                        <li>
                            <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.Zone)%>
                        </li>
                    </ul>
                </div>
            </td>
            <td valign="top">
                <div>
                    <ul>
                        <%
                            foreach (var shortcutModel in base.Model)
                            {
                        %>
                        <li>
                            <%= base.Html.GDNet().HtmlLink(shortcutModel.TargetUrl, shortcutModel.Name, shortcutModel.Description) %>
                        </li>
                        <%
                            }
                        %>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
