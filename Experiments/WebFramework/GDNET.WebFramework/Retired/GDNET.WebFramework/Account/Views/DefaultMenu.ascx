<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefaultMenu.ascx.cs" Inherits="WebFramework.Account.Views.DefaultMenu" %>
<asp:Menu ID="MN" runat="server" CssClass="menu" EnableViewState="false" IncludeStyleBlock="false"
    Orientation="Horizontal">
    <Items>
        <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Home"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/About.aspx" Text="About"></asp:MenuItem>
    </Items>
</asp:Menu>
