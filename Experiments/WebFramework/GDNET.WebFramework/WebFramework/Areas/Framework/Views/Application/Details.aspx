﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ApplicationModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Translations.EntityNames.Application %>
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
            <%= Translations.System.CreatedAt %>:
            <%= base.Model.CreatedAt.ToStringEx() %>
            <br />
            <%= Translations.System.CreatedBy %>:
            <%= base.Model.CreatedBy %>
            <br />
            <%= Translations.System.Category %>:
            <%= base.Model.Category %>
            <br />
            <%= Translations.System.Statut %>:
            <%= base.Model.ActualStatut %>
        </div>
    </div>
    <p>
        <%= base.Html.ActionLink("Return Application management", RoleController.ActionList)%>
    </p>
</asp:Content>