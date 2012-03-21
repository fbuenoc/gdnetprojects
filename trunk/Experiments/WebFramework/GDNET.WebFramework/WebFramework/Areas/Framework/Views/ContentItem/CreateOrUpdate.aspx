<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Translations.EntityNames.ContentItem %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().CreateOrUpdate<long>(base.Model) %>
    </h2>
    <h3>
        <%= Translations.ContentItem.InContentTypeXYZ(base.Model.ContentType)%>
    </h3>
    <div>
        <% base.Html.BeginForm(); %>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.Name) %>
        </div>
        <div>
            <%= base.Html.TextBoxFor(m => m.Name) %>
        </div>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.Description) %>
        </div>
        <div>
            <%= base.Html.TextAreaFor(m => m.Description, new { @class = "desc" }) %>
        </div>
        <h3>
            <%= Translations.System.Attributes %>
        </h3>
        <%
            foreach (var attribute in base.Model.Attributes)
            {
        %>
        <div class="editor-label">
            <%= attribute.Name %>
        </div>
        <div>
            <%= base.Html.TextBox(attribute.Code, string.Empty) %>
        </div>
        <%
            }
        %>
        <p>
            <%= base.Html.HiddenFor(m => m.ContentTypeId) %>
            <input type="submit" name="btnOK" value="<%= base.Html.WebFramework().SysTranslations.SaveAndContinue %>" />
        </p>
        <% base.Html.EndForm(); %>
    </div>
    <p>
        <%= base.Html.ActionLink("Return Content Item management", ContentItemController.ActionList)%>
        <%= base.Html.ActionLink("Return current Content Type", ContentTypeController.ActionDetails, ControllerConstants.FrameworkContentTypeController, new { id = base.Model.ContentTypeId }, new { })%>
    </p>
</asp:Content>
