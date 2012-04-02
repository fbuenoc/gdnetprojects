<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SystemTranslation().EntityContentItem %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().SystemTranslation().DetailOfXYZ(base.Model.Name) %>
    </h2>
    <div>
        <div>
            <% base.Html.RenderPartial("InfoModificationControl", base.Model); %>
        </div>
        <br />
        <div>
            <h3>
                <%= base.Html.WebFramework().SystemTranslation().Description %>
            </h3>
            <div>
                <%= base.Model.Description %>
            </div>
        </div>
        <h3>
            <%= base.Html.WebFramework().SystemTranslation().Attributes %>
        </h3>
        <%
            foreach (var attributeValue in base.Model.AttributesValue)
            {
        %>
        <div>
            <h4>
                <%= attributeValue.ContentAttribute.Name %>
            </h4>
        </div>
        <div>
            <%= base.Html.WebFramework().ActionLink().ActionLinkUpdateValue(attributeValue) %>
        </div>
        <div>
            <%= HttpUtility.HtmlDecode(attributeValue.Value) %>
        </div>
        <%
            }
        %>
    </div>
    <p>
        <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.ContentItem) %>
        <%= base.Html.ActionLink(base.Html.WebFramework().SystemTranslation().ReturnToListOfXYZ(base.Html.WebFramework().SystemTranslation().EntityContentItem), ContentItemController.ActionList)%>
        <%= base.Html.ActionLink("Create other Content Item", ContentItemController.ActionCreate, WebFrameworkConstants.Controllers.FrameworkContentItem, new { key = base.Model.ContentType.Id }, new { })%>
    </p>
</asp:Content>
