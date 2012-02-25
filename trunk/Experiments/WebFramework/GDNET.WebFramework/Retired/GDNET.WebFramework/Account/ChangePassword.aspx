<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Account/Site.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="WebFramework.Account.ChangePassword" %>

<asp:Content ID="HC" runat="server" ContentPlaceHolderID="H">
</asp:Content>
<asp:Content ID="BC" runat="server" ContentPlaceHolderID="MC">
    <h2>
        <asp:Literal runat="server" ID="litCP" Text="Change Password" />
    </h2>
    <p>
        <asp:Literal runat="server" ID="litSubTitle" Text="Use the form below to change your password." />
    </p>
    <p>
        New passwords are required to be a minimum of
        <%= Membership.MinRequiredPasswordLength %>
        characters in length.
    </p>
    <asp:ChangePassword ID="CUP" runat="server" CancelDestinationPageUrl="~/" EnableViewState="false"
        RenderOuterTable="false" SuccessPageUrl="ChangePasswordSuccess.aspx">
        <ChangePasswordTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="VSCUP" runat="server" CssClass="failureNotification" ValidationGroup="VGCUP" />
            <div class="accountInfo">
                <fieldset class="changePassword">
                    <legend>
                        <asp:Literal runat="server" ID="litAccount" Text="Account Information" />
                    </legend>
                    <p>
                        <asp:Label ID="LCP" runat="server" AssociatedControlID="CurrentPassword">Old Password:</asp:Label>
                        <asp:TextBox ID="CurrentPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Old Password is required."
                            ValidationGroup="VGCUP">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="LNP" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label>
                        <asp:TextBox ID="NewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RNP" runat="server" ControlToValidate="NewPassword" CssClass="failureNotification"
                            ErrorMessage="New Password is required." ToolTip="New Password is required." ValidationGroup="VGCUP">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="LCNP" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                        <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RCNP" runat="server" ControlToValidate="ConfirmNewPassword"
                            CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirm New Password is required."
                            ToolTip="Confirm New Password is required." ValidationGroup="VGCUP">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CVNP" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                            CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry."
                            ValidationGroup="VGCUP">*</asp:CompareValidator>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="BC" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    <asp:Button ID="BS" runat="server" CommandName="ChangePassword" Text="Change Password" ValidationGroup="VGCUP" />
                </p>
            </div>
        </ChangePasswordTemplate>
    </asp:ChangePassword>
</asp:Content>
