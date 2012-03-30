<%@ Import Namespace="WebFramework.Widgets.Models.HtmlContent" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HtmlContentModel>" %>
<div>
    <h3>
        <%= base.Model.Name %>
    </h3>
    <%
        var contentHtml = (base.Model.IsOverWeight) ? base.Model.HtmlContentCalculated : base.Model.HtmlContent;
    %>
    <p>
        <%= contentHtml %>
    </p>
    <%
        if (base.Model.IsOverWeight)
        {
    %>
    <p>
        <%= base.Html.WebFramework().WidgetHanlder().ActionLinkShowMore(base.Model.DetailConnection) %>
    </p>
    <%
        }
    %>
</div>
