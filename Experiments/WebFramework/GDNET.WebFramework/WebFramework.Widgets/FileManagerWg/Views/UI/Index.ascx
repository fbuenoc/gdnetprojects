<%@ Import Namespace="WebFramework.Widgets.FileManagerWg" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FileManagerModel>" %>
<div class="widget_container">
    <h3 class="title">
        <%= base.Model.Name %>
        <a name="<%= base.Model.IdRegion %>"></a>
    </h3>
    <ul class="no_style_type">
        <%
            int counter = 0;
            string itemCss = string.Empty;
            foreach (var fileModel in base.Model.FileContents)
            {
                itemCss = ((counter++ % 2) == 0) ? "file_record_even" : "file_record_odd";
        %>
        <li class="<%= itemCss %>">
            <div class="div1">
                <div>
                    <%= fileModel.Title %>
                </div>
                <div>
                    <%= fileModel.Description %>
                </div>
            </div>
            <div class="div2">
                Download
            </div>
            <div style="clear: both;">
            </div>
        </li>
        <%
            }
        %>
    </ul>
    <% base.Html.RenderPartial("WidgetAdminister", base.Model); %>
</div>
