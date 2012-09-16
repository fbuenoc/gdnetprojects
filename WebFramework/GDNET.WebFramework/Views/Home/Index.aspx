<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IList<ContentItemModel>>" %>

<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.Content" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal ID="L1" runat="server" Text="<%$ Trans:GUI.HomePage.Title %>" />
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="block block-left">
        <%  
            Func<ContentItemModel, string> GenerateNameLink = x =>
            {
                return base.Html.ActionLink(x.Name, "Details", "Home", new { id = x.Id.ToString() }, null).ToHtmlString();
            };

            var repeater = RepeaterAssistant.Create<ContentItemModel>("home_content_items").AddEntities(base.Model.ToList());
            repeater.AddColumns("Name", "Description").EnableHeader(false).AddGenerator("Name", GenerateNameLink);
        %>
        <%= repeater.GenerateHtml() %>
        <div style="clear: both;">
        </div>
    </div>
    <style type="text/css">
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
