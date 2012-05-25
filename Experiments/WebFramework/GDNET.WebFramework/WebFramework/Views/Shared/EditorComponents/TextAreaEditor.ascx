<%@ Import Namespace="GDNET.Web.Mvc.ComponentEditors" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TextAreaEditorComponent>" %>
<tr>
    <td valign="top">
        <%= base.Html.Label(base.Model.Name) %>
    </td>
    <td valign="top">
        <%= base.Html.GDNet().TextArea(base.Model.Name, base.Model.Value, base.Model.IsEnabled, new { @class = "editor_textarea" }) %>
    </td>
</tr>
