<%@ Page Title="" Language="C#" MasterPageFile="~/ShopBook.Master" AutoEventWireup="true" CodeBehind="XemSach.aspx.cs" Inherits="WebBanSach.XemSach" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Xem Sách</h1>
    Chọn chủ đề: <asp:DropDownList runat="server" ID="ddlChuDe" AutoPostBack="True" DataSourceID="dsChuDe" DataTextField="TenNXB" DataValueField="MaNXB"></asp:DropDownList>
    <br />
    <br />
    <div>
        <asp:Repeater ID="rptsach" runat="server" DataSourceID="dsloaisach">
            <ItemTemplate>
                <div class="item">
                    <div class="item-grid">
                        <div class="img">
                            <a href="#">
                                <img id="img1" src='<%# Eval("AnhBia", "Bia_sach/{0}") %>' />
                            </a>
                        </div>
                        <div class="text-hoa">
                            <asp:Label runat="server" ID="lbTenHoa" Text='<%#Eval("Tensach") %>'></asp:Label>
                            <br />
                            Giá Bán:
                            <asp:Label CssClass="text-info" runat="server" ID="lbGia" Text='<%# Eval("DonGia", "{0: #,##0} vnđ") %>'></asp:Label>
                            <br />
                            <asp:Button runat="server" CssClass="btn btn-success" Text="Thêm vào giỏ" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>


    <asp:SqlDataSource ID="dsloaisach" runat="server" ConnectionString="<%$ ConnectionStrings:BookStoreDBConnectionString3 %>" SelectCommand="SELECT * FROM [Sach] WHERE ([MaNXB] = @MaNXB)">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlChuDe" Name="MaNXB" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dsChuDe" runat="server" ConnectionString="<%$ ConnectionStrings:BookStoreDBConnectionString2 %>" SelectCommand="SELECT * FROM [NhaXuatBan]"></asp:SqlDataSource>
</asp:Content>
