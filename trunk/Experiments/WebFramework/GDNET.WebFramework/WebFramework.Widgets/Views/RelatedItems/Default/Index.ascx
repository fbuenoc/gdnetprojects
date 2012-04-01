<%@ Import Namespace="WebFramework.Widgets.Models.RelatedItems" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<RelatedItemsModel>" %>
<%
    foreach (var itemModel in base.Model.RelatedItems)
    {
%>
<div>
    <%= base.Html.WebFramework().WidgetHanlder().ActionLinkContentItem(itemModel, base.Model.DetailConnection)%>
</div>
<%
    }
%>
