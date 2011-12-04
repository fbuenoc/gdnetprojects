<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AccountRoleModel>" %>

<%@ Import Namespace="WebFramework.Areas.Framework.Controllers" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Add user to a Role
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Add user to role: (<%= base.Model.RoleName %>)
    </h2>
    <div>
        <% base.Html.BeginForm(); %>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.UserName) %>
        </div>
        <div>
            <%= base.Html.TextBoxFor(m => m.UserName, new { style="width: 450px;" })%>
        </div>
        <p>
            <input type="submit" value="Save & Continue" />
        </p>
        <%= base.Html.HiddenFor(m => m.RoleName) %>
        <% base.Html.EndForm(); %>
    </div>
    <p>
        <%= base.Html.ActionLink("Return Role management", RoleController.ActionList)%>
    </p>
</asp:Content>
