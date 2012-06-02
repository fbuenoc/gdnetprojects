<%@ Import Namespace="WebFramework.Widgets.FileManagerWg" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FileManagerModel>" %>
<div class="widget_container">
    <h3 class="title">
        <%= base.Model.Name %>
        <a name="<%= base.Model.IdRegion %>"></a>
    </h3>
    <ul>
        <%
            foreach (var fileModel in base.Model.FileContents)
            {
        %>
        <li>
            <div>
                <%= fileModel.Title %>
            </div>
            <div>
                <%= fileModel.Description %>
            </div>
            <div>
                Download
            </div>
        </li>
        <%
            }
        %>
    </ul>
    <% base.Html.RenderPartial("WidgetAdminister", base.Model); %>
</div>
