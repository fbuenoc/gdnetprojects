<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (base.Request.IsAuthenticated)
    {
%>
Welcome <strong>
    <%: base.Page.User.Identity.Name%></strong>
<br />
[
<%: Html.ActionLink("Details", "Details", "Account")%>
<%: Html.ActionLink("Log Off", "LogOff", "Account") %>
]
<%
    }
    else
    {
%>
[
<%: Html.ActionLink("Log On", "LogOn", "Account") %>
]
<%
    }
%>
