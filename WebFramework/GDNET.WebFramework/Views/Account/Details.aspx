<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="ADT" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate("GUI.Account.Details.Title") %>
</asp:Content>
<asp:Content ID="ADC" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ym-col1">
        <div class="ym-cbox">
            <p>
                <%: base.Html.ActionLinkTrans("GUI.Account.Details.ChangePassword", "ChangePassword") %>
            </p>
            <p>
                <%: base.Html.ActionLinkTrans("GUI.Account.Details.UpdateDetails", "UpdateDetails") %>
            </p>
            <fieldset>
                <legend>
                    <%: base.Html.Translate("GUI.Account.Details.ContentAdmin.Legend")%>
                </legend>
                <p>
                    <%: base.Html.ActionLinkTrans("GUI.Account.Details.ContentAdmin.ListeContent", "List", "ContentAdmin")%>
                </p>
                <p>
                    <%: base.Html.ActionLinkTrans("GUI.Account.Details.AddContent", "Create", "ContentAdmin")%>
                </p>
            </fieldset>
        </div>
    </div>
</asp:Content>
