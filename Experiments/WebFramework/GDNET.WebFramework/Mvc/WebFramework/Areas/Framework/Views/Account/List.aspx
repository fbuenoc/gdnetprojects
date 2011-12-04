<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Framework/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<AccountModel>>" %>

<asp:Content ID="C1" ContentPlaceHolderID="TitleContent" runat="server">
    Accounts
</asp:Content>
<asp:Content ID="C2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        List of accounts
    </h2>
    <div>
        <%= base.Html.Telerik().Grid<AccountModel>()
                .Name("AccountList")
                .EnableCustomBinding(true)
                .Columns(columns =>
                {
                    columns.Bound(c => c.UserName).Width(250).Title("User name");
                    columns.Bound(c => c.Email).Width(150).Title("Email");
                    columns.Bound(c => c.BasicInformation.TelNumber).Width(150).Title("Tel number");
                    columns.Bound(c => c.CreationDate).Title("Creation date");
                    columns.Bound(c => c.LastLoginDate).Title("Last login date");
                    columns.Bound(c => c.ProviderUserKey).Width(120).Title("Actions")
                        .ClientTemplate("<a href='/Framework/Account/Delete?key=<#= ProviderUserKey #>'>Xoá</a> | <a href='/Framework/Account/Details?key=<#= ProviderUserKey #>'>Chi tiết</a>");
                })
                .DataBinding(dataBinding => dataBinding.Ajax().Select("TelerikGetAccounts", 
                                                                       CommonConstants.FrameworkControllerAccount, 
                                                                       new { area = CommonConstants.AreaFramework }))
                .Pageable()
        %>
    </div>
    <p>
        <%= base.Html.ActionLink("Return Administrator index", "Index", CommonConstants.AreaFramework)%>
    </p>
</asp:Content>
