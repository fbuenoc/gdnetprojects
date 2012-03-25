<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<ContentItemModel>>" %>
<table>
    <%
        foreach (var articleModel in base.Model)
        {
    %>
    <tr>
        <td>
            <%= base.Html.WebFramework().HyperLink(articleModel)%>
        </td>
    </tr>
    <%
        }
    %>
</table>
