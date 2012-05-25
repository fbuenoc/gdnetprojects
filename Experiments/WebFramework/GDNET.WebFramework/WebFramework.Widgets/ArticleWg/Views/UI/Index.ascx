<%@ Import Namespace="WebFramework.Widgets.ArticleWg" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ArticleWidgetModel>" %>
<div>
    <%
        foreach (var articleModel in base.Model.ListArticles)
        {
    %>
    <div>
        <%= articleModel.Title %>
    </div>
    <%
        }
    %>
</div>
