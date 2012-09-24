<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LogOnModel>" %>

<asp:Content ID="LT" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal ID="L1" runat="server" Text="<%$ Trans:GUI.LogOnPage.Title %>" />
</asp:Content>
<asp:Content ID="LC" ContentPlaceHolderID="MainContent" runat="server">
    <div class="block">
        <div class="block-left">
            <div style="padding-top: 10px;">
                <%
                    string registerLink = base.Html.ActionLinkTrans("GUI.LogOnPage.RegisterText", "Register", "Account", "GUI.LogOnPage.RegisterTooltip").ToHtmlString();
                %>
                <%: base.Html.Translate("GUI.LogOnPage.Description", registerLink) %>
            </div>
        </div>
        <div class="block-right">
            <h2>
                <asp:Literal ID="L2" runat="server" Text="<%$ Trans:GUI.LogOnPage.Header %>" />
            </h2>
            <% base.Html.BeginForm(); %>
            <%: base.Html.ValidationSummaryTrans(true, "GUI.LogOnPage.LoginError") %>
            <fieldset>
                <legend>
                    <asp:Literal ID="LA" runat="server" Text="<%$ Trans:GUI.LogOnPage.AccountInformation %>" />
                </legend>
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.UserName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserName) %>
                </div>
                <div>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Password) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.Password) %>
                </div>
                <div>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </div>
                <div class="editor-label">
                    <%: Html.CheckBoxFor(m => m.RememberMe) %>
                    <%: Html.LabelFor(m => m.RememberMe) %>
                </div>
                <p>
                    <input type="submit" value='<%: base.Html.Translate("GUI.Common.SubmitButton") %>' />
                </p>
            </fieldset>
            <% base.Html.EndForm(); %>
        </div>
    </div>
</asp:Content>
