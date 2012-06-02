<%@ Import Namespace="WebFramework.Widgets.ArticleWg" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ArticleWidgetModel>" %>
<div>
    <%= base.Model.ListArticles[0].Title %>
    <a name="<%= base.Model.IdRegion %>"></a>
</div>
<div>
    <%= base.Model.ListArticles[0].Description %>
</div>
<div>
    <%= base.Model.ListArticles[0].FullContent %>
</div>
