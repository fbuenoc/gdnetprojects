<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefaultLoginView.ascx.cs" Inherits="WebFramework.Views.DefaultLoginView" %>
<!-- Login status -->
<asp:LoginView ID="LV" runat="server" EnableViewState="false">
    <AnonymousTemplate>
        [ <a href="~/Account/Login.aspx" id="ll" runat="server">Log In</a> ]
    </AnonymousTemplate>
    <LoggedInTemplate>
        Welcome <span class="bold">
            <asp:HyperLink ID="HD" runat="server" NavigateUrl="~/Account/Detail.aspx">
                <asp:LoginName ID="LN" runat="server" />
            </asp:HyperLink>
        </span>! [
        <asp:LoginStatus ID="LS" runat="server" LogoutAction="Redirect" LogoutText="Log Out" LogoutPageUrl="~/" />
        ]
    </LoggedInTemplate>
</asp:LoginView>
