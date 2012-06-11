<%@ Import Namespace="WebFramework.Widgets.RecentArticlesAg" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<RecentArticlesModel>" %>
<div class="widget_container">
    <h3 class="title">
        <%= base.Model.Name %>
        <a name="<%= base.Model.IdRegion %>"></a>
    </h3>
    <ul class="no_style_type">
        <%
            int counter = 0;
            string itemCss = string.Empty;
            foreach (var articleModel in base.Model.ListArticles)
            {
                itemCss = ((counter++ % 2) == 0) ? "article_record_even" : "article_record_odd";
        %>
        <li class="<%= itemCss %>">
            <div>
                <a href="<%= articleModel.DetailLink %>">
                    <%= articleModel.Title %>
                </a>
            </div>
        </li>
        <%
            }
        %>
    </ul>
    <% base.Html.RenderPartial("WidgetAdminister", base.Model); %>
</div>
