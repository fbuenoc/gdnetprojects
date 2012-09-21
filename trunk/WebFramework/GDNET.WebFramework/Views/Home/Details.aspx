<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DetailModel>" %>

<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.Content" %>
<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.HomeModels" %>
<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: base.Html.Translate("GUI.DetailsPage.Title", base.Model.ItemModel.Name) %>
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="block">
        <div class="block-left">
            <div class="home-details-title">
                <%= base.Model.ItemModel.Name %>
            </div>
            <div class="home-details-description">
                <%= base.Model.ItemModel.Description%>
            </div>
            <p>
                <%= base.Model.ItemModel.Keywords%>
            </p>
            <%
                var repeater = RepeaterAssistant.Create<ContentPartModel>("item_parts").AddEntities(base.Model.ItemModel.Parts);
                repeater.AddColumns("Name", "Details").EnableHeader(false);
            %>
            <%= repeater.GenerateHtml() %>
        </div>
        <div class="block-right">
            <div class="home-details-title">
                <%: base.Html.Translate("GUI.DetailsPage.FocusTitle")%>
            </div>
            <%
                Func<ContentItemModel, string> NameGenerator = x =>
                {
                    return base.Html.ActionLink(x.Name, "Details", "Home", new { id = x.Id.ToString() }, new { title = x.Description }).ToHtmlString();
                };

                var repeaterFocus = RepeaterAssistant.Create<ContentItemModel>("focus_items").AddEntities(base.Model.FocusItems);
                repeaterFocus.AddColumns("Name").EnableHeader(false);
                repeaterFocus.AddGenerator("Name", NameGenerator);
            %>
            <%= repeaterFocus.GenerateHtml()%>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('div[name=item_parts]').addClass('rpt');
            $('div[name=item_parts] div[name=body]').addClass('rpt_body');
            $('div[name=item_parts] div[name=body] div[name=line]').addClass('rpt_body_line');
            $('div[name=item_parts] div[name=body] div[name=line]').addClass('rpt_body_line_home_details');
            $('div[name=item_parts] div[name=body] div[name=line] div[name=Name]').addClass('home-details-sub-title');
            $('div[name=item_parts] div[name=body] div[name=line] div[name=Details]').addClass('home-details-sub-content');

            $('div[name=focus_items] div[name=body]').addClass('rpt_body');
            $('div[name=focus_items] div[name=body] div[name=line]').addClass('rpt_body_line');
            $('div[name=focus_items] div[name=body] div[name=line]:even').addClass('rpt_body_line_even_none_focus');
            $('div[name=focus_items] div[name=body] div[name=line]:odd').addClass('rpt_body_line_odd_none_focus');
            $('div[name=focus_items] div[name=body] div[name=line] div[name=Name]').addClass('rpt_body_cell_focus_name_focus');
        });
    </script>
</asp:Content>
