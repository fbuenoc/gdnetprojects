<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QuyenMua.MobileWeb.Default"
    MasterPageFile="~/Site.Master" %>

<%@ Register Src="~/Views/TransactionList/TransactionList.ascx" TagName="TransactionList"
    TagPrefix="uc" %>
<asp:Content ContentPlaceHolderID="T" runat="server">
    <asp:Literal ID="ltrT" runat="server" Text="Giao dịch quyền mua CK" />
</asp:Content>
<asp:Content ContentPlaceHolderID="B" runat="server">
    <uc:TransactionList runat="server" ID="l" />
</asp:Content>
