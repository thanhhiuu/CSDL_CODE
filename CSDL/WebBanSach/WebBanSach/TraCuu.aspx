<%@ Page Title="" Language="C#" MasterPageFile="~/ShopBook.Master" AutoEventWireup="true" CodeBehind="TraCuu.aspx.cs" Inherits="WebBanSach.TraCuu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Tra Cuu</h2>
    Ten sach: <asp:TextBox runat="server" ID="txttracuu"></asp:TextBox>
    <asp:Button runat="server" ID="btntimkiem"  Text="Tra cuu"/>


    <asp:GridView ID="gvsach" runat="server" DataSourceID="dssach" DataKeyNames="MaSach" AutoGenerateColumns="false"></asp:GridView>


    <asp:SqlDataSource ID="dssach" runat="server" ConnectionString="<%$ ConnectionStrings:BookStoreDBConnectionString3 %>" 
        DeleteCommand="DELETE FROM [Sach] WHERE [MaSach] = @MaSach" 
        InsertCommand="INSERT INTO [Sach] ([TenSach], [MaCD], [MaNXB], [Dongia], [AnhBia], [Ngaycapnhat], [Soluotxem]) VALUES (@TenSach, @MaCD, @MaNXB, @Dongia, @AnhBia, @Ngaycapnhat, @Soluotxem)"
        SelectCommand="SELECT * FROM [Sach] WHERE ([TenSach] LIKE '%' + @TenSach + '%')" 
        UpdateCommand="UPDATE [Sach] SET [TenSach] = @TenSach, [MaCD] = @MaCD, [MaNXB] = @MaNXB, [Dongia] = @Dongia, [AnhBia] = @AnhBia, [Ngaycapnhat] = @Ngaycapnhat, [Soluotxem] = @Soluotxem WHERE [MaSach] = @MaSach">
        <DeleteParameters>
            <asp:Parameter Name="MaSach" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="TenSach" Type="String" />
            <asp:Parameter Name="MaCD" Type="Int32" />
            <asp:Parameter Name="MaNXB" Type="Int32" />
            <asp:Parameter Name="Dongia" Type="Decimal" />
            <asp:Parameter Name="AnhBia" Type="String" />
            <asp:Parameter Name="Ngaycapnhat" Type="DateTime" />
            <asp:Parameter Name="Soluotxem" Type="Int32" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="txttracuu" Name="TenSach" PropertyName="Text" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="TenSach" Type="String" />
            <asp:Parameter Name="MaCD" Type="Int32" />
            <asp:Parameter Name="MaNXB" Type="Int32" />
            <asp:Parameter Name="Dongia" Type="Decimal" />
            <asp:Parameter Name="AnhBia" Type="String" />
            <asp:Parameter Name="Ngaycapnhat" Type="DateTime" />
            <asp:Parameter Name="Soluotxem" Type="Int32" />
            <asp:Parameter Name="MaSach" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
