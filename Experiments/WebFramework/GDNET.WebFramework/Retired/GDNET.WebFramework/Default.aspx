﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="WebFramework.Default" %>

<asp:Content ID="TC" runat="server" ContentPlaceHolderID="T">
    <gnc:Literal ID="LitTitle" runat="server" TextCode="GUI.WebFramework.Default.PageTitle" />
</asp:Content>
<asp:Content ID="BC" runat="server" ContentPlaceHolderID="MC">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409" title="MSDN ASP.NET Docs">
            documentation on ASP.NET at MSDN</a>.
    </p>
</asp:Content>
