<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserDetailsModel>" %>
<%@ Import Namespace="GDNET.FrameworkInfrastructure.Common.Models" %>
<div class="clear">
    <div class="info_label">
        <%: base.Html.Translate("GUI.User.DisplayName")%>
    </div>
    <div class="info_value">
        <%: base.Model.DisplayName %>
    </div>
</div>
<%
    if (base.Model.DisplayMode == UserDetailsMode.Medium)
    {
%>
<div class="clear">
    <div class="info_label">
        <%: base.Html.Translate("GUI.User.CreatedDate")%>
    </div>
    <div class="info_value">
        <%: base.Model.CreatedAt.ToShortDateString() %>
    </div>
</div>
<%
    }
%>
<div class="clear">
    <div class="info_label">
        <%: base.Html.Translate("GUI.User.Introduction")%>
    </div>
    <div class="info_value">
        <%= base.Model.Introduction %>
    </div>
</div>
