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

namespace BT01_Mo_hinh_ngat_ket_noi_sv
{
    public partial class Form1 : Form
    {
        // Khai báo các đối tượng cần sử dụng
        // 1.1 Chuỗi kết nối
        string strcon = @"provider=microsoft.jet.oledb.4.0; data source=..\..\..\Data\QLSINHVIEN.mdb";

        // 1.2 Khai báo các đối tượng lưu trữ dữ liệu
        DataSet ds = new DataSet();

        // 1.3 Khai báo các DataAdapter su dung voi nguyen tac: 1 DataTable tuong ung voi 1 DataAdapter
        OleDbDataAdapter adpKhoa, adpSinhvien, adpKetqua;

        // 1.4 Khai bao doi tuong CommandBuilder tuong ung de cap nhat du lieu cho bang SINHVIEN
        // Luu y : Chi khai bao CommandBuilder cho doi tuong bang cap nhat
        OleDbCommandBuilder cmbSinhvien;
        int stt = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Khoi_tao_doi_tuong();
            Doc_du_lieu();
            Moc_noi_quan_he();
            Khoi_tao_Combobox();
            stt = 0;
            GanDuLieu(stt);
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
        public void GanDuLieu(int stt)
        {
            // Lấy dòng dữ liệu thứ stt trong tblSinhVien
            DataRow rsv = ds.Tables["SINHVIEN"].Rows[stt];
            txtmasv.Text = rsv["MaSV"].ToString();
            txthosv.Text = rsv["HoSV"].ToString();
            txttensv.Text = rsv["TenSV"].ToString();
            chkphai.Checked = (Boolean)rsv["Phai"];
            dtpngaysinh.Value = (DateTime)rsv["NgaySinh"];
            txtnoisinh.Text = rsv["NoiSinh"].ToString();
            cbomakh.SelectedValue = rsv["MaKH"].ToString();
            txthocbong.Text = rsv["HocBong"].ToString();

            // Tính tổng điểm
            txttongdiem.Text = Tong_diem(txtmasv.Text).ToString();

            // Thể hiện số thứ tự mẫu tin hiện hành
            lblSTT.Text = (stt + 1) + " / " + ds.Tables["SINHVIEN"].Rows.Count;
        }
        private void Khoi_tao_Combobox()
        {
            cbomakh.DisplayMember = "TenKH";
            cbomakh.ValueMember = "MaKH";
            cbomakh.DataSource = ds.Tables["KHOA"];
        }
        private void Moc_noi_quan_he()
        {
            // Tạo quan hệ giữa tblKhoa và tblSinhVien
            ds.Relations.Add("FK_KH_SV", ds.Tables["KHOA"].Columns["MaKH"], ds.Tables["SINHVIEN"].Columns["MaKH"], true);

            // Tạo quan hệ giữa tblSinhVien và tblKetQua
            ds.Relations.Add("FK_SV_KQ", ds.Tables["SINHVIEN"].Columns["MaSV"], ds.Tables["KETQUA"].Columns["MaSV"], true);

            // Loại bỏ Cascade delete trong các quan hệ
            ds.Relations["FK_KH_SV"].ChildKeyConstraint.DeleteRule = Rule.None;
            ds.Relations["FK_SV_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;
        }

        private void Doc_du_lieu()
        {
            //1. Đọc dữ liệu của bảng Khoa
            //1.1 Sao chép cấu trúc của table KHOA vào DataTable trong Dataset ds
            adpKhoa.FillSchema(ds, SchemaType.Source, "KHOA");
            //1.2 Sao chép du lieu của table SINHVIEN vào DataTable trong Dataset ds
            adpKhoa.Fill(ds, "KHOA");

            //1. Đọc dữ liệu của bảng Khoa
            adpSinhvien.FillSchema(ds, SchemaType.Source, "SINHVIEN");
            adpSinhvien.Fill(ds, "SINHVIEN");

            //1.3 Sao chép cấu trúc của table KETQUA vào DataTable trong Dataset ds
            //1. Đọc dữ liệu của bảng Khoa

            adpKetqua.FillSchema(ds, SchemaType.Source, "KETQUA");
            adpKetqua.Fill(ds, "KETQUA");


        }

        private void Khoi_tao_doi_tuong()
        {
            // 1. Khoi tao doi tuong DataAdapter
            adpKhoa = new OleDbDataAdapter("select * from khoa", strcon);
            adpSinhvien = new OleDbDataAdapter("select * from sinhvien", strcon);
            adpKetqua = new OleDbDataAdapter("select * from ketqua", strcon);
            // 2. Khoi tao doi tuong CommandBuilter
            cmbSinhvien = new OleDbCommandBuilder(adpSinhvien);
        }


        private void btntruoc_Click(object sender, EventArgs e)
        {
            if(stt == 0)
            {
                stt = ds.Tables["SINHVIEN"].Rows.Count - 1;
                GanDuLieu(stt);
                return;

            }
           else
            {
                stt--;
                GanDuLieu(stt);
            }
        }
        private void btnsau_Click(object sender, EventArgs e)
        {
            if (stt == ds.Tables["SINHVIEN"].Rows.Count - 1)
            {
                stt = 0;
                GanDuLieu(stt);
                return;

            }
            else
            {
                stt++;
                GanDuLieu(stt);
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmasv.ReadOnly = false;
            foreach (Control ctl in this.Controls)
                if (ctl is TextBox)
                    (ctl as TextBox).Clear();
                else if (ctl is CheckBox)
                    (ctl as CheckBox).Checked = true;
                else if (ctl is ComboBox)
                    (ctl as ComboBox).SelectedIndex = 0;
                else if (ctl is DateTimePicker)
                    (ctl as DateTimePicker).Value = new DateTime(2005, 1, 1);
            txtmasv.Focus();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            // Xác định dòng cần huỷ ==> sử dụng hàm Find tìm theo khoá chính của DataTable
            DataRow rsv = ds.Tables["SINHVIEN"].Rows.Find(txtmasv.Text);
            // Cần kiểm tra: Nếu rsv có tồn tại những dòng liên quan trong tblKetQua => không cho xoá. Ngược lại thì cho xoá
            // Sử dụng hàm GetChildRow để kiểm tra những dòng liên quan có tồn tại hay không? Giá trị trả về của hàm này là một mảng
            DataRow[] Mang_dong_Lien_quan = rsv.GetChildRows("FK_SV_KQ");
            if (Mang_dong_Lien_quan.Length > 0) // Có tồn tại những dòng liên quan trong tblKetQua
                MessageBox.Show("Không xoá được do tồn tại những dòng liên quan trong kETQUA");
            else
            {
                //Xóa trong DataTable
                rsv.Delete();

                //xóa trong CSDL
                int n = adpSinhvien.Update(ds, "SINHVIEN");
                if(n > 0)
                    MessageBox.Show("Huy thanh vien thanh cong");
                stt = 0;
                GanDuLieu(stt);
            }
        }


        private void btnghi_Click(object sender, EventArgs e)
        {
            
            DataTable tblSinhVien = ds.Tables["SINHVIEN"]; 
            if (txtmasv.ReadOnly == true) // Ghi sau khi sửa
            {
                // Xác định dòng cần sửa
                DataRow rsv = tblSinhVien.Rows.Find(txtmasv.Text);

                // 1. Tiến hành sửa trong DataTable
                rsv["HoSV"] = txthosv.Text;
                rsv["TenSV"] = txttensv.Text;
                rsv["Phai"] = chkphai.Checked;
                rsv["NgaySinh"] = dtpngaysinh.Value;
                rsv["NoiSinh"] = txtnoisinh.Text;
                rsv["MaKH"] = cbomakh.SelectedValue.ToString();
                rsv["HocBong"] = txthocbong.Text;
            }
            else // Ghi sau khi thêm mới
            {
                // Kiểm tra khoá chính có trùng hay không?
                DataRow rsv = tblSinhVien.Rows.Find(txtmasv.Text);
                if (rsv != null) // Đã trùng khoá chính
                {
                    MessageBox.Show("Trùng khoá chính. Nhập lại Mã SV");
                    txtmasv.Focus();
                    return;
                }
                // Tạo mới sinh viên
                rsv = tblSinhVien.NewRow();
                rsv["MaSV"] = txtmasv.Text;
                rsv["HoSV"] = txthosv.Text;
                rsv["TenSV"] = txttensv.Text;
                rsv["Phai"] = chkphai.Checked;
                rsv["NgaySinh"] = dtpngaysinh.Value;
                rsv["NoiSinh"] = txtnoisinh.Text;
                rsv["MaKH"] = cbomakh.SelectedValue.ToString();
                rsv["HocBong"] = txthocbong.Text;
                ds.Tables["SINHVIEN"].Rows.Add(rsv);
                txtmasv.ReadOnly = true;


                
            }
            int n = adpSinhvien.Update(ds, "SINHVIEN");
            if (n > 0)
                MessageBox.Show("Cap nhat thanh vien thanh cong");
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            GanDuLieu(stt);
        }

    }
}

