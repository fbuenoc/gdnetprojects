<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ContentItemModel>" %>

<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.Content" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate("GUI.DetailsPage.Title", base.Model.Name) %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="block block-left">
        <div class="home-details-title">
            <%= base.Model.Name %>
        </div>
        <div class="home-details-description">
            <%= base.Model.Description %>
        </div>
        <p>
            <%= base.Model.Keywords %>
        </p>
        <%
            var repeater = RepeaterAssistant.Create<ContentPartModel>("item_parts").AddEntities(base.Model.Parts);
            repeater.AddColumns("Name", "Details").EnableHeader(false);
        %>
        <%= repeater.GenerateHtml() %>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('div[name=item_parts]').addClass('rpt');
            $('div[name=item_parts] div[name=body]').addClass('rpt_body');
            $('div[name=item_parts] div[name=body] div[name=line]').addClass('rpt_body_line');
            $('div[name=item_parts] div[name=body] div[name=line]').addClass('rpt_body_line_home_details');
            $('div[name=item_parts] div[name=body] div[name=line] div[name=Name]').addClass('home-details-sub-title');
            $('div[name=item_parts] div[name=body] div[name=line] div[name=Details]').addClass('home-details-sub-content');
        });
    </script>
</asp:Content>
