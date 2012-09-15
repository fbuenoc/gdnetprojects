<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RegisterModel>" %>

<asp:Content ID="REG" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate("GUI.RegisterPage.Title") %>
</asp:Content>
<asp:Content ID="REGC" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: base.Html.Translate("GUI.RegisterPage.Header") %>
    </h2>
    <p>
        <%: base.Html.Translate("GUI.RegisterPage.Description", Membership.MinRequiredPasswordLength)%>
    </p>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% Html.BeginForm(); %>
    <%: Html.ValidationSummaryTrans(true, "GUI.RegisterPage.RegisterError")%>
    <div>
        <fieldset>
            <legend>
                <asp:Literal ID="LA" runat="server" Text="<%$ Trans:GUI.RegisterPage.AccountInformation %>" />
            </legend>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Email) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Email) %>
                <%: Html.ValidationMessageFor(m => m.Email) %>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Password) %>
            </div>
            <div class="editor-field">
                <%: Html.PasswordFor(m => m.Password) %>
                <%: Html.ValidationMessageFor(m => m.Password) %>
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
