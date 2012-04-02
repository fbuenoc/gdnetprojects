<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentTypeModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SystemTranslation().EntityContentType %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().SystemTranslation().DetailOfXYZ(base.Model.Name)%>
    </h2>
    <div>
        <% base.Html.RenderPartial("InfoModificationControl", base.Model); %>
    </div>
    <br />
    <h3>
        Attributes
    </h3>
    <div>
        <% base.Html.Telerik().Grid<ContentAttributeModel>(base.Model.Attributes)
                .Name("Attributes")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Code).Title("Code");
                    columns.Bound(c => c.DataType).Title("Data type");
                    columns.Bound(c => c.Id).Title("Actions").Template(template =>
                    {
        %>
        <%= base.Html.ActionLink("Details", "Details", WebFrameworkConstants.Controllers.FrameworkContentAttribute, new { id = template.Id }, new { })%>
        <%= base.Html.ActionLink("Edit", "Edit", WebFrameworkConstants.Controllers.FrameworkContentAttribute, new { id = template.Id }, new { })%>
        <%= base.Html.ActionLink("Delete", "Delete", WebFrameworkConstants.Controllers.FrameworkContentAttribute, new { id = template.Id }, new { })%>
        <%
                    });
                })
                .Pageable()
                .Render();
        %>
    </div>
    <p>
        <%= base.Html.WebFramework().ActionLink().ActionListLink(ListType.ContentTypes) %>
        <%= base.Html.ActionLink("Return Content Type management", ContentTypeController.ActionList)%>
        <%= base.Html.ActionLink("Add new Attribute", ContentAttributeController.ActionCreate, WebFrameworkConstants.Controllers.FrameworkContentAttribute, new { key = base.Model.Id }, new { })%>
        <%= base.Html.ActionLink("Add new Content Item", ContentItemController.ActionCreate, WebFrameworkConstants.Controllers.FrameworkContentItem, new { key = base.Model.Id }, new { })%>
    </p>
</asp:Content>
