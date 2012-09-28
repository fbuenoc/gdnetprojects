<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<div>
    <div style="float: right;">
        <%
            if (base.Request.IsAuthenticated)
            {
        %>
        <%: base.Html.Translate("GUI.LogOn.Welcome", base.Page.User.Identity.Name) %>
        [
        <%: Html.ActionLinkTrans("GUI.LogOn.Details", "Details", "Account") %>
        <%: Html.ActionLinkTrans("GUI.LogOn.LogOff", "LogOff", "Account") %>
        ]
        <%
            }
            else
            {
        %>
        [
        <%: Html.ActionLinkTrans("GUI.LogOn.LogOn", "LogOn", "Account")%>
        ]
        <%
            }
        %>
    </div>
    <div style="float: right; margin-right: 10px;">
        <%: base.Html.GetUserCustomizedLanguageName() %>
        [
        <%: base.Html.ActionLinkTrans("GUI.UserCustomizedInformation.ChangeLanguage", "ChangeLanguage", "My")%>
        ]
    </div>
</div>
