<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs"
    Inherits="WebFramework.Admin.Translation.Index" %>

<%@ Register Src="~/Admin/Translation/Views/TranslationList.ascx" TagName="TranslationList" TagPrefix="UC" %>
<asp:Content ID="TC" ContentPlaceHolderID="T" runat="server">
    <gnc:Literal ID="LitTitle" runat="server" TextCode="GUI.Admin.Translation.TranslationList.PageTitle" />
</asp:Content>
<asp:Content ID="BC" ContentPlaceHolderID="MC" runat="server">
    <UC:TranslationList ID="TL" runat="server" />
</asp:Content>
