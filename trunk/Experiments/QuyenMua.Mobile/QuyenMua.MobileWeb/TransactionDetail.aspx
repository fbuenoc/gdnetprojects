<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="TransactionDetail.aspx.cs" Inherits="QuyenMua.MobileWeb.TransactionDetail" %>

<%@ Register Src="~/Views/TransactionDetail/TransactionDetail.ascx" TagPrefix="uc"
    TagName="TransactionDetail" %>
<asp:Content ID="c1" ContentPlaceHolderID="T" runat="server">
</asp:Content>
<asp:Content ID="c2" ContentPlaceHolderID="H" runat="server">
</asp:Content>
<asp:Content ID="c3" ContentPlaceHolderID="B" runat="server">
    <uc:TransactionDetail ID="d" runat="server" />
</asp:Content>
