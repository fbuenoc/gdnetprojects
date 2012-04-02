<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ApplicationModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SystemTranslation().EntityApplication %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().SystemTranslation().DetailOfXYZ(base.Model.Name)%>
    </h2>
    <p>
        <%= base.Model.Description %>
    </p>
    <div>
        <%= base.Html.WebFramework().SystemTranslation().CreatedAt %>:
        <%= base.Model.CreatedAt.ToStringEx() %>
        <br />
        <%= base.Html.WebFramework().SystemTranslation().CreatedBy %>:
        <%= base.Model.CreatedBy %>
        <br />
        <%= base.Html.WebFramework().SystemTranslation().Category %>:
        <%= base.Model.Category %>
        <br />
        <%= base.Html.WebFramework().SystemTranslation().Statut %>:
        <%= base.Model.ActualStatut %>
    </div>
    <p>
        <%= base.Html.WebFramework().ActionListLink(base.Html.WebFramework().SystemTranslation().EntityApplication, RoleController.ActionList)%>
    </p>
</asp:Content>
