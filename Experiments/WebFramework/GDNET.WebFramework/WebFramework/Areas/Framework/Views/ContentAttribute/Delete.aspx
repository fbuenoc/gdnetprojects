﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentAttributeModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Translations.System.DeleteConfirmation %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <%= Translations.System.DeleteConfirmationXYZ(Translations.EntityNames.ContentAttribute) %>
    </div>
    <div>
        <%= base.Model.Code %>
        in the Content Type:
        <%= base.Model.ContentType %>
    </div>
    <p>
        <%= Translations.System.CreatedAt %>:
        <%= base.Model.CreatedAt.ToStringEx() %>
        <br />
        <%= Translations.System.CreatedBy %>:
        <%= base.Model.CreatedBy %>
        <br />
        <%= Translations.System.Statut %>:
        <%= base.Model.ActualStatut %>
    </p>
    <p>
        <% base.Html.BeginForm(); %>
        <input type="submit" name="btnOK" value="<%= Translations.System.DeleteAndContinue %>" />
        <%= base.Html.HiddenFor(m => m.Id) %>
        <% base.Html.EndForm(); %>
    </p>
    <p>
        <%= base.Html.ActionLink("Return Content Type management", ContentTypeController.ActionDetails, ControllerConstants.FrameworkContentTypeController, new { id = base.Model.ContentTypeId }, new { })%>
    </p>
</asp:Content>