<%@ Import Namespace="WebFramework.Business" %>
<%@ Import Namespace="WebFramework.Widgets.Models.RecentArticles" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<RecentArticlesModel>" %>
<div class="widget_container">
    <h3 class="title">
        <%= base.Model.Name %>
        <a name="<%= base.Model.IdRegion %>"></a>
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
                <div class="w_retar_desc">
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
    <% base.Html.RenderPartial("WidgetAdminister", base.Model); %>
</div>
