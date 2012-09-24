﻿<%@ Import Namespace="WebFramework.Widgets.FileManagerWg.Models" %>

<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<FileContentModel>>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    List Files
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    </div>
    <div>
        <% base.Html.Telerik().Grid<FileContentModel>(base.Model)
                .Name("ListFiles")
                .Columns(columns =>
                {
                    columns.Bound(c => c.Title).Title("Title");
                    columns.Bound(c => c.Id).Title("Actions").Template(template =>
                    {
                    });
                })
                .Pageable()
                .Render();
        %>
    </div>
</asp:Content>
<asp:Content ID="C3" ContentPlaceHolderID="HeadContent" runat="server">
    <% base.Html.WebFramework().WidgetHanlder().RegisterStyleSheets(); %>
</asp:Content>