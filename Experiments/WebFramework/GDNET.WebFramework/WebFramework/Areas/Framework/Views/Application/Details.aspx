<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ApplicationModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SystemTranslation().EntityApplication %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().SystemTranslation().DetailOfXYZ(base.Model.Name)%>
    </h2>
    <p>
        <%= base.Model.Description %>
    </p>
    <div>
        <% base.Html.RenderPartial("InfoModificationControl", base.Model); %>
    </div>
    <div>
        <%= base.Html.WebFramework().SystemTranslation().Category %>:
        <%= base.Model.Category %>
    </div>
    <p>
        <%= base.Html.WebFramework().ActionLink().ActionListLink(EntityType.Application) %>
    </p>
</asp:Content>
