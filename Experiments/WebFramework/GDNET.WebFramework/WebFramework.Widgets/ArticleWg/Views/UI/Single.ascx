<%@ Import Namespace="WebFramework.Widgets.ArticleWg" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ArticleWidgetModel>" %>
<div class="widget_container">
    <h3 class="title">
        <%= base.Model.ListArticles[0].Title %>
        <a name="<%= base.Model.IdRegion %>"></a>
    </h3>
    <div>
        <p>
            <%= base.Model.ListArticles[0].Description %>
        </p>
        <p>
            <%= base.Model.ListArticles[0].FullContent %>
        </p>
    </div>
    <% base.Html.RenderPartial("WidgetAdminister", base.Model); %>
</div>
