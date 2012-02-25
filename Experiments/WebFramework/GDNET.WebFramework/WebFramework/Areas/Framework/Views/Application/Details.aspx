<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ApplicationModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Application
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details of Application:
    </h2>
    <div>
        <div>
            <a href="<%= base.Model.RootUrl %>" title="<%= base.Model.Description %>">
                <%= base.Model.Name %>
            </a>
        </div>
        <br />
        <div>
            Created at:
            <%= base.Model.CreatedAt.ToStringEx() %>
        </div>
        <div>
            Created by:
            <%= base.Model.CreatedBy %>
        </div>
        <div>
            Category:
            <%= base.Model.Category %>
        </div>
    </div>
    <p>
        <%= base.Html.ActionLink("Return Application management", RoleController.ActionList)%>
    </p>
</asp:Content>
