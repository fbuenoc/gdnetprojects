<%@ Page Title="Register" Language="C#" MasterPageFile="~/Account/Site.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="GDNET.WebFramework.Account.Register" %>

<asp:Content ID="HC" runat="server" ContentPlaceHolderID="H">
</asp:Content>
<asp:Content ID="BC" runat="server" ContentPlaceHolderID="MC">
    <asp:CreateUserWizard ID="CUW" runat="server" EnableViewState="false">
        <LayoutTemplate>
            <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CUWS" runat="server">
                <ContentTemplate>
                    <h2>
                        Create a New Account
                    </h2>
                    <p>
                        Use the form below to create a new account.
                    </p>
                    <p>
                        Passwords are required to be a minimum of
                        <%= Membership.MinRequiredPasswordLength %>
                        characters in length.
                    </p>
                    <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="VS" runat="server" CssClass="failureNotification" ValidationGroup="VGCUW" />
                    <div class="accountInfo">
                        <fieldset class="register">
                            <legend>Account Information</legend>
                            <p>
                                <asp:Label ID="LUN" runat="server" AssociatedControlID="UserName" Text="User Name:" />
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                    ValidationGroup="VGCUW">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="LE" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RE" runat="server" ControlToValidate="Email" CssClass="failureNotification"
                                    ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="VGCUW">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="LP" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                    ValidationGroup="VGCUW">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="LCP" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification"
                                    Display="Dynamic" ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired"
                                    runat="server" ToolTip="Confirm Password is required." ValidationGroup="VGCUW">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CVCP" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                    CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                    ValidationGroup="VGCUW">*</asp:CompareValidator>
                            </p>
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="BCU" runat="server" CommandName="MoveNext" Text="Create User" ValidationGroup="VGCUW" />
                        </p>
                    </div>
                </ContentTemplate>
                <CustomNavigationTemplate>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
