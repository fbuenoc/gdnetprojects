﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentTypeModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SystemTranslation().DeleteConfirmation %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= base.Html.WebFramework().SystemTranslation().DeleteConfirmationXYZ(base.Html.WebFramework().SystemTranslation().EntityContentType); %>
    </div>
    <div>
        <%= base.Model.Name %>
    </div>
    <p>
        <%= base.Html.WebFramework().SystemTranslation().CreatedAt %>:
        <%= base.Model.CreatedAt.ToStringEx() %>
        <br />
        <%= base.Html.WebFramework().SystemTranslation().CreatedBy %>:
        <%= base.Model.CreatedBy %>
        <br />
        <%= base.Html.WebFramework().SystemTranslation().Statut %>:
        <%= base.Model.ActualStatut %>
    </p>
    <p>
        <% base.Html.BeginForm(); %>
        <input type="submit" name="btnOK" value="<%= base.Html.WebFramework().SystemTranslation().DeleteAndContinue %>" />
        <%= base.Html.HiddenFor(m => m.Id) %>
        <% base.Html.EndForm(); %>
    </p>
    <p>
        <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.ContentType) %>
        <%= base.Html.ActionLink("Return Content Type management", ContentTypeController.ActionList) %>
    </p>
</asp:Content>