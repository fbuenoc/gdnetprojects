<%@ Import Namespace="GDNET.Web.Mvc.ComponentEditors" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<NumberEditorComponent>" %>
<tr>
    <td valign="top">
        <%= base.Html.Label(base.Model.Name) %>
    </td>
    <td valign="top">
        <%= base.Html.Telerik().NumericTextBox().Name(base.Model.Name).Value(base.Model.Value) %>
    </td>
</tr>
