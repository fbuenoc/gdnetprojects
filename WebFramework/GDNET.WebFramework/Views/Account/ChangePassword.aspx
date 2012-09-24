﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ChangePasswordModel>" %>

<asp:Content ID="CPT" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate("GUI.Account.ChangePassword.Title")%>
</asp:Content>
<asp:Content ID="CPC" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: base.Html.Translate("GUI.Account.ChangePassword.Focus")%>
    </h2>
    <p>
        <%: base.Html.Translate("GUI.Account.ChangePassword.Description",Membership.MinRequiredPasswordLength) %>
    </p>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% Html.BeginForm(); %>
    <%: Html.ValidationSummaryTrans(true, "GUI.Account.ChangePassword.Error")%>
    <div>
        <fieldset>
            <legend>
                <asp:Literal ID="LA" runat="server" Text="<%$ Trans:GUI.Account.ChangePassword.AccountInformation %>" />
            </legend>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.OldPassword) %>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(m => m.OldPassword) %>
                <%: Html.ValidationMessageFor(m => m.OldPassword) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.NewPassword) %>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(m => m.NewPassword) %>
                <%: Html.ValidationMessageFor(m => m.NewPassword) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.ConfirmPassword) %>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
            </div>
            <p>
                <input type="submit" value='<%: base.Html.Translate("GUI.Common.SubmitButton") %>' />
            </p>
        </fieldset>
    </div>
    <% Html.EndForm(); %>
</asp:Content>