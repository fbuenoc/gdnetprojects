<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<ContentItemModel>>" %>

<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.Content" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    List of content items
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List
    </h2>
    <%
        List<string> columns = new List<string>() { "Name" };
        string repeaterHtml = base.Html.Repeater(base.Model.ToList(), columns);        
    %>
    <div id="repeater_content_items">
        <%= repeaterHtml %>
    </div>
</asp:Content>
