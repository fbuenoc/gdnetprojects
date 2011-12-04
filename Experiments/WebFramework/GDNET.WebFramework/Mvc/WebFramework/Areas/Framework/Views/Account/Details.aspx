<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AccountModel>" %>

<%@ Import Namespace="WebFramework.Areas.Framework.Controllers" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Accounts
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details
    </h2>
    <p>
        Email:
        <%= base.Model.Email %>
        <br />
        Username:
        <%= base.Model.UserName %>
        <br />
        Creation date:
        <%= base.Model.CreationDate.ToStringEx() %>
    </p>
    <div>
        <%= base.Html.ActionLink("Return Account management", AccountController.ActionList) %>
    </div>
</asp:Content>
