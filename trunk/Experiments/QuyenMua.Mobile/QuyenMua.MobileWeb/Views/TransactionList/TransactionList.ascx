<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TransactionList.ascx.cs"
    Inherits="QuyenMua.MobileWeb.Views.TransactionList.TransactionList" %>
<jqmob:Page ID="p1" runat="server" DataTitle="QuyenMua.COM - Quyền mua mới nhất"
    Theme="B">
    <Header>
        <jqmob:Settings ID="s1" runat="server" Theme="B" />
        <h3>
            <asp:Literal ID="ltrTitle" runat="server" Text="Giao dịch gần nhất"></asp:Literal>
        </h3>
        <jqmob:MobHyperLink ID="nt" runat="server" NavigateUrl="~/TransactionDetail.aspx?mode=Creation"
            Text="Đăng tin" Theme="E" Icon="ArrowUp" Position="Right" />
    </Header>
    <Content>
        <jqmob:MobRepeater ID="rp1" runat="server" DataInset="true" ReadOnly="true">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td class="d1">
                            <asp:Literal ID="lS" runat="server" Text="Mã CK" />
                        </td>
                        <td class="d1">
                            <asp:Literal ID="lT" runat="server" Text="Loại" />
                        </td>
                        <td class="d2">
                            <asp:Literal ID="lP" runat="server" Text="Giá" />
                        </td>
                        <td class="d3">
                            <asp:Literal ID="lA" runat="server" Text="KL" />
                        </td>
                        <td class="d4">
                            <asp:Literal ID="lD" runat="server" Text="Ngày" />
                        </td>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <table>
                    <tr>
                        <td class="d1">
                            <asp:Literal ID="lS" runat="server" />
                        </td>
                        <td class="d1">
                            <asp:Literal ID="lT" runat="server" />
                        </td>
                        <td class="d2">
                            <asp:Literal ID="lP" runat="server" />
                        </td>
                        <td class="d3">
                            <asp:Literal ID="lA" runat="server" />
                        </td>
                        <td class="d4">
                            <asp:Literal ID="lD" runat="server" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </jqmob:MobRepeater>
    </Content>
    <Footer>
        <jqmob:Settings ID="s1" runat="server" Theme="E" />
        <h4>
            (C) 2011 quyenmua.com
        </h4>
    </Footer>
</jqmob:Page>
