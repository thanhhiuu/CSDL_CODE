using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; //dùng khi có sử dụng Access

namespace BT01_Truy_xuat_Du_lieu
{
    public partial class Form2 : Form
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
        //Khai báo các command để đọc ghi dữ liệu với CSDL
        OleDbCommand cmdKhoa, cmdSinhVien, cmdKetQua;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Khởi tạo kết nối
            cnn = new OleDbConnection(strcon);
            // Đọc dữ liệu từ CSDL vào Dataset
            Tao_Cau_truc_cac_bang();
            // Móc nối quan hệ cho các DataTable
            Moc_noi_Quan_he_Cac_bang();


            // Nhập dữ liệu vào các DataTable từ các bảng trong CSDL
            Nhap_Lieu_Tu_CSDL();

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
            Object td = tblKetQua.Compute("sum(Diem)", "MaSV='" + msv + "'");
            // Lưu ý: trường hợp sinh viên không có điểm thì phương thức Compute trả về giá trị DBNull
            if (td == DBNull.Value)
                kq = 0;
            else
                kq = Convert.ToDouble(td);
            return kq;
        }
        private void Nhap_lieu_tblKetQua()
        {
            //1. Mở kết nối
            cnn.Open();

            //2. Khởi tạo đối tượng commad tương ứng để đọc dữ liệu từ table KETQUA
            cmdKetQua = new OleDbCommand("select * from ketqua", cnn);

            //3. Tạo đối tượng DataReader để tiến hành đọc từng dòng dữ liệu  trong table Kết quá
            OleDbDataReader rkq = cmdKetQua.ExecuteReader();

            //4.Tiến hành đọc dữ liệu với DataReader như sau
            while(rkq.Read())   //mỗi lần lặp thì rkq trỏ đến 1 dòng trong table KETQUA
            {
                DataRow r = tblKetQua.NewRow();
                //r[0] = rkq[0];
                //r[1] = rkq[1];
                for(int i = 0; i < rkq.FieldCount; i++)
                {
                    r[i] = rkq[i];
                }

                tblKetQua.Rows.Add(r);
            }

            //đóng DataReader và đối tượng kết nối 
            rkq.Close();
            cnn.Close();
        }
        private void Nhap_lieu_tblSinhVien()
        {
            //1. Mở kết nối
            cnn.Open();

            //2. Khởi tạo đối tượng command tương ứng để đọc dữ liệu từ table SINHVIEN
            cmdSinhVien = new OleDbCommand("select * from sinhvien", cnn);

            //3. Tạo đối tượng DataReader để tiến hành đọc từng dòng dữ liệu  trong table SINHVIEN
            OleDbDataReader rsv = cmdSinhVien.ExecuteReader();

            //4.Tiến hành đọc dữ liệu với DataReader như sau
            while (rsv.Read())   //mỗi lần lặp thì rsv trỏ đến 1 dòng trong table SINHVIEN
            {
                DataRow r = tblSinhVien.NewRow();
                for (int i = 0; i < rsv.FieldCount; i++)
                {
                    r[i] = rsv[i];
                }

                tblSinhVien.Rows.Add(r);
            }

            //đóng DataReader và đối tượng kết nối 
            rsv.Close();
            cnn.Close();
        }
        private void Nhap_lieu_tblKhoa()
        {
            //1. Mở kết nối
            cnn.Open();

            //2. Khởi tạo đối tượng commad tương ứng để đọc dữ liệu từ table KHOA
            cmdKhoa = new OleDbCommand("select * from khoa", cnn);

            //3. Tạo đối tượng DataReader để tiến hành đọc từng dòng dữ liệu  trong table KHOA
            OleDbDataReader rkh = cmdKhoa.ExecuteReader();

            //4.Tiến hành đọc dữ liệu với DataReader như sau
            while (rkh.Read())   //mỗi lần lặp thì rkh trỏ đến 1 dòng trong table KHOA
            {
                DataRow r = tblKhoa.NewRow();
                for (int i = 0; i < rkh.FieldCount; i++)
                {
                    r[i] = rkh[i];
                }

                tblKhoa.Rows.Add(r);
            }
                        //đóng DataReader và đối tượng kết nối 
            rkh.Close();
            cnn.Close();
        }
        private void Nhap_Lieu_Tu_CSDL()
        {
            Nhap_lieu_tblKhoa();
            Nhap_lieu_tblSinhVien();
            Nhap_lieu_tblKetQua();
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
                    (ctl as DateTimePicker).Value = new DateTime(2005, 1, 1);
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
                //Xóa trong DataTable
                rsv.Delete();

                //xóa trong CSDL
                cnn.Open();

                //Xóa  cách 1: sử dụng phương pháp nối chuỗi
                //string Chuoi_xoa = "delete from sinhvien where masv = '" + txtmasv.Text + "'";
                //cmdSinhVien = new OleDbCommand(Chuoi_xoa, cnn);

                //Xóa cách 2: sử dụng parametter của đối tượng command
                string Chuoi_xoa = "delete from sinhvien where masv = @msv";
                //Khai báo parametter trên như sau
                cmdSinhVien.Parameters.Add("@msv", OleDbType.Char).Value = txtmasv.Text;
                int n = cmdSinhVien.ExecuteNonQuery();
                if (n > 0)
                    MessageBox.Show("Hủy sinh viên thành công!");

                stt = 0;
                GanDuLieu(stt);
            }
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (txtmasv.ReadOnly == true) // Ghi sau khi sửa
            {
                cnn.Open();
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

                //2. sửa trong CSDL
                string Chuoi_sua = "update sinhvien set hosv=@hsv, tensv=@tsv, phai=@ph, ngaysinh=@ngsinh, noisinh=@nosinh, makh=@mk, hocbong=@hb where masv=@msv";
                cmdSinhVien = new OleDbCommand(Chuoi_sua, cnn);

                //Khai báo các parametter trên
                cmdSinhVien.Parameters.Add("@msv",OleDbType.Char).Value=txtmasv.Text;
                cmdSinhVien.Parameters.Add("@hsv", OleDbType.VarWChar).Value = txthosv.Text;
                cmdSinhVien.Parameters.Add("@tsv", OleDbType.VarWChar).Value = txttensv.Text;
                cmdSinhVien.Parameters.Add("@ph", OleDbType.Boolean).Value = chkphai.Checked;
                cmdSinhVien.Parameters.Add("@ngsinh", OleDbType.Date).Value = dtpngaysinh.Value;
                cmdSinhVien.Parameters.Add("@nosinh", OleDbType.VarWChar).Value = txtnoisinh.Text;
                cmdSinhVien.Parameters.Add("@mk", OleDbType.Char).Value = cbomakh.SelectedValue.ToString() ;
                cmdSinhVien.Parameters.Add("@hb", OleDbType.Double).Value = txthocbong.Text;

                int n = cmdSinhVien.ExecuteNonQuery();
                if(n > 0)
                {
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công!");
                }
                cnn.Close();
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
                //Thêm mới sinh viên vào CSDL
                string Chuoi_ghi = "insert into sinhvien values(@msv, @hsv, @tsv, @ph, @ngsinh, @nosinh, @mk, @hb)";
                cnn.Open();
                cmdSinhVien = new OleDbCommand(Chuoi_ghi, cnn);
                //Khai báo các Parametter
                cmdSinhVien.Parameters.Add("@msv", OleDbType.Char).Value = txtmasv.Text;
                cmdSinhVien.Parameters.Add(@"hsv", OleDbType.VarWChar).Value = txthosv.Text;
                cmdSinhVien.Parameters.Add("@tsv", OleDbType.VarWChar).Value = txttensv.Text;
                cmdSinhVien.Parameters.Add("@ph", OleDbType.Boolean).Value = chkphai.Checked;
                cmdSinhVien.Parameters.Add("@ngsinh", OleDbType.Date).Value = dtpngaysinh.Value;
                cmdSinhVien.Parameters.Add("@nosinh", OleDbType.VarWChar).Value = txtnoisinh.Text;
                cmdSinhVien.Parameters.Add("@mk", OleDbType.Char).Value = cbomakh.SelectedValue.ToString();
                cmdSinhVien.Parameters.Add("@hb", OleDbType.Double).Value = txthocbong.Text;

                int n = cmdSinhVien.ExecuteNonQuery();
                if (n > 0)
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công!");
                cnn.Close();
            } 
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            GanDuLieu(stt);
        }

    }
}
