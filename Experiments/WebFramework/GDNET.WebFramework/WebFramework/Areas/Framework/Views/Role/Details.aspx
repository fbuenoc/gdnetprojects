<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RoleModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Roles
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details of Role:
        <%= base.Model.Name %>
    </h2>
    <h3>
        Current users in role (<%= base.Model.Users.Count %>)
    </h3>
    <div>
        <%
            StringBuilder usersInRoleBuilder = new StringBuilder();
            string usersInRole = string.Join("<br />", base.Model.Users.ToArray());
        %>
        <%= usersInRole %>
    </div>
    <p>
        <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.ContentType) %>
        |
        <%= base.Html.ActionLink("Add User to role", RoleController.ActionAddUser, new { role = base.Model.Name })%>
    </p>
</asp:Content>
