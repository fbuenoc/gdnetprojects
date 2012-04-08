<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<RegionModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SystemTranslation().EntityRegion %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().SystemTranslation().DetailOfXYZ(base.Model.Name)%>
    </h2>
    <div>
        <% base.Html.RenderPartial("InfoModificationControl", base.Model); %>
    </div>
    <p>
        <%= base.Html.WebFramework().ActionLink().ActionDetailLink(EntityType.Zone, new { id = base.Model.Zone.Id }, "Zone Details")%>
    </p>
</asp:Content>
