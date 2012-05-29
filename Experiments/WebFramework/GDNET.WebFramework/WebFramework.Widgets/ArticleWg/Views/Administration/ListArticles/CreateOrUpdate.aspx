<%@ Import Namespace="WebFramework.Widgets.ArticleWg.Models" %>

<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ArticleModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Article
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
    </h2>
    <div>
        <% base.Html.BeginForm(); %>
        <table width="100%">
            <% base.Html.GDNet().EditorAssistant().RenderEditorComponent(Editors.TextBoxEditor, "Title", base.Model.Title, true); %>
            <% base.Html.GDNet().EditorAssistant().RenderEditorComponent(Editors.TextAreaEditor, "Description", base.Model.Description, true); %>
            <% base.Html.GDNet().EditorAssistant().RenderEditorComponent(Editors.HtmlEditor, "FullContent", base.Model.FullContent, true); %>
        </table>
        <p>
            <input type="submit" name="btnOK" value="<%= base.Html.WebFramework().SystemTranslation().SaveAndContinue %>" />
        </p>
        <% base.Html.EndForm(); %>
    </div>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="HeadContent" runat="server">
    <% base.Html.WebFramework().WidgetHanlder().RegisterStyleSheets(); %>
</asp:Content>
