<%@ Page Title="" Language="C#" MasterPageFile="~/Account/Site.Master" AutoEventWireup="true"
    CodeBehind="RecoverPassword.aspx.cs" Inherits="WebFramework.Account.RecoverPassword" %>

<asp:Content ID="HC" ContentPlaceHolderID="H" runat="server">
</asp:Content>
<asp:Content ID="BC" ContentPlaceHolderID="MC" runat="server">
    <asp:PasswordRecovery ID="RP" runat="server" EnableViewState="false">
        <QuestionTemplate>
            <div>
                <p>
                    <asp:Literal ID="LUN" runat="server" Text="Username:"></asp:Literal>
                    <asp:Literal ID="UserName" runat="server"></asp:Literal>
                </p>
                <p>
                    <asp:Literal ID="LQ" runat="server" Text="Question:"></asp:Literal>
                    <asp:Literal ID="Question" runat="server"></asp:Literal>
                </p>
                <p>
                    <asp:Label ID="LA" runat="server" AssociatedControlID="Answer" Text="Answer:" />
                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RA" runat="server" ControlToValidate="Answer" ErrorMessage="Answer is required."
                        ToolTip="Answer is required." ValidationGroup="VGRP">*</asp:RequiredFieldValidator>
                </p>
                <p class="submitButton">
                    <asp:Button ID="BC" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    <asp:Button ID="BS" runat="server" CommandName="Submit" Text="Recover Password" ValidationGroup="VGRP" />
                </p>
            </div>
        </QuestionTemplate>
        <UserNameTemplate>
            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
            <asp:ValidationSummary ID="VSRP" runat="server" CssClass="failureNotification" ValidationGroup="VGRP" />
            <fieldset class="recoverPassword">
                <legend>
                    <asp:Literal runat="server" ID="litAccount" Text="Account Information" />
                </legend>
                <p>
                    <asp:Label ID="LUN" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                    <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                        CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                        ValidationGroup="VGRP">*</asp:RequiredFieldValidator>
                </p>
            </fieldset>
            <p class="submitButton">
                <asp:Button ID="BC" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                <asp:Button ID="BS" runat="server" CommandName="Submit" Text="Recover Password" ValidationGroup="VGRP" />
            </p>
        </UserNameTemplate>
        <SuccessTemplate>
            <p>
                <gdnet:Literal ID="litSuccess" runat="server" Text="Password recovery is completed successfully."
                    TextCode="GUI.Account.RecoverPassword.Success.Text" />
            </p>
        </SuccessTemplate>
    </asp:PasswordRecovery>
</asp:Content>
