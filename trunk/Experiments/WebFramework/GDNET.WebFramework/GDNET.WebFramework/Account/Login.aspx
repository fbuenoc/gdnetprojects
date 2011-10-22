<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Account/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="GDNET.WebFramework.Account.Login" %>

<asp:Content ID="HC" runat="server" ContentPlaceHolderID="H">
</asp:Content>
<asp:Content ID="BC" runat="server" ContentPlaceHolderID="MC">
    <h2>
        Log In
    </h2>
    <p>
        Please enter your username and password.
        <asp:HyperLink ID="HR" runat="server">Register</asp:HyperLink>
        if you don't have an account.
    </p>
    <asp:Login ID="L" runat="server" EnableViewState="false" RenderOuterTable="false">
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="VSL" runat="server" CssClass="failureNotification" ValidationGroup="VGL" />
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Account Information</legend>
                    <p>
                        <asp:Label ID="LUN" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                            CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                            ValidationGroup="VGL">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="LP" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                            ValidationGroup="VGL">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:CheckBox ID="RememberMe" runat="server" />
                        <asp:Label ID="LRM" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Keep me logged in</asp:Label>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="VGL" />
                </p>
            </div>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>
