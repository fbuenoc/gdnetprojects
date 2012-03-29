<%@ Import Namespace="WebFramework.Widgets.Models.HtmlContent" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HtmlContentModel>" %>
<div>
    <h3>
        <%= base.Model.Name %>
    </h3>
    <p>
        <%= base.Model.HtmlContentCalculated %>
    </p>
    <%
        if (base.Model.IsOverWeight)
        {
    %>
    <p>
    </p>
    <%
        }
    %>
</div>
