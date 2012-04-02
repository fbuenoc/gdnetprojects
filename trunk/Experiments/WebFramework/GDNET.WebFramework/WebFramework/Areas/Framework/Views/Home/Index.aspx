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
                            <%= base.Html.ActionLink("Roles", "List", "Role")%>
                        </li>
                        <li>
                            <%= base.Html.ActionLink("Accounts", "List", "Account") %>
                        </li>
                    </ul>
                    <ul>
                        <li>
                            <%= base.Html.ActionLink("Applications", "List", "Application")%>
                        </li>
                        <li>
                            <%= base.Html.ActionLink("Cultures", "List", "Culture")%>
                        </li>
                        <li>
                            <%= base.Html.ActionLink("Content types", "List", "ContentType")%>
                        </li>
                        <li>
                            <%= base.Html.ActionLink("Lists", "List", "ListValue")%>
                        </li>
                    </ul>
                    <ul>
                        <li>
                            <%= base.Html.ActionLink("Content items", "List", "ContentItem")%>
                        </li>
                        <li>
                            <%= base.Html.ActionLink("Translations", "List", "Translation")%>
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
