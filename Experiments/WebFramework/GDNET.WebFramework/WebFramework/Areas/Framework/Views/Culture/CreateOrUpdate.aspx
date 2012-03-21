<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CultureModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Culture
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().CreateOrUpdate<int>(base.Model) %>
    </h2>
    <div>
        <% base.Html.BeginForm(); %>
        <div class="editor-label">
            <%= base.Html.LabelFor(m => m.IsDefault) %>
        </div>
        <div>
            <%= base.Html.CheckBoxFor(m => m.IsDefault)%>
        </div>
        <p>
            <input type="submit" value="<%= base.Html.WebFramework().SysTranslations.SaveAndContinue %>" />
        </p>
        <% base.Html.EndForm(); %>
    </div>
    <p>
        <%= base.Html.ActionLink("Return Content Type management", CultureController.ActionList)%>
    </p>
</asp:Content>
