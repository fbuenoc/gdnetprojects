<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Details informations
</asp:Content>
<asp:Content ID="changePasswordSuccessContent" ContentPlaceHolderID="MainContent"
    runat="server">
    <div>
        <%: base.Html.ActionLink("Change password", "ChangePassword")%>
    </div>
    <div>
        <%: base.Html.ActionLink("Update details", "UpdateDetails")%>
    </div>
    <div>
        <%: base.Html.ActionLink("Add new content", "Create", "ContentAdmin")%>
    </div>
</asp:Content>
