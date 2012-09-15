﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<ContentItemModel>>" %>

<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.Content" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal ID="L1" runat="server" Text="<%$ Trans:GUI.ContentAdmin.List.Title %>" />
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="L2" runat="server" Text="<%$ Trans:GUI.ContentAdmin.List.Heading %>" />
    </h2>
    <%
        Func<ContentItemModel, string> GenerateNameLink = (x =>
        {
            return string.Format("<a href=\"Details?id={0}\" title=\"{1}\">{2}</a>", x.Id, x.Description, x.Name);
        });

        var repeater = RepeaterAssistant.Create<ContentItemModel>("content_items").EnableHeader(true).AddEntities(base.Model.ToList());
        repeater.AddGenerator("Name", GenerateNameLink);
        repeater.AddColumnWithText("Name", "GUI.ContentAdmin.List.ColumnName").AddColumnWithText("Keywords", "GUI.ContentAdmin.List.ColumnKeywords");
    %>
    <div>
        <%= repeater.GenerateHtml() %>
        <div style="clear: both;">
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('div[name=content_items]').addClass('rpt');
            $('div[name=content_items] div[name=header]').addClass('rpt_header');
            $('div[name=content_items] div[name=header] div').addClass('rpt_header_cell');

            $('div[name=content_items] div[name=body]').addClass('rpt_body');
            $('div[name=content_items] div[name=body] div[name=line]').addClass('rpt_body_line');
            $('div[name=content_items] div[name=body] div[name=line]:even').addClass('rpt_body_line_even');
            $('div[name=content_items] div[name=body] div[name=line]:odd').addClass('rpt_body_line_odd');
            $('div[name=content_items] div[name=body] div[name=line] div').addClass('rpt_body_cell');
        });
    </script>
</asp:Content>