<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Site.Master" AutoEventWireup="true"
    CodeBehind="Detail.aspx.cs" Inherits="WebFramework.Account.Detail" %>

<asp:Content ID="HC" ContentPlaceHolderID="H" runat="server">
</asp:Content>
<asp:Content ID="BC" ContentPlaceHolderID="MC" runat="server">
    <asp:Menu ID="MN" runat="server" CssClass="menu" EnableViewState="false" IncludeStyleBlock="false"
        Orientation="Horizontal">
        <Items>
            <asp:MenuItem NavigateUrl="~/Account/ChangePassword.aspx" Text="Change password"></asp:MenuItem>
        </Items>
    </asp:Menu>
</asp:Content>
