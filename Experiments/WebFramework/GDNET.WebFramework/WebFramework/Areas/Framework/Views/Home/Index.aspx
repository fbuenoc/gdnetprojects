<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Index
    </h2>
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
        </ul>
    </div>
</asp:Content>
