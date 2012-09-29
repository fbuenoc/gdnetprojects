<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ChangeLanguageModel>" %>

<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.My" %>
<%@ Import Namespace="GDNET.Domain.Entities.System.ReferenceData" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal ID="L1" runat="server" Text="<%$ Trans:GUI.My.ChangeLanguage.Title %>" />
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MetaContent" runat="server">
    <% base.Html.RenderPartial("PageMetaUserControl", base.Model.PageMeta); %>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="block">
        <% Html.BeginForm(); %>
        <fieldset>
            <legend>
                <asp:Literal ID="LA" runat="server" Text="<%$ Trans:GUI.My.ChangeLanguage.Legend %>" />
            </legend>
            <div class="editor-line">
                <div class="editor-label-admin">
                    <%: base.Html.Translate("GUI.My.ChangeLanguage.LanguageUI")%>
                </div>
                <div class="editor-field-admin">
                    <%: base.Html.DropDownListFor(m => m.UserCustomizedInformation.LanguageUI, SystemCatalogs.Languages)%>
                </div>
            </div>
            <div class="editor-line">
                <div class="editor-label-admin">
                    <%: base.Html.Translate("GUI.My.ChangeLanguage.Language")%>
                </div>
                <div class="editor-field-admin">
                    <%: base.Html.DropDownListFor(m => m.UserCustomizedInformation.Language, SystemCatalogs.Languages, true, true)%>
                </div>
            </div>
            <div class="editor-line">
                <p>
                    <input type="submit" value='<%: base.Html.Translate("GUI.Common.SubmitButton") %>' />
                </p>
            </div>
        </fieldset>
        <% Html.EndForm(); %>
    </div>
</asp:Content>
