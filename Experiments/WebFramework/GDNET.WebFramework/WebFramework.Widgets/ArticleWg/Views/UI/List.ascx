<%@ Import Namespace="WebFramework.Widgets.ArticleWg" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ArticleWidgetModel>" %>
<div class="widget_container">
    <h3 class="title">
        <%= base.Model.Name %>
        <a name="<%= base.Model.IdRegion %>"></a>
    </h3>
    <ul>
        <%
            foreach (var articleModel in base.Model.ListArticles)
            {
        %>
        <li>
            <div>
                <%= articleModel.Title %>
            </div>
        </li>
        <%
            }
        %>
    </ul>
    <% base.Html.RenderPartial("WidgetAdminister", base.Model); %>
</div>
