<%@ Import Namespace="WebFramework.Common.Framework.System" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PageModel>" %>
<div style="clear: both;">
</div>
<% if (base.Html.FrameworkSecurity().CanManagePage(base.Model.EntityInfo))
   {
%>
<div class="management_space">
    <a href="<%= base.Model.AdministerUrl %>">
        <%= WebFramework.Domain.DomainServices.Translation.Translate("SysTranslation.PageAdminister")%>
    </a>
    <%--<%= base.Html.WebFramework().WidgetHanlder().ActionLinkAdminister(base.Model) %>--%>
</div>
<%
   } 
%>
