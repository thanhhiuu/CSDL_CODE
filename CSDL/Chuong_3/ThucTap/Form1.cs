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
using System.Data.SqlClient;

namespace ThucTap
{
    public partial class Form1 : Form
    {
        // Kết nối CSDL bằng sql 
        string stron = @"server=HIUIT; database=QL_SVCSDL; integrated security = true";

        // Khoi tao dataset
        DataSet ds = new DataSet();
        // SqlAdapter 
        SqlDataAdapter adpKhoa, adpSinhVien, adpKetQua;
        // SqlCommadBuider
        SqlCommandBuilder cmdSinhVien;
        // Khoi tao data BinDingSource
        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            bs.CurrentChanged += Bs_CurrentChanged;
        }

        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            lblSTT.Text = bs.Position + 1 + " / " + bs.Count;

            // Tinh tong diem
            txttongdiem.Text = Tong_diem(txtmasv.Text).ToString();

        }
        private double Tong_diem(string msv)
        {
            double kq = 0;
            Object td = ds.Tables["KETQUA"].Compute("sum(Diem)", "MaSV='" + msv + "'");
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

        }

        private void Lien_ket_dieu_khien()
        {
            // Dung vòng lặp để liên kết dự liệu của BinDingSoucre với các điều khiển
            foreach (Control ctr in this.Controls)
                if (ctr is TextBox && ctr.Name != "txttongdiem" && ctr.Name != "txtphai")
                    ctr.DataBindings.Add("text", bs, ctr.Name.Substring(3), true);
                else if (ctr is CheckBox)
                    ctr.DataBindings.Add("selectedvalue", bs, ctr.Name.Substring(3), true);
            else if(ctr is DateTimePicker) 
                    ctr.DataBindings.Add("value", bs, ctr.Name.Substring(3), true);

            // Binding cho doi tuong txtphai
            Binding bdphai = new Binding("text", bs, "phai", true);
            bdphai.Format += Bdphai_Format;
            bdphai.Parse += Bdphai_Parse;

            // Them doi tuong BinDing vao dieu khien txtphai
            txtphai.DataBindings.Add(bdphai);
            // Dinh dang lai txthocbong hien thi
            txthocbong.DataBindings[0].FormatString = "#,##0 đ";   
        }

        private void Bdphai_Parse(object sender, ConvertEventArgs e)
        {
            if (e.Value == null) return;
            e.Value = e.Value.ToString().ToUpper() == "Nam" ? true : false;
        }

        private void Bdphai_Format(object sender, ConvertEventArgs e)
        {
            if(e.Value == DBNull.Value || e.Value == null) return;
            e.Value = (Boolean)e.Value ? "Nam" : "Nữ";
        }

        private void Moc_noi_qua_he()
        {
            ds.Relations.Add("FK_KH_SV", ds.Tables["KHOA"].Columns["MaKH"], ds.Tables["SINHVIEN"].Columns["MaKH"]);
            ds.Relations.Add("FK_SV_KQ", ds.Tables["SINHVIEN"].Columns["MaSV"], ds.Tables["KETQUA"].Columns["MaSV"]);

            ds.Relations["FK_SV_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;
        }

        private void Khoi_tao_bingdingSource()
        {
            bs.DataSource = ds;
            bs.DataMember = "SINHVIEN";
        }

        private void Doc_du_lieu()
        {
            adpKhoa.FillSchema(ds, SchemaType.Source, "KHOA");
            adpKhoa.Fill(ds, "KHOA");

            adpSinhVien.FillSchema(ds, SchemaType.Source, "SINHVIEN");
            adpSinhVien.Fill(ds, "SINHVIEN");

            adpKetQua.FillSchema(ds, SchemaType.Source, "KETQUA");
            adpKetQua.Fill(ds, "KETQUA");
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
            // Kiểm tra xem dữ liệu có tồn tại trước đó hay khong 
            DataRow r = (bs.Current as DataRowView).Row;
            DataRow[] Mang_dong_hien_hanh = r.GetChildRows("FK_SV_KQ");
            if(Mang_dong_hien_hanh.Length > 0) 
            {
                MessageBox.Show("Khong the xoa do da ton tai !");
            }
            bs.RemoveCurrent();
            // Update lai du lieu SINHVIEN
            int a = adpSinhVien.Update(ds, "SINHVIEN");
            if(a > 0)
            {
                MessageBox.Show("Huy thanh cong");
            }
        }
        

        private void btnghi_Click(object sender, EventArgs e)
        {
            // Thêm mới
            if(!txtmasv.ReadOnly)
            {
                DataRow r = ds.Tables["SINHVIEN"].Rows.Find(txtmasv.Text);
                if(r != null)
                {
                    MessageBox.Show("Khongghi duoc vi da trung ma sinh vien");
                    txtmasv.Focus();
                    return;
                }
                txtmasv.ReadOnly = true;
                bs.EndEdit();

                // Update du lieu SINHVIEN
                int a = adpSinhVien.Update(ds, "SINHVIEN");
                if( a > 0)
                {
                    MessageBox.Show("Ghi thanh cong !");
                }

            }
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            txtmasv.ReadOnly = true;
            Close();
        }


        private void Khoi_tao_combobox()
        {
            cbomakh.DataSource = ds.Tables["KHOA"];
            cbomakh.ValueMember = "MaKH";
            cbomakh.DisplayMember = "TenKH";
        }

        private void Khoi_tao_du_lieu()
        {
            adpKhoa = new SqlDataAdapter("select * from khoa", stron);
            adpSinhVien = new SqlDataAdapter("select * from sinhvien", stron);
            adpKetQua = new SqlDataAdapter("select * from ketqua", stron);

            // Khởi tạo commandBuilder
            cmdSinhVien = new SqlCommandBuilder(adpSinhVien);
        }
    }
}
