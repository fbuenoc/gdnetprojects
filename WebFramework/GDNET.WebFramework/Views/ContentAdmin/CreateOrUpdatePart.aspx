<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentPartModel>" %>

<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.Content" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate(base.Model.IsCreation ? "GUI.ContentAdmin.ContentPart.Title.Creation" : "GUI.ContentAdmin.ContentPart.Title.Modification")%>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MetaContent" runat="server">
    <script type="text/javascript" src="/ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%: base.Html.Translate(base.Model.IsCreation ? "GUI.ContentAdmin.ContentPart.Focus.Creation" : "GUI.ContentAdmin.ContentPart.Focus.Modification")%>
    </h2>
    <% Html.BeginForm(); %>
    <%: Html.ValidationSummaryTrans(true, "GUI.ContentAdmin.ContentPart.ValidationSummary")%>
    <div>
        <fieldset>
            <legend>
                <%: base.Html.Translate("GUI.ContentAdmin.ContentPart.Info")%>
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
                    <%: Html.LabelFor(m => m.Details)%>
                </div>
                <div class="editor-field-admin">
                    <%: Html.TextAreaFor(m => m.Details, "ckeditor textarea_content")%>
                    <%: Html.ValidationMessageFor(m => m.Details)%>
                </div>
            </div>
            <div class="editor-line">
                <div class="editor-field-admin">
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
