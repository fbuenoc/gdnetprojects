<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemModel>" %>

<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.Content" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate("GUI.DetailsPage.Title", base.Model.Name) %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <%= base.Model.Name %>
    </p>
    <p>
        <%= base.Model.Description %>
    </p>
    <p>
        <%= base.Model.Keywords %>
    </p>
    <%
        var repeater = RepeaterAssistant.Create<ContentPartModel>("item_parts").AddEntities(base.Model.Parts);
        repeater.AddColumns("Name", "Details").EnableHeader(false);
    %>
    <%= repeater.GenerateHtml() %>
</asp:Content>
