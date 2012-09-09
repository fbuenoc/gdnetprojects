<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<ContentItemModel>>" %>

<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.Content" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        List<string> columns = new List<string>() { "Name", "Description" };
        string repeaterHtml = base.Html.Repeater("home_content_items", base.Model.ToList(), columns);
    %>
    <%= repeaterHtml %>
    <div style="clear: both;">
    </div>
    <style type="text/css">
        .rpt_body_cell_home_name
        {
            float: none;
            width: 400px;
            padding-right: 5px;
            font-weight: bold;
        }
        .rpt_body_cell_home_desc
        {
            float: none;
            width: 400px;
            padding-right: 5px;
            font-style: italic;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('div[name=home_content_items] div[name=body]').addClass('rpt_body');
            $('div[name=home_content_items] div[name=body] div[name=line]').addClass('rpt_body_line');
            $('div[name=home_content_items] div[name=body] div[name=line]:even').addClass('rpt_body_line_even');
            $('div[name=home_content_items] div[name=body] div[name=line]:odd').addClass('rpt_body_line_odd');
            $('div[name=home_content_items] div[name=body] div[name=line] div[name=Name]').addClass('rpt_body_cell_home_name');
            $('div[name=home_content_items] div[name=body] div[name=line] div[name=Description]').addClass('rpt_body_cell_home_desc');
        });
    </script>
</asp:Content>
