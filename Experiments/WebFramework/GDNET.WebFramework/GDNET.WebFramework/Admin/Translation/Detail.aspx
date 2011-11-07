<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs"
    Inherits="WebFramework.Admin.Translation.Detail" %>

<%@ Register Src="~/Admin/Translation/Views/TranslationDetail.ascx" TagName="TranslationDetail" TagPrefix="UC" %>
<asp:Content ID="TC" ContentPlaceHolderID="T" runat="server">
    <gnc:Literal ID="LitTitle" runat="server" TextCode="GUI.Admin.Translation.TranslationDetail.PageTitle" />
</asp:Content>
<asp:Content ID="BC" ContentPlaceHolderID="MC" runat="server">
    <UC:TranslationDetail ID="TD" runat="server" />
</asp:Content>
