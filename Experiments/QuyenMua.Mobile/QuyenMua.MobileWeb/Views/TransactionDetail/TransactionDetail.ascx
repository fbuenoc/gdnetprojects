<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TransactionDetail.ascx.cs"
    Inherits="QuyenMua.MobileWeb.Views.TransactionDetail.TransactionDetail" %>
<jqmob:Page ID="p1" runat="server" DataTitle="QuyenMua.COM - Đăng tin mua bán quyền"
    Theme="F">
    <Header>
        <jqmob:Settings ID="s1" runat="server" Theme="B" />
        <jqmob:MobHyperLink ID="b" runat="server" Text="Back" Icon="Back" Theme="E" />
        <h3>
            <asp:Literal ID="ltrTitle" runat="server" Text="Đăng tin mua bán quyền"></asp:Literal>
        </h3>
    </Header>
    <Content>
        <jqmob:Settings ID="s1" runat="server" Theme="C" />
        <jqmob:Form ID="f1" runat="server" Method="Post">
            <jqmob:FieldContainer ID="c1" runat="server">
                <jqmob:Label ID="l1" runat="server" Text="Họ tên NĐT:" ForControlId="i1" />
                <jqmob:Input ID="i1" runat="server" Type="Text" />
            </jqmob:FieldContainer>
            <jqmob:FieldContainer ID="c2" runat="server">
                <jqmob:Label ID="l2" runat="server" Text="Email:" ForControlId="i2" />
                <jqmob:Input ID="i2" runat="server" Type="Email" />
            </jqmob:FieldContainer>
            <jqmob:FieldContainer ID="c3" runat="server">
                <jqmob:Label ID="l3" runat="server" Text="Số ĐT:" ForControlId="i3" />
                <jqmob:Input ID="i3" runat="server" Type="Tel" />
            </jqmob:FieldContainer>
            <jqmob:FieldContainer ID="c4" runat="server">
                <jqmob:Label ID="l4" runat="server" Text="Mã CK:" ForControlId="i4" />
                <jqmob:Input ID="i4" runat="server" Type="Text" />
            </jqmob:FieldContainer>
            <jqmob:FieldContainer ID="c5" runat="server">
                <jqmob:Label ID="l5" runat="server" Text="Giá:" ForControlId="i5" />
                <jqmob:Input ID="i5" runat="server" Type="Number" />
            </jqmob:FieldContainer>
            <jqmob:FieldContainer ID="c6" runat="server">
                <jqmob:Label ID="l6" runat="server" Text="Khối lượng:" ForControlId="i6" />
                <jqmob:Input ID="i6" runat="server" Type="Number" />
            </jqmob:FieldContainer>
            <jqmob:FieldContainer ID="c10" runat="server">
                <jqmob:Label ID="l10" runat="server" Text="Nội dung:" ForControlId="i10" />
                <jqmob:Input ID="i10" runat="server" Type="Text" Multiline="true" Cols="50" Rows="2" />
            </jqmob:FieldContainer>
            <jqmob:Button ID="b1" Icon="ArrowUp" Type="Submit" runat="server" Value="Đăng tin"
                Theme="E" />
        </jqmob:Form>
    </Content>
    <Footer>
        <jqmob:Settings ID="s1" runat="server" Theme="B" />
        <h4>
            (C) 2011 quyenmua.com
        </h4>
    </Footer>
</jqmob:Page>
