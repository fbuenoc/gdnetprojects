<%@ Import Namespace="WebFramework.Common.Widgets" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WidgetModelBase>" %>
<% if (base.Html.FrameworkSecurity().CanManageWidget(base.Model.EntityInfo))
   {
%>
<div class="management_space">
    <%= base.Html.WebFramework().WidgetHanlder().ActionLinkAdminister(base.Model) %>
</div>
<%
   } 
%>
