<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemModel>" %>

<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.Content" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate(base.Model.IsCreation ? "GUI.ContentAdmin.ContentItem.Title.Creation" : "GUI.ContentAdmin.ContentItem.Title.Modification")%>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: base.Html.Translate(base.Model.IsCreation ? "GUI.ContentAdmin.ContentItem.Focus.Creation" : "GUI.ContentAdmin.ContentItem.Focus.Modification")%>
    </h2>
    <% Html.BeginForm(); %>
    <%: Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.") %>
    <div>
        <fieldset>
            <legend>
                <%: base.Html.Translate("GUI.ContentAdmin.ContentItem.Info")%>
            </legend>
            <div class="editor-line">
                <div class="editor-label-admin">
                    <%: Html.LabelFor(m => m.Name) %>
                </div>
                <div class="editor-field-admin">
                    <%: Html.TextBoxFor(m => m.Name, "input_name")%>
                    <%: Html.ValidationMessageFor(m => m.Name)%>
                </div>
            </div>
            <div class="editor-line">
                <div class="editor-label-admin">
                    <%: Html.LabelFor(m => m.Description)%>
                </div>
                <div class="editor-field-admin">
                    <%: Html.TextAreaFor(m => m.Description, "textarea_content")%>
                    <%: Html.ValidationMessageFor(m => m.Description)%>
                </div>
            </div>
            <div class="editor-line">
                <div class="editor-label-admin">
                    <%: Html.LabelFor(m => m.Keywords)%>
                </div>
                <div class="editor-field-admin">
                    <%: Html.TextAreaFor(m => m.Keywords, "textarea_tiny")%>
                    <%: Html.ValidationMessageFor(m => m.Keywords)%>
                </div>
            </div>
            <div class="editor-line">
                <div class="editor-field">
                    <%: Html.CheckBoxFor(m => m.IsActive)%>
                    <%: Html.LabelFor(m => m.IsActive) %>
                </div>
            </div>
            <div class="editor-line">
                <p>
                    <input type="submit" value='<%: base.Html.Translate("GUI.Common.SubmitButton") %>' />
                </p>
            </div>
        </fieldset>
    </div>
    <% Html.EndForm(); %>
</asp:Content>
