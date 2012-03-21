<%@ Import Namespace="GDNET.Common.Helpers" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentAttributeModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SysTranslations.EntityContentAttribute %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().CreateOrUpdate<long>(base.Model) %>
    </h2>
    <div>
        <% base.Html.BeginForm(); %>
        <div>
            Content type:
            <%= base.Model.ContentType %>
        </div>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.Code)%>
        </div>
        <div>
            <%= base.Html.TextBoxFor(m => m.Code)%>
        </div>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.DataTypeId)%>
        </div>
        <div>
            <%= base.Html.DropDownListLV("LVH.ContentDataTypes", ExpressionAssistant.GetPropertyName(() => this.Model.DataTypeId) , base.Model.DataTypeId)%>
        </div>
        <p>
            <%= base.Html.HiddenFor(m => m.ContentTypeId) %>
            <input type="submit" value="<%= base.Html.WebFramework().SysTranslations.SaveAndContinue %>" />
        </p>
        <% base.Html.EndForm(); %>
    </div>
    <p>
        <%= base.Html.ActionLink("Return current Content Type", ContentAttributeController.ActionDetails, ControllerConstants.FrameworkContentTypeController, new { id = base.Model.ContentTypeId }, new { })%>
    </p>
</asp:Content>
