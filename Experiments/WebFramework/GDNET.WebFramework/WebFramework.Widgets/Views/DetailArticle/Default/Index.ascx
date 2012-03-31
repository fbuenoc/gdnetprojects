<%@ Import Namespace="WebFramework.Widgets.Models.DetailArticle" %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<DetailArticleModel>" %>
<div>
    <%= base.Model.ItemModel.Name %>
</div>
<div>
    <%= base.Model.ItemModel.Description %>
</div>
<div>
    <%= base.Model.ItemModel.MainContent %>
</div>
