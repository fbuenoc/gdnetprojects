<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="ADT" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate("GUI.Account.Details.Title") %>
</asp:Content>
<asp:Content ID="ADC" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%: base.Html.ActionLinkTrans("GUI.Account.Details.ChangePassword", "ChangePassword") %>
    </p>
    <p>
        <%: base.Html.ActionLinkTrans("GUI.Account.Details.UpdateDetails", "UpdateDetails") %>
    </p>
    <p>
        <%: base.Html.ActionLinkTrans("GUI.Account.Details.AddContent", "Create", "ContentAdmin")%>
    </p>
</asp:Content>
