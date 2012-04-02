﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ListValueModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SysTranslations.DeleteConfirmation %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().SysTranslations.DeleteConfirmationXYZ(base.Html.WebFramework().SysTranslations.EntityListValue); %>
    </h2>
    <p>
        List Value to be deleted:
        <%= base.Model.Name %>
    </p>
    <p>
        <% base.Html.BeginForm(); %>
        <input type="submit" name="btnOK" value="<%= base.Html.WebFramework().SysTranslations.DeleteAndContinue %>" />
        <%= base.Html.HiddenFor(m => m.Id) %>
        <% base.Html.EndForm(); %>
    </p>
    <p>
        <%= base.Html.ActionLink("Return List Value management", ListValueController.ActionList) %>
    </p>
</asp:Content>