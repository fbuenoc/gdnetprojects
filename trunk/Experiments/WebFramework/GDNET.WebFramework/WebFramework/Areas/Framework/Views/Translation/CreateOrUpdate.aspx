<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="ViewPage<TranslationModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SystemTranslation().EntityTranslation %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().Translation().CreateOrUpdate<long>(base.Model) %>
    </h2>
    <div>
        <% base.Html.BeginForm(); %>
        <div>
            <% base.Html.RenderPartial("InfoModificationControl", base.Model); %>
        </div>
        <div>
            <%= base.Html.WebFramework().SystemTranslation().Category %>:
            <%= base.Model.Category %>
            <br />
            <%= base.Html.WebFramework().SystemTranslation().Code %>
            <%= base.Model.Code %>
        </div>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.Value) %>
        </div>
        <div>
            <%= base.Html.TextAreaFor(m => m.Value, new { @class = "desc" })%>
        </div>
        <p>
            <input type="submit" name="btnOK" value="<%= base.Html.WebFramework().SystemTranslation().SaveAndContinue %>" />
        </p>
        <% base.Html.EndForm(); %>
    </div>
    <p>
        <%= base.Html.WebFramework().ActionLink().ActionListLink(ListType.Translations) %>
    </p>
</asp:Content>
