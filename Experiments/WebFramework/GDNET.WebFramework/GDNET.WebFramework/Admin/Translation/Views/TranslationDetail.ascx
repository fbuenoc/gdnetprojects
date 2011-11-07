<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TranslationDetail.ascx.cs" Inherits="WebFramework.Admin.Translation.Views.TranslationDetail" %>
<%@ Register Src="~/Views/DefaultNotifier.ascx" TagName="Notifier" TagPrefix="UC" %>
<UC:Notifier ID="NF" runat="server" Visible="false" />
<div>
    <gnc:LinkButton ID="RT" runat="server" Text="Return" TextCode="GUI.Common.Action.Return.Text" TooltipCode="GUI.Common.Action.Return.Tooptip" />
    <gnc:Button ID="E" runat="server" Text="Edit" TextCode="GUI.Common.Action.Edit.Text" TooltipCode="GUI.Common.Action.Edit.Tooltip" />
</div>
<fieldset>
    <legend>
        <gnc:Literal ID="LitBlocTitle" runat="server" Text="Translation detail" TextCode="GUI.Admin.Translation.TranslationDetail.Legend"></gnc:Literal>
    </legend>
    <div>
        <div>
            <gnc:Literal ID="LitCode" runat="server" Text="Code" TextCode="GUI.Admin.Translation.TranslationDetail.Code" />
        </div>
        <div>
            <gnc:TextBox ID="IC" runat="server" TooltipCode="GUI.Admin.Translation.TranslationDetail.Code.TextBox.Tooltip"
                CssClass="normalEntry" />
        </div>
    </div>
    <div>
        <div>
            <gnc:Literal ID="LitText" runat="server" Text="Text" TextCode="GUI.Admin.Translation.TranslationDetail.Text" />
        </div>
        <div>
            <gnc:TextBox ID="IT" runat="server" TooltipCode="GUI.Admin.Translation.TranslationDetail.Text.TextBox.Tooltip"
                TextMode="MultiLine" CssClass="text2Lines" />
        </div>
    </div>
</fieldset>
<div>
    <gnc:Button ID="R" runat="server" Text="Reset" TextCode="GUI.Common.Action.Reset.Text" TooltipCode="GUI.Common.Action.Reset.Tooltip" />
    <gnc:Button ID="S" runat="server" Text="Submit" TextCode="GUI.Common.Action.Submit.Text" TooltipCode="GUI.Common.Action.Submit.Tooltip" />
    <gnc:Button ID="D" runat="server" Text="Delete" TextCode="GUI.Common.Action.Delete.Text" TooltipCode="GUI.Common.Action.Delete.Tooltip" />
</div>
