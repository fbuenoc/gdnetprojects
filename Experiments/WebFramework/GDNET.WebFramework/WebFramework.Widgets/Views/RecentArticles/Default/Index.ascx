<%@ Import Namespace="WebFramework.Business" %>
<%@ Import Namespace="WebFramework.Widgets.Models.RecentArticles" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<RecentArticlesModel>" %>
<table>
    <%
        foreach (var articleModel in base.Model.Articles)
        {
    %>
    <tr>
        <td>
            <%= base.Html.WebFramework().WidgetHanlder().ActionLinkContentItem(articleModel, base.Model.DetailConnection) %>
        </td>
    </tr>
    <%
        }
    %>
</table>
