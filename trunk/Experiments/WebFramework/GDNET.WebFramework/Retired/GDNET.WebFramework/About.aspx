<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WebFramework.About" %>

<asp:Content ID="HC" runat="server" ContentPlaceHolderID="H">
</asp:Content>
<asp:Content ID="BC" runat="server" ContentPlaceHolderID="MC">
    <h2>
        <gnc:Literal ID="litHeader" runat="server" Text="About" TextCode="GUI.Account.About.Header" />
    </h2>
    <p>
        <gnc:Literal ID="litContent" runat="server" Text="Put content here." TextCode="GUI.Account.About.Content" />
    </p>
</asp:Content>
