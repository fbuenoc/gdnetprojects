<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserDetailsModel>" %>
<%@ Import Namespace="GDNET.FrameworkInfrastructure.Models.SearchModels" %>
<div class="ym-contain-dt site-nbg">
    <div>
        <div class="normal">
            <%: base.Model.DisplayName %>
        </div>
        <div class="normal">
            <%: base.Html.ActionLinkTrans("GUI.UserDetails.SearchContent", "Index", "Search", new { by = SearchMode.Author.ToString().ToLower(), value = base.Model.Id })%>
        </div>
    </div>
    <div>
        <section class="box">
            <%
                if (base.Model.DisplayMode == UserDetailsMode.Medium)
                {
                }
            %>
            <h6>
                <%: base.Html.Translate("GUI.User.CreatedDate")%>
            </h6>
            <div class="normal">
                <%: base.Model.CreatedAt.ToShortDateString() %>
            </div>
            <h6>
                <%: base.Html.Translate("GUI.User.Introduction")%>
            </h6>
            <%= base.Model.Introduction %>
        </section>
    </div>
</div>
