﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentTypeModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Content Type
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().CreateOrUpdate<long>(base.Model) %>
    </h2>
    <div>
        <% base.Html.BeginForm(); %>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.Name) %>
        </div>
        <div>
            <%= base.Html.TextBoxFor(m => m.Name)%>
        </div>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.Code)%>
        </div>
        <div>
            <%= base.Html.TextBoxFor(m => m.Code)%>
        </div>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.TypeName)%>
        </div>
        <div>
            <%= base.Html.TextBoxFor(m => m.TypeName)%>
        </div>
        <p>
            <input type="submit" value="<%= base.Html.WebFramework().SystemTranslation().SaveAndContinue %>" />
        </p>
        <% base.Html.EndForm(); %>
    </div>
    <p>
        <%= base.Html.ActionLink("Return Content Type management", ContentTypeController.ActionList)%>
    </p>
</asp:Content>
