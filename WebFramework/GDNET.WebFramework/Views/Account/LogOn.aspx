<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LogOnModel>" %>

<asp:Content ID="LT" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal ID="L1" runat="server" Text="<%$ Trans:GUI.LogOnPage.Title %>" />
</asp:Content>
<asp:Content ID="LC" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="L2" runat="server" Text="<%$ Trans:GUI.LogOnPage.Header %>" />
    </h2>
    <p>
        <asp:Literal ID="L3" runat="server" Text="<%$ Trans:GUI.LogOnPage.Description1 %>" />
        <%: base.Html.ActionLinkTrans("GUI.LogOnPage.RegisterText", "Register", "Account", "GUI.LogOnPage.RegisterTooltip")%>
        <asp:Literal ID="L4" runat="server" Text="<%$ Trans:GUI.LogOnPage.Description2 %>" />
    </p>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% Html.BeginForm(); %>
    <%: Html.ValidationSummaryTrans(true, "GUI.LogOnPage.LoginError")%>
    <div>
        <fieldset>
            <legend>
                <asp:Literal ID="LA" runat="server" Text="<%$ Trans:GUI.LogOnPage.AccountInformation %>" />
            </legend>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.UserName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.UserName) %>
                <%: Html.ValidationMessageFor(m => m.UserName) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Password) %>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(m => m.Password) %>
                <%: Html.ValidationMessageFor(m => m.Password) %>
            </div>
            <div class="editor-label">
                <%: Html.CheckBoxFor(m => m.RememberMe) %>
                <%: Html.LabelFor(m => m.RememberMe) %>
            </div>
            <p>
                <input type="submit" value='<%: base.Html.Translate("GUI.LogOnPage.SubmitButton") %>' />
            </p>
        </fieldset>
    </div>
    <% Html.EndForm(); %>
</asp:Content>
