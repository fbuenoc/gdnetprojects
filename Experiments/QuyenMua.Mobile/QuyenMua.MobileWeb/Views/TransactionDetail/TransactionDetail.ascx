<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TransactionDetail.ascx.cs"
    Inherits="QuyenMua.MobileWeb.Views.TransactionDetail.TransactionDetail" %>
<%@ Register Src="~/Views/Common/DefaultNotifier.ascx" TagName="DefaultNotifier"
    TagPrefix="uc" %>
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
        <uc:DefaultNotifier ID="ntf" runat="server" Visible="false" />
        <script type="text/javascript">
            $().ready(function () {
                $("#aspnetForm").validate({
                    errorLabelContainer: $("div#errorContainer"),
                    rules: {
                        ctl00_B_d_ctl01_i1: {
                            required: true,
                            minlength: 6
                        },
                        ctl00_B_d_ctl01_i2: {
                            required: true,
                            email: true
                        },
                        ctl00_B_d_ctl01_i10: "required",
                        ctl00_B_d_ctl01_i6: "required",
                        ctl00_B_d_ctl01_i5: "required",
                        ctl00_B_d_ctl01_i3: "required"
                    }
                });
            });
        </script>
        <form method="post" runat="server" enableviewstate="false" id="tdf" data-ajax="false">
        <div id="errorContainer">
        </div>
        <jqmob:FieldContainer ID="c1" runat="server">
            <jqmob:Label ID="l1" runat="server" Text="Họ tên NĐT:" ForControlId="i1" />
            <jqmob:Input ID="i1" runat="server" Type="Text" title="Hãy nhập họ tên, gồm 6 kí tự trở lên." />
        </jqmob:FieldContainer>
        <jqmob:FieldContainer ID="c2" runat="server">
            <jqmob:Label ID="l2" runat="server" Text="Email:" ForControlId="i2" />
            <jqmob:Input ID="i2" runat="server" Type="Email" title="Hãy nhập email hợp lệ." />
        </jqmob:FieldContainer>
        <jqmob:FieldContainer ID="c3" runat="server">
            <jqmob:Label ID="l3" runat="server" Text="Số ĐT:" ForControlId="i3" />
            <jqmob:Input ID="i3" runat="server" Type="Tel" title="Hãy nhập SĐT hợp lệ." />
        </jqmob:FieldContainer>
        <jqmob:FieldContainer ID="c4" runat="server">
            <jqmob:Label ID="l4" runat="server" Text="Mã CK:" ForControlId="i4" />
            <jqmob:Input ID="i4" runat="server" Type="Text" title="Hãy nhập mã CK từ 3 kí tự." />
        </jqmob:FieldContainer>
        <jqmob:FieldContainer ID="c5" runat="server">
            <jqmob:Label ID="l5" runat="server" Text="Giá:" ForControlId="i5" />
            <jqmob:Input ID="i5" runat="server" Type="Number" title="Hãy nhập giá." />
        </jqmob:FieldContainer>
        <jqmob:FieldContainer ID="c6" runat="server">
            <jqmob:Label ID="l6" runat="server" Text="Khối lượng:" ForControlId="i6" />
            <jqmob:Input ID="i6" runat="server" Type="Number" title="Hãy nhập khối lượng." />
        </jqmob:FieldContainer>
        <jqmob:FieldContainer ID="c7" runat="server">
            <jqmob:Label ID="l7" runat="server" Text="Địa điểm:" ForControlId="i7" />
            <jqmob:Input ID="i7" runat="server" Type="Text" title="Hãy nhập địa điểm." />
        </jqmob:FieldContainer>
        <jqmob:FieldContainer ID="c8" runat="server">
            <jqmob:Label ID="l8" runat="server" Text="Cty CK:" ForControlId="i8" />
            <jqmob:Input ID="i8" runat="server" Type="Text" title="Hãy nhập công ty chứng khoán." />
        </jqmob:FieldContainer>
        <jqmob:FieldContainer ID="c10" runat="server">
            <jqmob:Label ID="l10" runat="server" Text="Nội dung:" ForControlId="i10" />
            <jqmob:Input ID="i10" runat="server" Type="Text" Multiline="true" Cols="50" Rows="2"
                title="Hãy nhập nội dung." />
        </jqmob:FieldContainer>
        <jqmob:Button ID="b1" Icon="ArrowUp" Type="Submit" runat="server" Value="Đăng tin"
            Theme="E" />
        </form>
    </Content>
    <Footer>
        <jqmob:Settings ID="s1" runat="server" Theme="B" />
        <h4>
            (C) 2011 quyenmua.com
        </h4>
    </Footer>
</jqmob:Page>
