<%@ Import Namespace="WebFramework.Widgets.HtmlContentWg" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HtmlContentModel>" %>
<div class="widget_container">
    <h3 class="title">
        <%= base.Model.Name %>
        <a name="<%= base.Model.IdRegion %>"></a>
    </h3>
    <%
        var contentHtml = (base.Model.IsOverWeight) ? base.Model.HtmlContentCalculated : base.Model.HtmlContent;
    %>
    <div>
        <%= HttpUtility.HtmlDecode(contentHtml) %>
    </div>
    <%
        if (base.Model.IsOverWeight)
        {
    %>
    <div>
        <%= base.Html.WebFramework().WidgetHanlder().ActionLinkShowMore(base.Model.DetailConnection) %>
    </div>
    <%
        }
    %>
    <% base.Html.RenderPartial("WidgetAdminister", base.Model); %>
</div>
