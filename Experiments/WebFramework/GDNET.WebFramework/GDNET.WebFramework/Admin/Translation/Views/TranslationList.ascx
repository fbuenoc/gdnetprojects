<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TranslationList.ascx.cs" Inherits="WebFramework.Admin.Translation.Views.TranslationList" %>
<gnc:HyperLink ID="NT" runat="server" Text="New translation" TextCode="GUI.Admin.Translation.NewTranslation.Text" />
<div class="clear">
    <asp:DataPager ID="PGT" runat="server" PagedControlID="LV" PageSize="10" QueryStringField="p">
        <Fields>
            <asp:NumericPagerField ButtonType="Link" />
        </Fields>
    </asp:DataPager>
</div>
<div class="clear">
    <gnc:ListView ID="LV" runat="server" ItemPlaceholderID="PH">
        <LayoutTemplate>
            <div class="clear">
                <div class="pHeaderColumn sw2">
                    <gnc:Literal ID="LitCodeHeader" runat="server" TextCode="GUI.Admin.Translation.TranslationList.CodeHeader" />
                </div>
                <div class="pHeaderColumn sw2">
                    <gnc:Literal ID="LitTextHeader" runat="server" TextCode="GUI.Admin.Translation.TranslationList.TextHeader" />
                </div>
                <div class="pHeaderColumn">
                    <gnc:Literal ID="LitActionHeader" runat="server" TextCode="GUI.Admin.Translation.TranslationList.ActionHeader" />
                </div>
            </div>
            <asp:PlaceHolder ID="PH" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="clear">
                <div class="pDataColumn sw2">
                    <!-- Translation code -->
                    <gnc:Literal ID="LC" runat="server" />
                </div>
                <div class="pDataColumn sw2">
                    <!-- Translation text -->
                    <gnc:Literal ID="LT" runat="server" />
                </div>
                <div class="pDataColumn">
                    <gnc:LinkButton ID="AE" runat="server" Action="Edit" TextCode="GUI.Admin.Translation.TranslationList.Edit.Text"
                        TooltipCode="GUI.Admin.Translation.TranslationList.Edit.Tooltip" />
                    <gnc:LinkButton ID="AD" runat="server" Action="Delete" TextCode="GUI.Admin.Translation.TranslationList.Delete.Text"
                        TooltipCode="GUI.Admin.Translation.TranslationList.Delete.Tooltip" />
                </div>
            </div>
        </ItemTemplate>
    </gnc:ListView>
</div>
<div class="clear">
    <asp:DataPager ID="PGB" runat="server" PagedControlID="LV" PageSize="10">
        <Fields>
            <asp:NumericPagerField ButtonType="Link" />
        </Fields>
    </asp:DataPager>
</div>
