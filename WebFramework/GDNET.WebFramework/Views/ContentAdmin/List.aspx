<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<ContentItemModel>>" %>

<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.Content" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    List of content items
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List
    </h2>
    <%
        List<string> columns = new List<string>() { "Name", "Keywords" };
        string repeaterHtml = base.Html.Repeater("content_items", true, base.Model.ToList(), columns);        
    %>
    <%= repeaterHtml %>
    <div style="clear: both;">
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
