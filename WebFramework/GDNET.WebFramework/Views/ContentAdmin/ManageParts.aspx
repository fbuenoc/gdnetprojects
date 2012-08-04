<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemPartsModel>" %>

<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.Content" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    ManageParts
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        ManageParts (<%: base.Model.PartsCount %>)
    </h2>
    <div>
        <%: base.Html.ActionLinkWithId("New part", "CreatePart", base.Model.Id.ToString()) %>
    </div>
</asp:Content>
