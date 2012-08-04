<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentPartModel>" %>

<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.Content" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Part
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create
    </h2>
    <% Html.BeginForm(); %>
    <%: Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.") %>
    <div>
        <fieldset>
            <legend>Content part details</legend>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Name)%>
                <%: Html.ValidationMessageFor(m => m.Name)%>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Details)%>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(m => m.Details)%>
                <%: Html.ValidationMessageFor(m => m.Details)%>
            </div>
            <div class="editor-field">
                <%: Html.CheckBoxFor(m => m.IsActive)%>
                <%: Html.LabelFor(m => m.IsActive) %>
            </div>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>
    </div>
    <% Html.EndForm(); %>
</asp:Content>
