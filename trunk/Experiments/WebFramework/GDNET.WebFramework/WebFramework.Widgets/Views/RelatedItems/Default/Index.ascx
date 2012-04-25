<%@ Import Namespace="WebFramework.Widgets.Models.RelatedItems" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<RelatedItemsModel>" %>
<div>
    <a name="<%= base.Model.IdRegion %>"></a>
    <table>
        <%
            foreach (var itemModel in base.Model.RelatedItems)
            {
        %>
        <tr>
            <td>
                <%= base.Html.WebFramework().WidgetHanlder().ActionLinkContentItem(itemModel, base.Model.DetailConnection)%>
            </td>
        </tr>
        <%
            }
        %>
    </table>
    <div>
        <%= base.Html.WebFramework().WidgetHanlder().ActionLinkAdminister(base.Model) %>
    </div>
</div>
