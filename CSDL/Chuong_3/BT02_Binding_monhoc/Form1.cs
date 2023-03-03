using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient; // Sử dụng với Sql Server
using System.Data.OleDb; // Sử dụng CSDL với Access


namespace BT02_Binding_monhoc
{
    public partial class Form1 : Form
    {
        // Khai báo các đối tượng cần sử dụng
        // 1.1 Chuỗi kết nối
        string strcon = @"provider=microsoft.jet.oledb.4.0; data source=..\..\..\Data\QLSINHVIEN.mdb";

        // 1.2 Khai báo các đối tượng lưu trữ dữ liệu
        DataSet ds = new DataSet();

        // 1.3 Khai báo các DataAdapter su dung voi nguyen tac: 1 DataTable tuong ung voi 1 DataAdapter
        OleDbDataAdapter adpMonhoc, adpKetqua;

        // 1.4 Khai bao doi tuong CommandBuilder tuong ung de cap nhat du lieu cho bang SINHVIEN
        // Luu y : Chi khai bao CommandBuilder cho doi tuong bang cap nhat
        OleDbCommandBuilder cmbMonhoc;

        // 1.5 Khai báo đối tượng BindingSource: để liên kết và thực hiện một số chức năng trên form
        BindingSource bs = new BindingSource();
         
         public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Khoi_tao_du_lieu();
            Doc_du_lieu();
            Moc_noi_qua_he();
            Khoi_tao_bingdingSource();
            Lien_ket_dieu_khien();
        }

        private void Lien_ket_dieu_khien()
        {
            txtmamh.DataBindings.Add("text", ds, "MaMH", true);
            txttenmh.DataBindings.Add("text", ds, "TenMH", true);
            txtsotiet.DataBindings.Add("text", ds, "SoTiet", true);
        }

        private void Khoi_tao_bingdingSource()
        {
            bs.DataSource = ds;
            bs.DataMember = "MONHOC";
        }

        private void Moc_noi_qua_he()
        {
            ds.Relations.Add("FK_MH_KQ", ds.Tables["MONHOC"].Columns["MaMH"], ds.Tables["KETQUA"].Columns["MaMH"]);
            ds.Relations["FK_MH_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;


        }

        private void Doc_du_lieu()
        {
            // 1. Sao chep cau truc va du lieu cua DataTable
            adpMonhoc.FillSchema(ds, SchemaType.Source, "MONHOC");
            adpMonhoc.Fill(ds, "MONHOC");

            adpKetqua.FillSchema(ds, SchemaType.Source, "KETQUA");
            adpKetqua.Fill(ds, "KETQUA");

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            txtmamh.ReadOnly = true;
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if(!txtmamh.ReadOnly) // Them moi
            {
                DataRow[] Mang_Dong_Lien_Quan = ds.Tables["MONHOC"].Select("MaMH = '" + txtmamh.Text + "'");
                if (Mang_Dong_Lien_Quan.Length > 0)
                {
                    MessageBox.Show("Trung khoa chinh nhap lai !");
                    txtmamh.Focus();
                    return;
                }
            }
            txtmamh.ReadOnly = true;
            // Cap nhat lai viec them moi hay sua trong DataTable 
            bs.EndEdit();
            // Cap nhat lai CSDL
            int n = adpMonhoc.Update(ds, "MONHOC");
            if (n > 0)
                MessageBox.Show("Cap nhat mon hoc thanh cong");
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            // Hủy trong DataTable
            // 1. Kiểm tra có tồn tại các mẫu tin có liên quan trong KETQUA hay không trước khi hủy
            DataRow[] Mang_Dong_Lien_Quan = ds.Tables["KETQUA"].Select("MaMH = '" + txtmamh.Text + "'");
            if(Mang_Dong_Lien_Quan.Length > 0)
            {
                MessageBox.Show("Khong xoa duoc do ton tai dong lien quan trong KETQUA");
                return;
            }
            bs.RemoveCurrent();
            // Hủy trong CSDL
            int n = adpMonhoc.Update(ds, "MONHOC");
            if (n > 0)
                MessageBox.Show("Huy mon hoc thanh cong");
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmamh.ReadOnly = true;
            // Create
            bs.AddNew();
            txtmamh.Focus();
        }

        private void Khoi_tao_du_lieu()
        {
            // 1. Khởi tạo dữ liệu cho DataAdapter
            adpMonhoc = new OleDbDataAdapter("select * from monhoc", strcon);
            adpKetqua = new OleDbDataAdapter("select * from ketqua", strcon);

            // 2. Khởi tạo CommandBuilder
            cmbMonhoc = new OleDbCommandBuilder(adpMonhoc);
        }
        
       

    }
}
// Bài toán: Muốn có một đối tượng có thể thực hiện tự động các thao tác:
// 1. Liên kết các điều khiển trên form với một dòng dữ liệu trong DataTable
// ==> Việc gán dữ liệu sẽ được thực hiện tự động
// 2. Tự động di chuyển qua lại các dòng dữ liệu trong DataTable
// 3.