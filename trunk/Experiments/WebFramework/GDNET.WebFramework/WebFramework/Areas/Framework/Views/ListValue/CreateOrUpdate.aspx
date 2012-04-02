<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ListValueModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SystemTranslation().EntityListValue %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().CreateOrUpdate<long>(base.Model) %>
    </h2>
    <div>
        <% base.Html.BeginForm(); %>
        <div>
            <%= base.Html.LabelFor(m => m.Parent)%>:
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
            <%= base.Html.LabelFor(m => m.Detail)%>
        </div>
        <div>
            <%= base.Html.TextAreaFor(m => m.Detail, new { @class = "desc" }) %>
        </div>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.CustomValue)%>
        </div>
        <div>
            <%= base.Html.TextBoxFor(m => m.CustomValue)%>
        </div>
        <p>
            <%= base.Html.HiddenFor(m => m.ParentId) %>
            <input type="submit" name="btnOK" value="<%= base.Html.WebFramework().SystemTranslation().SaveAndContinue %>" />
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
