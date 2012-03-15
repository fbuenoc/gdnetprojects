<%@ Import Namespace="WebFramework.Areas.Framework.ViewModels" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="ViewPage<TranslationViewModel>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Translation
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List of Translations
    </h2>
    <div>
        <h3>
            Cultures
        </h3>
        <p>
            <%= base.Html.GDNet().ListValue(base.Model.CulturesListValue) %>
        </p>
    </div>
    <div>
        <h3>
            Categories
        </h3>
        <p>
            <%= base.Html.GDNet().ListValue(base.Model.CategoriesListValue) %>
        </p>
    </div>
    <div>
        <% base.Html.Telerik().Grid<TranslationModel>(base.Model.Translations)
                .Name("ListTranslations")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Code).Title("Code");
                    columns.Bound(c => c.CreatedBy).Title("Created by");
                    columns.Bound(c => c.CreatedAt).Title("Created at");
                    columns.Bound(c => c.LastModifiedBy).Title("Last modified by");
                    columns.Bound(c => c.LastModifiedAt).Title("Last modified at");
                    columns.Bound(c => c.Id).Title("Actions").Template(template =>
                    {
        %>
        <%= base.Html.WebFramework().HyperLinkActions(new { id = template.Id }) %>
        <%
                    });
                })
                .Pageable()
                .Render();
        %>
    </div>
</asp:Content>
