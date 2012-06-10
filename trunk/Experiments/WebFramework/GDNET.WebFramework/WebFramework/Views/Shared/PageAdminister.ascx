<%@ Import Namespace="WebFramework.Widgets.Daskboard.ViewModels" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DaskboardPageModel>" %>
<div style="clear: both;">
</div>
<% if (base.Model.CanAdminister)
   {
%>
<div class="management_space">
    <a href="<%= base.Model.AdministerUrl %>">
        <%= WebFramework.Domain.DomainServices.Translation.Translate("SysTranslation.PageAdminister")%>
    </a>
</div>
<%
   } 
%>
