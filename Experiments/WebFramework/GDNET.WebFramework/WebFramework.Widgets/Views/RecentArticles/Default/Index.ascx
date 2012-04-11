<%@ Import Namespace="WebFramework.Business" %>
<%@ Import Namespace="WebFramework.Widgets.Models.RecentArticles" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<RecentArticlesModel>" %>
<div class="widget_container">
    <h3 class="title">
        <%= base.Model.Name %>
    </h3>
    <table cellpadding="0" cellspacing="0" width="100%">
        <%
            foreach (var articleModel in base.Model.Articles)
            {
        %>
        <tr>
            <td>
                <%= base.Html.WebFramework().WidgetHanlder().ActionLinkContentItem(articleModel, base.Model.DetailConnection) %>
                <%
                if (base.Model.ViewOption == ViewOption.WithDescription)
                {
                %>
                <div class="">
                    <%= articleModel.Description %>
                </div>
                <%
                }
                %>
            </td>
        </tr>
        <%
            }
        %>
    </table>
    <div class="management_space">
        <%= base.Html.WebFramework().WidgetHanlder().ActionLinkAdminister(base.Model) %>
    </div>
</div>
