<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ApplicationModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= base.Html.WebFramework().SysTranslations.EntityApplication %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <%= base.Html.WebFramework().SysTranslations.DetailOfXYZ(base.Model.Name)%>
    </h2>
    <p>
        <%= base.Model.Description %>
    </p>
    <div>
        <%= base.Html.WebFramework().SysTranslations.CreatedAt %>:
        <%= base.Model.CreatedAt.ToStringEx() %>
        <br />
        <%= base.Html.WebFramework().SysTranslations.CreatedBy %>:
        <%= base.Model.CreatedBy %>
        <br />
        <%= base.Html.WebFramework().SysTranslations.Category %>:
        <%= base.Model.Category %>
        <br />
        <%= base.Html.WebFramework().SysTranslations.Statut %>:
        <%= base.Model.ActualStatut %>
    </div>
    <p>
        <%= base.Html.WebFramework().ActionListLink(base.Html.WebFramework().SysTranslations.EntityApplication, RoleController.ActionList)%>
    </p>
</asp:Content>
