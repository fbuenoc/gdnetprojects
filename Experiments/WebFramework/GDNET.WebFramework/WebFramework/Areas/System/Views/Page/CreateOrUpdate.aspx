﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PageModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SystemTranslation().EntityPage %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().Translation().CreateOrUpdate<long>(base.Model)%>
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
            <%= base.Html.LabelFor(m => m.Description) %>
        </div>
        <div>
            <%= base.Html.TextAreaFor(m => m.Description)%>
        </div>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.Keyword) %>
        </div>
        <div>
            <%= base.Html.TextAreaFor(m => m.Keyword)%>
        </div>
        <p>
            <input type="submit" name="btnOK" value="<%= base.Html.WebFramework().SystemTranslation().SaveAndContinue %>" />
        </p>
        <% base.Html.EndForm(); %>
    </div>
    <p>
        <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.Page) %>
    </p>
</asp:Content>