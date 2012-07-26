<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemModel>" %>

<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.Content" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create
    </h2>
    <% Html.BeginForm(); %>
    <%: Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.") %>
    <div>
        <fieldset>
            <legend>Content item details</legend>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(m => m.Name)%>
                <%: Html.ValidationMessageFor(m => m.Name)%>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Description)%>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(m => m.Description)%>
                <%: Html.ValidationMessageFor(m => m.Description)%>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(m => m.Keywords)%>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(m => m.Keywords)%>
                <%: Html.ValidationMessageFor(m => m.Keywords)%>
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
