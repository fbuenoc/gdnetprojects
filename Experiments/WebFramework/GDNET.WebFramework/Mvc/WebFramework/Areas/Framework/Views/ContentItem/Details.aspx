<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Content Item
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details of Content Item:
        <%= base.Model.Name %>
    </h2>
    <div>
        <div>
            Created at:
            <%= base.Model.CreatedAt.ToStringEx() %>
        </div>
        <div>
            Created by:
            <%= base.Model.CreatedBy %>
        </div>
        <div>
            Description:
            <%= base.Model.Description %>
        </div>
        <h3>
            Attributes
        </h3>
    </div>
    <p>
        <%= base.Html.ActionLink("Return Content Item management", ContentItemController.ActionList)%>
        <%= base.Html.ActionLink("Create other Content Item", ContentItemController.ActionCreate, ControllerConstants.FrameworkContentItemController, new { key = base.Model.ContentTypeId }, new { })%>
    </p>
</asp:Content>
