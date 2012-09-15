<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<UpdateDetailsModel>" %>

<asp:Content ID="UDT" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate("GUI.Account.UpdateDetailPage.Title") %>
</asp:Content>
<asp:Content ID="UDC" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: base.Html.Translate("GUI.Account.UpdateDetailPage.Focus") %>
    </h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% Html.BeginForm(); %>
    <%: Html.ValidationSummary(true, "Account modification was unsuccessful. Please correct the errors and try again.") %>
    <div>
        <fieldset>
            <legend>
                <%: base.Html.Translate("GUI.Account.General.FieldSet.Legend") %>
            </legend>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.DisplayName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.DisplayName)%>
                <%: Html.ValidationMessageFor(m => m.DisplayName)%>
            </div>
            <div class="editor-field">
                <%: Html.CheckBoxFor(m => m.IsActive)%>
                <%: Html.LabelFor(m => m.IsActive) %>
            </div>
        </fieldset>
        <p>
            <input type="submit" value='<%: base.Html.Translate("GUI.Common.SubmitButton") %>' />
        </p>
    </div>
    <% Html.EndForm(); %>
</asp:Content>
