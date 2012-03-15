<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="ViewPage<TranslationModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    CreateOrUpdate
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().CreateOrUpdate<long>(base.Model) %>
    </h2>
    <div>
        <% base.Html.BeginForm(); %>
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
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.Value) %>
        </div>
        <div>
            <%= base.Html.TextAreaFor(m => m.Value, new { @class = "desc" })%>
        </div>
        <p>
            <input type="submit" name="btnOK" value="<%= Translations.System.SaveAndContinue %>" />
        </p>
        <% base.Html.EndForm(); %>
    </div>
    <p>
        <%= base.Html.ActionLink("Return Application management", RoleController.ActionList)%>
    </p>
</asp:Content>
