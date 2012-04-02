<%@ Import Namespace="WebFramework.Common.Framework.Base" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IModelWithModification>" %>
<table>
    <tr>
        <td width="100px">
            <%= base.Html.WebFramework().SystemTranslation().CreatedAt %>
        </td>
        <td>
            <%= base.Model.CreatedAt.ToStringEx() %>
        </td>
    </tr>
    <tr>
        <td>
            <%= base.Html.WebFramework().SystemTranslation().CreatedBy%>
        </td>
        <td>
            <%= base.Model.CreatedBy %>
        </td>
    </tr>
    <tr>
        <td>
            <%= base.Html.WebFramework().SystemTranslation().Statut %>
        </td>
        <td>
            <%= base.Model.ActualStatut %>
        </td>
    </tr>
</table>
