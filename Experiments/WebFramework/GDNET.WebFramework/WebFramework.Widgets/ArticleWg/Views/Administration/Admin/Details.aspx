<%@ Import Namespace="WebFramework.Widgets.ArticleWg.Models" %>

<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ArticleModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Article details
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
    </h2>
    <div>
        <table width="100%">
            <% base.Html.GDNet().EditorAssistant().RenderEditorComponent(Editors.TextBoxEditor, "Title", base.Model.Title, false); %>
            <% base.Html.GDNet().EditorAssistant().RenderEditorComponent(Editors.TextAreaEditor, "Description", base.Model.Description, false); %>
            <% base.Html.GDNet().EditorAssistant().RenderEditorComponent(Editors.HtmlEditor, "FullContent", base.Model.FullContent, false); %>
        </table>
    </div>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="HeadContent" runat="server">
    <% base.Html.WebFramework().WidgetHanlder().RegisterStyleSheets(); %>
</asp:Content>
