using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb; // Sử dụng với Access

namespace BT01_Truy_xuat_Du_lieu
{
    public partial class Form1 : Form
    {
        // Bài tập này thực hiện theo mô hình kết nối
        //1. Khai báo các đối tượng cần sử dụng
        // 1.1. Chuỗi kết nối
        string strcon = @"provider=microsoft.jet.oledb.4.0; data source=..\..\..\Data\QLSINHVIEN.mdb";
        //1.2. Đối tượng kết nối
        OleDbConnection cnn;
        //1.3. Khai báo các đối tượng lưu dữ liệu
        DataSet ds = new DataSet();
        DataTable tblKhoa = new DataTable("KHOA");
        DataTable tblSinhVien = new DataTable("SINHVIEN");
        DataTable tblKetQua = new DataTable("KETQUA");
        int stt = -1;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo kết nối
            cnn = new OleDbConnection(strcon);
            // Đọc dữ liệu từ CSDL vào Dataset
            Tao_Cau_truc_cac_bang();
            // Móc nối quan hệ cho các DataTable
            Moc_noi_Quan_he_Cac_bang();

            // Nhập dữ liệu vào các DataTable từ tập tin .txt
            Nhap_Lieu_Tu_Tap_tin_Text();

            // Nhập dữ liệu vào các DataTable từ các bảng trong CSDL
            //Nhap_Lieu_Tu_CSDL();

            // Khởi tạo combobox
            Khoi_tao_Combobox();

            // Hiển thị dữ liệu
            stt = 0;
            GanDuLieu(stt);
        }
        private void Khoi_tao_Combobox()
        {
            cbomakh.DisplayMember = "TenKH";
            cbomakh.ValueMember = "MaKH";
            cbomakh.DataSource = tblKhoa;
        }
        public void GanDuLieu(int stt)
        {
            // Lấy dòng dữ liệu thứ stt trong tblSinhVien
            DataRow rsv = tblSinhVien.Rows[stt];
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
            lblSTT.Text = (stt + 1) + " / " + tblSinhVien.Rows.Count;
        }
        private double Tong_diem(string msv)
        {
            double kq = 0;
            Object td = tblKetQua.Compute("sum(Diem)","MaSV='"+msv+"'");
            // Lưu ý: trường hợp sinh viên không có điểm thì phương thức Compute trả về giá trị DBNull
            if (td == DBNull.Value)
                kq = 0;
            else
                kq = Convert.ToDouble(td);
            return kq;
        }
        private void Nhap_Lieu_Tu_Tap_tin_Text()
        {
            Nhap_lieu_tblKhoa();
            Nhap_lieu_tblSinhVien();
            Nhap_lieu_tblKetQua();
        }
        private void Nhap_lieu_tblKetQua()
        {
            // Nhập liệu cho tblKetQua => Đọc dữ liệu từ tập tin KETQUA.txt
            string[] Mang_KQ = File.ReadAllLines(@"..\..\..\data\KETQUA.txt");
            foreach (string Chuoi_KQ in Mang_KQ)
            {
                // Tách Chuoi_KQ thành các thành phần tương ứng với các cột trong tblKetQua
                string[] Mang_thanh_phan = Chuoi_KQ.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                // Tạo một dòng mới có cấu trúc giống cấu trúc của một dòng trong tblKetQua
                DataRow rkq = tblKetQua.NewRow();

                // Gán giá trị cho các cột của dòng mới tạo ra
                for (int i = 0; i < Mang_thanh_phan.Length; i++)
                    rkq[i] = Mang_thanh_phan[i];

                // Thêm dòng vừa tạo vào tblKetQua
                tblKetQua.Rows.Add(rkq);
            }
        }
        private void Nhap_lieu_tblSinhVien()
        {
            // Nhập liệu cho tblSinhVien => Đọc dữ liệu từ tập tin SINHVIEN.txt
            string[] Mang_SV = File.ReadAllLines(@"..\..\..\data\SINHVIEN.txt");
            foreach (string Chuoi_SV in Mang_SV)
            {
                // Tách Chuoi_SV thành các thành phần tương ứng với các cột trong tblSinhVien
                string[] Mang_thanh_phan = Chuoi_SV.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                // Tạo một dòng mới có cấu trúc giống cấu trúc của một dòng trong tblSinhVien
                DataRow rsv = tblSinhVien.NewRow();

                // Gán giá trị cho các cột của dòng mới tạo ra
                for (int i = 0; i < Mang_thanh_phan.Length; i++)
                    rsv[i] = Mang_thanh_phan[i];

                // Thêm dòng vừa tạo vào tblSinhVien
                tblSinhVien.Rows.Add(rsv);
            }
        }
        private void Nhap_lieu_tblKhoa()
        {
            // Nhập liệu cho tblKhoa => Đọc dữ liệu từ tập tin KHOA.txt
            string[] Mang_Khoa = File.ReadAllLines(@"..\..\..\data\KHOA.txt");
            foreach (string Chuoi_khoa in Mang_Khoa)
            {
                // Tách Chuoi_khoa thành các thành phần tương ứng với MaKH và TenKH
                string[] Mang_thanh_phan = Chuoi_khoa.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                // Tạo một dòng mới có cấu trúc giống cấu trúc của một dòng trong tblKhoa
                DataRow rkh = tblKhoa.NewRow();

                // Gán giá trị cho các cột của dòng mới tạo ra
                rkh[0] = Mang_thanh_phan[0];
                rkh[1] = Mang_thanh_phan[1];

                // Thêm dòng vừa tạo vào tblKhoa
                tblKhoa.Rows.Add(rkh);
            }
        }
        private void Nhap_Lieu_Tu_CSDL()
        {
            
        }
        private void Moc_noi_Quan_he_Cac_bang()
        {
            // Tạo quan hệ giữa tblKhoa và tblSinhVien
            ds.Relations.Add("FK_KH_SV", ds.Tables["KHOA"].Columns["MaKH"], ds.Tables["SINHVIEN"].Columns["MaKH"], true);

            // Tạo quan hệ giữa tblSinhVien và tblKetQua
            ds.Relations.Add("FK_SV_KQ", ds.Tables["SINHVIEN"].Columns["MaSV"], ds.Tables["KETQUA"].Columns["MaSV"], true);

            // Loại bỏ Cascade delete trong các quan hệ
            ds.Relations["FK_KH_SV"].ChildKeyConstraint.DeleteRule = Rule.None;
            ds.Relations["FK_SV_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;
        }
        private void Tao_Cau_truc_cac_bang()
        {
            // Tạo cấu trúc cho DataTable tương ứng với bảng KHOA
            tblKhoa.Columns.Add("MaKH", typeof(string));
            tblKhoa.Columns.Add("TenKH", typeof(string));
            // Tạo khoá chính cho tblKhoa
            tblKhoa.PrimaryKey = new DataColumn[] { tblKhoa.Columns["MaKH"] };

            // Tạo cấu trúc cho DataTable tương ứng với bảng SINHVIEN
            tblSinhVien.Columns.Add("MaSV", typeof(string));
            tblSinhVien.Columns.Add("HoSV", typeof(string));
            tblSinhVien.Columns.Add("TenSV", typeof(string));
            tblSinhVien.Columns.Add("Phai", typeof(Boolean));
            tblSinhVien.Columns.Add("NgaySinh", typeof(DateTime));
            tblSinhVien.Columns.Add("NoiSinh", typeof(string));
            tblSinhVien.Columns.Add("MaKH", typeof(string));
            tblSinhVien.Columns.Add("HocBong", typeof(double));
            // Tạo khoá chính cho tblSinhVien
            tblSinhVien.PrimaryKey = new DataColumn[] { tblSinhVien.Columns["MaSV"] };

            // Tạo cấu trúc cho DataTable tương ứng với bảng KETQUA
            tblKetQua.Columns.Add("MaSV", typeof(string));
            tblKetQua.Columns.Add("MaMH", typeof(string));
            tblKetQua.Columns.Add("Diem", typeof(Single));
            tblKetQua.PrimaryKey = new DataColumn[] { tblKetQua.Columns["MaSV"], tblKetQua.Columns["MaMH"] };

            // Thêm các DataTable vào Dataset
            //ds.Tables.Add(tblKhoa);
            //ds.Tables.Add(tblSinhVien);
            //ds.Tables.Add(tblKetQua);

            // Thêm đồng thời nhiều DataTable vào Dataset
            ds.Tables.AddRange(new DataTable[] { tblKhoa, tblSinhVien, tblKetQua });
        }
        private void btntruoc_Click(object sender, EventArgs e)
        {
            stt--;
            GanDuLieu(stt);
        }
        private void btnsau_Click(object sender, EventArgs e)
        {
            stt++;
            GanDuLieu(stt);
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
                    (ctl as DateTimePicker).Value = new DateTime(2005,1,1);
            txtmasv.Focus();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            // Xác định dòng cần huỷ ==> sử dụng hàm Find tìm theo khoá chính của DataTable
            DataRow rsv = tblSinhVien.Rows.Find(txtmasv.Text);
            // Cần kiểm tra: Nếu rsv có tồn tại những dòng liên quan trong tblKetQua => không cho xoá. Ngược lại thì cho xoá
            // Sử dụng hàm GetChildRow để kiểm tra những dòng liên quan có tồn tại hay không? Giá trị trả về của hàm này là một mảng
            DataRow[] Mang_dong_Lien_quan = rsv.GetChildRows("FK_SV_KQ");
            if (Mang_dong_Lien_quan.Length > 0) // Có tồn tại những dòng liên quan trong tblKetQua
                MessageBox.Show("Không xoá được do tồn tại những dòng liên quan trong kETQUA");
            else
            {
                rsv.Delete();
                stt = 0;
                GanDuLieu(stt);
            }    
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (txtmasv.ReadOnly == true) // Ghi sau khi sửa
            {
                // Xác định dòng cần sửa
                DataRow rsv = tblSinhVien.Rows.Find(txtmasv.Text);
                // Tiến hành sửa
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
                tblSinhVien.Rows.Add(rsv);
                txtmasv.ReadOnly = true;
            }
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            GanDuLieu(stt);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ghi tập tin
            // Lưu ý: tblSinhVien.Rows => tập hợp dòng (Không phải là mảng) => chuyển thành mảng => ItemArray (là mảng tương ứng 1 dòng trong dataTable)
            //        Để chuyển một mảng thành chuỗi => Join => Thí du: có mảng 1,2,3 = dùng join => chuyển thành chuỗi: "1|2|3"
            // Thuật toán ghi một DataTable vào tập tin
            // 1. Khai báo một mảng chuỗi với mỗi phần tử sẽ chứa một chuỗi tương ứng với 1 dòng trong DataTable
            // 2. Duyệt qua tập hợp Rows của DataTable và đưa từng dòng vào mảng chuỗi với hàm Join
            // 3. Sử dụng phương thức WriteAllLines để ghi mảng chuỗi vào tập tin SINHVIEN.txt
            
            List<string> Mang_Chuoi_Sinh_vien = new List<string>();
            foreach (DataRow rsv in tblSinhVien.Rows)
            {
                // Biến mảng thành chuỗi
                string Chuoi_dong_Sinh_vien = string.Join("|", rsv.ItemArray);
                // Thêm chuỗi trên vào Mang_chuoi_Sinh_vien
                Mang_Chuoi_Sinh_vien.Add(Chuoi_dong_Sinh_vien);
            }
            // Ghi Mang_chuoi_Sinh_vien vào tập tin
            File.WriteAllLines(@"..\..\..\Data\SINHVIEN.txt", Mang_Chuoi_Sinh_vien);
        }
    }
}
