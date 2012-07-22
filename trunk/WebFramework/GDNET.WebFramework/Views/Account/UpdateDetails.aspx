<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<UpdateDetailsModel>" %>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Update membership information
</asp:Content>
<asp:Content ID="changePasswordSuccessContent" ContentPlaceHolderID="MainContent"
    runat="server">
    <h2>
        Update membership information
    </h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% Html.BeginForm(); %>
    <%: Html.ValidationSummary(true, "Account modification was unsuccessful. Please correct the errors and try again.") %>
    <div>
        <fieldset>
            <legend>Account Information</legend>
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
            <input type="submit" value="Submit Changes" />
        </p>
    </div>
    <% Html.EndForm(); %>
</asp:Content>
