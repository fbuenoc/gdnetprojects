<%@ Import Namespace="GDNET.Web.Mvc.ComponentEditors" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TextBoxEditorComponent>" %>
<tr>
    <td valign="top">
        <%= base.Html.Label(base.Model.Name) %>
    </td>
    <td valign="top">
        <%= base.Html.GDNet().TextBox(base.Model.Name, base.Model.Value, base.Model.IsEnabled)%>
    </td>
</tr>
