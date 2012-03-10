<%@ Import Namespace="WebFramework.ViewModels" %>
<%@ Import Namespace="WebFramework.Base.Helpers" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HomeViewModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Welcome
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Welcome
    </h2>
    <div>
        <ul>
            <%
                foreach (var productModel in base.Model.Products)
                {
            %>
            <li>
                <%= base.Html.HyperLink(productModel) %>
            </li>
            <%
                }
            %>
        </ul>
    </div>
</asp:Content>
