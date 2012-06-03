<%@ Import Namespace="WebFramework.Widgets.ArticleWg.Models" %>

<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ArticleModel>>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    List Articles
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="zone_actions">
        <%= base.Html.WebFramework().ActionLink().ActionLinkCreate("Article", "Admin", "Create") %>
    </div>
    <div>
        <% base.Html.Telerik().Grid<ArticleModel>(base.Model)
                .Name("ListArticles")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Title).Title("Title");
                    columns.Bound(c => c.Id).Title("Actions").Template(template =>
                    {
        %>
        <%= base.Html.WebFramework().ActionLink().ActionLinkUpdate("Admin", "Edit", template.Id) %>
        <%
                    });
                })
                .Pageable()
                .Render();
        %>
    </div>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="HeadContent" runat="server">
    <% base.Html.WebFramework().WidgetHanlder().RegisterStyleSheets(); %>
</asp:Content>
