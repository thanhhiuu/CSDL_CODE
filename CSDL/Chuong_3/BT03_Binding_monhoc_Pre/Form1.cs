using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BT03_Binding_monhoc_Pre
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
            // Phat sinh su kien Current_Changed cua BinDingSource
            bs.CurrentChanged += Bs_CurrentChanged;
        }
            
        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            // Methods nay duoc tu dong thi hanh khi co Event di chuyen mau tin
            lblSTT.Text = bs.Position + 1 + " / " + bs.Count;
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
            // 1. Su dung loop de lien ket cac dieu khien tren form voisw BinDingSource
            foreach (Control ctrl in this.Controls)
                if(ctrl is TextBox && ctrl.Name!="txtloaimh")
                    ctrl.DataBindings.Add("text", bs, ctrl.Name.Substring(3), true);

            // Dinh dang lai so tiet truoc khi hien thi
            txtsotiet.DataBindings[0].FormatString = "00 Tiet";
            // BinDing Rieng cho txtloaimh chua du lieu kieu boolean
            Binding bdmh = new Binding("text", bs, "LoaiMH", true);

            // Phat sinh Event Format va Parse cho Object dbmh
            bdmh.Format += Bdmh_Format;
            bdmh.Parse += Bdmh_Parse;

            // Them doi tuong BinDing dbmh vao dieu kien txtloaimh
            txtloaimh.DataBindings.Add(bdmh);
        }

        private void Bdmh_Parse(object sender, ConvertEventArgs e)
        {
            // Xay ra khi data duoc chuyen tu dieu khien tren Form ve DataTable (Data duoc chua trong e.Value)
            if (e.Value == null) return;
            e.Value = e.Value.ToString().ToUpper() == "Bắt buộc" ? true : false;
        }

        private void Bdmh_Format(object sender, ConvertEventArgs e)
        {
            // Xay ra khi du lieu (e.Value) duoc chuyen tu DataTable den form hoac khi chinh sua data cua Control tren Form 
            if (e.Value == DBNull.Value || e.Value == null) return;
            e.Value = (Boolean)e.Value ? "Bắt buộc" : "Tự chọn";
        }

        private void Khoi_tao_bingdingSource()
        {
            bs.DataSource = ds;
            bs.DataMember = "MONHOC";

            bdnmonhoc.BindingSource = bs;
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

        private void btndau_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
             bs.MovePrevious();
        }

        private void btncuoi_Click(object sender, EventArgs e)
        {
           bs.MoveLast();
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            txtmamh.ReadOnly = true;
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (!txtmamh.ReadOnly) // Them moi
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
            if (Mang_Dong_Lien_Quan.Length > 0)
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
            txtmamh.ReadOnly = false;
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
// Cac van de thuc hien trong bai tap:
// 1. Su dung loop de lien ket cac dieu khien tren form voisw BinDingSource
// 2. Tao cac doi tuong BinDing lien ket voi dieu khien textBox chua du lieu kieu boolean
// 3. Cach phat sinh su kien Current_Changed cuar BindDingSource va su kien hien hanh tren Object BinDingSource
// 3.1 Event Curren_Changed: Xay ra khi co su di chuyen mau tin hien hanh tren( doi tuong BinDingSource
// 3.2 Thuoc tinh Position: Cho biet so thu tu cua mau tin hien hanh cua Objaect BinDingSource
// 3.3 Envent Format cua Object BinDing: Xay ra khi data duoc chuyen doi tu DataTable lem form (Hoac khi hieu chinh data
// // => Luu y: Neu data can chuyen khong co trong DataTable => Gia tri cua du lieu laf DBNull
// 3.4 Event Parse: Xay ra khi du lieu duoc chuyen tu form ve dataTable
// 4. Using control BinDingNavigator de di chuyen data ve DataTable
// 5. Using cac Methosd cua Object BinDingSource
// + AddNew(): Them moi dong data
// + EndEdit: Ghi sau khi su hay them moi
// + CancelEdit: Huy bo thao tac vua thuc hien
// + Remove: Huy mau hien hanh tren Form trong DataTable