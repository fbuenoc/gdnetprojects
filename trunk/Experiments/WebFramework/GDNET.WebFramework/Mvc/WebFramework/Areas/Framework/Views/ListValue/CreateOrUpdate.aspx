<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ApplicationModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Applications
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Create or update
    </h2>
    <div>
        <% base.Html.BeginForm(); %>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.Name) %>
        </div>
        <div>
            <%= base.Html.TextBoxFor(m => m.Name)%>
        </div>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.Description)%>
        </div>
        <div>
            <%= base.Html.TextBoxFor(m => m.Description)%>
        </div>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.RootUrl)%>
        </div>
        <div>
            <%= base.Html.TextBoxFor(m => m.RootUrl)%>
        </div>
        <p>
            <input type="submit" value="Save & Continue" />
        </p>
        <% base.Html.EndForm(); %>
    </div>
    <p>
        <%= base.Html.ActionLink("Return Application management", RoleController.ActionList)%>
    </p>
</asp:Content>
