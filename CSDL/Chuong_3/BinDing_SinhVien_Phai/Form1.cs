using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BinDing_SinhVien_Phai
{
    public partial class Form1 : Form
    {


        // Khai báo các đối tượng cần sử dụng
        // 1.1 Chuỗi kết nối
        string strcon = @"provider=microsoft.jet.oledb.4.0; data source=..\..\..\Data\QLSINHVIEN.mdb";

        // 1.2 Khai báo các đối tượng lưu trữ dữ liệu
        DataSet ds = new DataSet();

        // 1.3 Khai báo các DataAdapter su dung voi nguyen tac: 1 DataTable tuong ung voi 1 DataAdapter
        OleDbDataAdapter adpSinhvien, adpKetqua, adpKhoa;

        // 1.4 Khai bao doi tuong CommandBuilder tuong ung de cap nhat du lieu cho bang SINHVIEN
        // Luu y : Chi khai bao CommandBuilder cho doi tuong bang cap nhat
        OleDbCommandBuilder cmbSinhvien;

        // 1.5 Khai báo đối tượng Bindi ngSource: để liên kết và thực hiện một số chức năng trên form
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            bs.CurrentChanged += Bs_CurrentChanged;
        }

        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            // Methods nay duoc tu dong thi hanh khi co Event di chuyen mau tin
            lblSTT.Text = bs.Position + 1 + " / " + bs.Count;
            // Tính tổng điểm
            txttongdiem.Text = Tong_diem(txtmasv.Text).ToString();
        }
        private double Tong_diem(string msv)
        {
            double kq = 0;
            Object td = ds.Tables["KETQUA"].Compute("sum(Diem)", "MaSV='" + msv + "'");
            // Lưu ý: trường hợp sinh viên không có điểm thì phương thức Compute trả về giá trị DBNull
            if (td == DBNull.Value)
                kq = 0;
            else
                kq = Convert.ToDouble(td);
            return kq;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            Khoi_tao_du_lieu();
            Doc_du_lieu();
            Moc_noi_qua_he();
            Khoi_tao_bingdingSource();
            Lien_ket_dieu_khien();
            Khoi_tao_combobox();
            txttongdiem.Text = Tong_diem(txtmasv.Text).ToString();
        }
        private void Khoi_tao_combobox()
        {
            cbomakh.DisplayMember = "TenKH";
            cbomakh.ValueMember = "MaKH";
            cbomakh.DataSource = ds.Tables["KHOA"];
        }

        private void Khoi_tao_du_lieu()
        {
            // 1. Khởi tạo dữ liệu cho DataAdapter
            adpKhoa = new OleDbDataAdapter("select * from khoa", strcon);
            adpSinhvien = new OleDbDataAdapter("select * from sinhvien", strcon);
            adpKetqua = new OleDbDataAdapter("select * from ketqua", strcon);



            // 2. Khởi tạo CommandBuilder
            cmbSinhvien = new OleDbCommandBuilder(adpSinhvien);
        }
        private void Lien_ket_dieu_khien()
        {
            // 1. Su dung loop de lien ket cac dieu khien tren form voisw BinDingSource
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox && ctrl.Name != "txttongdiem" && ctrl.Name!= "txtphai")
                    ctrl.DataBindings.Add("text", bs, ctrl.Name.Substring(3), true);
                else if (ctrl is CheckBox)
                   ctrl.DataBindings.Add("selectedvalue", bs, ctrl.Name.Substring(3), true);
                else if (ctrl is DateTimePicker)
                    ctrl.DataBindings.Add("value", bs, ctrl.Name.Substring(3), true);

            // Binding cho điều khiển txtphai
            Binding bdphai = new Binding("text", bs, "Phai", true);
            bdphai.Format += Bdphai_Format;
            bdphai.Parse += Bdphai_Parse;

            // Them doi tuong BinDing dbmh vao dieu kien txtloaimh
            txtphai.DataBindings.Add(bdphai);
            // Dinh dang lai hoc bong truoc khi hien thi
            txthocbong.DataBindings[0].FormatString = "#,##0 đ ";


        }

            private void Bdphai_Parse(object sender, ConvertEventArgs e)
            {
                if (e.Value == null) return;
                e.Value = e.Value.ToString().ToUpper() == "Nam" ? true : false;
            }

            private void Bdphai_Format(object sender, ConvertEventArgs e)
            {
                if (e.Value == DBNull.Value || e.Value == null) return;
                e.Value = (Boolean)e.Value ? "Nam" : "Nữ";
            }

        private void Khoi_tao_bingdingSource()
        {
            bs.DataSource = ds;
            bs.DataMember = "SINHVIEN";



            // Khoi tao doi tuong BidingNav
            //bdnmonhoc.BindingSource = bs;
        }
        private void Doc_du_lieu()
        {
            // 1. Sao chep cau truc va du lieu cua DataTable
            adpKhoa.FillSchema(ds, SchemaType.Source, "KHOA");
            adpKhoa.Fill(ds, "KHOA");

            adpSinhvien.FillSchema(ds, SchemaType.Source, "SINHVIEN");
            adpSinhvien.Fill(ds, "SINHVIEN");

            adpKetqua.FillSchema(ds, SchemaType.Source, "KETQUA");
            adpKetqua.Fill(ds, "KETQUA");


        }
        private void Moc_noi_qua_he()
        {
            ds.Relations.Add("FK_KH_SV", ds.Tables["KHOA"].Columns["MaKH"], ds.Tables["SINHVIEN"].Columns["MaKH"]);
            ds.Relations.Add("FK_SV_KQ", ds.Tables["SINHVIEN"].Columns["MaSV"], ds.Tables["KETQUA"].Columns["MaSV"]);

            ds.Relations["FK_SV_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;



        }


        private void btntruoc_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmasv.ReadOnly = false;
            bs.AddNew();

            cbomakh.SelectedIndex = 0;
            txtmasv.Focus();


        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            // Hủy trong DataTable
            // 1. Kiểm tra có tồn tại các mẫu tin có liên quan trong KETQUA hay không trước khi hủy
            // Dong hien hanh dang hien thi tren Form => bs.Current co kie Object
            DataRow r = (bs.Current as DataRowView).Row;
            DataRow[] Mang_dong_lien_quan = r.GetChildRows("FK_SV_KQ");
            if (Mang_dong_lien_quan.Length > 0)
            {
                MessageBox.Show("Khong xoa duoc do ton tai dong lien quan trong KETQUA");
                return;
            }
            bs.RemoveCurrent();
            // Hủy trong CSDL
            int n = adpSinhvien.Update(ds, "SINHVIEN");
            if (n > 0)
                MessageBox.Show("Huy sinh vien thanh cong");
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (!txtmasv.ReadOnly) // Them moi
            {
                DataRow r = ds.Tables["SINHVIEN"].Rows.Find(txtmasv.Text);
                if (r != null)
                {
                    MessageBox.Show("Trung khoa chinh nhap lai !");
                    txtmasv.Focus();
                    return;
                }
            }
            txtmasv.ReadOnly = true;
            // Cap nhat lai viec them moi hay sua trong DataTable 
            bs.EndEdit();
            // Cap nhat lai CSDL
            int n = adpSinhvien.Update(ds, "SINHVIEN");
            if (n > 0)
                MessageBox.Show("Cap nhat sinh vien thanh cong");
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            txtmasv.ReadOnly = true;
           Close();
        }
    }
}
