<%@ Import Namespace="WebFramework.Widgets.FileManagerWg" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FileManagerModel>" %>
<div class="widget_container">
    <h3 class="title">
        <%= base.Model.Name %>
        <a name="<%= base.Model.IdRegion %>"></a>
    </h3>
    <%
        foreach (var fileModel in base.Model.FileContents)
        {
    %>
    <div>
        <%= fileModel.Name %>
    </div>
    <div>
        <%= fileModel.Description %>
    </div>
    <%
        }
    %>
    <% base.Html.RenderPartial("WidgetAdminister", base.Model); %>
</div>
