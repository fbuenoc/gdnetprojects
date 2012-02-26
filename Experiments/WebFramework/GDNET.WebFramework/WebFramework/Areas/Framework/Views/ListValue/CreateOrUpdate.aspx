<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ListValueModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Applications
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= TranslationAssistant.CreateOrUpdate<long>(base.Model) %>
    </h2>
    <div>
        <% base.Html.BeginForm(); %>
        <div>
            Parent value:
            <%= base.Model.Parent %>
        </div>
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
            <%= base.Html.LabelFor(m => m.CustomValue)%>
        </div>
        <div>
            <%= base.Html.TextBoxFor(m => m.CustomValue)%>
        </div>
        <p>
            <%= base.Html.HiddenFor(m => m.ParentId) %>
            <input type="submit" value="Save & Continue" />
        </p>
        <% base.Html.EndForm(); %>
    </div>
    <p>
        <%= base.Html.ActionLink("Return List Value management", RoleController.ActionList)%>
        <% if (base.Model.ParentId != 0)
           {
        %>
        <%= base.Html.ActionLink("Return " + base.Model.Parent, ListValueController.ActionDetails, new { id = base.Model.ParentId }) %>
        <%
           }
        %>
    </p>
</asp:Content>
