<%@ Import Namespace="GDNET.Web.Mvc.ComponentEditors" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<HtmlEditorComponent>" %>
<tr>
    <td valign="top">
        <%= base.Html.Label(base.Model.Name) %>
    </td>
    <td valign="top">
        <%= base.Html.Telerik().Editor().Name(base.Model.Name).Value(HttpUtility.HtmlDecode(base.Model.Value)) %>
    </td>
</tr>
