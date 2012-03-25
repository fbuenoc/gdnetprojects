﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentAttributeModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Content Attribute
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details of Content Attribute:
        <%= base.Model.Code %>
    </h2>
    <div>
        <div>
            <%= base.Html.WebFramework().SysTranslations.CreatedAt %>:
            <%= base.Model.CreatedAt.ToStringEx() %>
            <br />
            <%= base.Html.WebFramework().SysTranslations.CreatedBy %>:
            <%= base.Model.CreatedBy %>
            <br />
            Content type:
            <%= base.Model.ContentType %>
            <br />
            Data type:
            <%= base.Model.DataType %>
        </div>
    </div>
    <p>
        <%= base.Html.ActionLink("Return Content Type management", ContentTypeController.ActionDetails, ControllerConstants.FrameworkContentTypeController, new { id = base.Model.ContentTypeId }, new { })%>
        <%= base.Html.ActionLink("Add other Attribute", ListValueController.ActionCreate, new { key = base.Model.ContentTypeId }) %>
    </p>
</asp:Content>