<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemAttributeValueModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    CreateOrUpdate
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().Translation().CreateOrUpdate<long>(base.Model) %>
    </h2>
    <% base.Html.BeginForm(); %>
    <h4>
        <%= base.Model.ContentAttribute.Name %>
    </h4>
    <div>
        <% base.Html.WebFramework().TextEditor().RenderEditorComponent(base.Model, true); %>
    </div>
    <p>
        <input type="submit" name="btnOK" value="<%= base.Html.WebFramework().SystemTranslation().SaveAndContinue %>" />
    </p>
    <% base.Html.EndForm(); %>
</asp:Content>
