<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="ViewPage<TranslationModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SysTranslations.EntityTranslation %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().CreateOrUpdate<long>(base.Model) %>
    </h2>
    <div>
        <% base.Html.BeginForm(); %>
        <div>
            <%= base.Html.WebFramework().SysTranslations.CreatedAt %>:
            <%= base.Model.CreatedAt.ToStringEx() %>
            <br />
            <%= base.Html.WebFramework().SysTranslations.CreatedBy %>:
            <%= base.Model.CreatedBy %>
            <br />
            <%= base.Html.WebFramework().SysTranslations.Statut %>:
            <%= base.Model.ActualStatut %>
            <br />
            <%= base.Html.WebFramework().SysTranslations.Category %>:
            <%= base.Model.Category %>
            <br />
            <%= base.Html.WebFramework().SysTranslations.Code %>
            <%= base.Model.Code %>
        </div>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.Value) %>
        </div>
        <div>
            <%= base.Html.TextAreaFor(m => m.Value, new { @class = "desc" })%>
        </div>
        <p>
            <input type="submit" name="btnOK" value="<%= base.Html.WebFramework().SysTranslations.SaveAndContinue %>" />
        </p>
        <% base.Html.EndForm(); %>
    </div>
    <p>
        <%= base.Html.WebFramework().ActionLink("SysTranslation.EntityNames.Translation.ReturnList", RoleController.ActionList)%>
    </p>
</asp:Content>
