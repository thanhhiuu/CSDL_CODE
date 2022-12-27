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

namespace BT_01
{
    public partial class Form1 : Form
    {
        // Khai báo các đối tượng 
        // 1. Khai báo một biến (đối tượng) DataSet
        DataSet ds = new DataSet();
        // 2. Khai báo các DataTable tương ứng với các bảng có chứa dữ liệu
        DataTable tblKhoa = new DataTable("KHOA");
        DataTable tblSinhVien = new DataTable("SINHVIEN");
        DataTable tblKetQua = new DataTable("KETQUA");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tạo bảng cấu trúc các bảng
            Tao_Cau_Truc_Cac_Bang();
            Moc_Noi_Quan_He_Cac_Bang();
            Nhap_Lieu_Cho_Cac_Bang();
        }

        private void Nhap_Lieu_Cho_Cac_Bang()
        {
            Nhap_Lieu_tblKhoa();
            Nhap_Lieu_tblSinhVien();
            Nhap_Lieu_tblKetQua();
        }

        private void Nhap_Lieu_tblKetQua()
        {
            // Nhap lieu cho tblKhoa => Doc du lieu tu tap tin KETQUA.txt
            string[] Mang_KQ = File.ReadAllLines(@"..\..\..\data\KETQUA.txt");
            foreach (string Chuoi_KQ in Mang_KQ)
            {
                // Tach chuoi khoa thanh cac thanh phan tuong ung voi cac cot tblKetQua
                string[] Mang_Thanh_Phan = Chuoi_KQ.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                // Tao 1 dong moi co cau truc giong cau truc cua 1 dong trong tblKetQua
                DataRow rkq = tblKetQua.NewRow();
                // Gan gia tri cho cac cot cua dong moi tao ra
                // Cach 1:
                //rkh[0] = Mang_Thanh_Phan[0];
                //rkh[1] = Mang_Thanh_Phan[1];
                // Cach 2:
                for (int i = 0; i < Mang_Thanh_Phan.Length; i++)
                {
                    rkq[i] = Mang_Thanh_Phan[i];
                }


                // Them dong vua tao vao tblSinhVien
                tblKetQua.Rows.Add(rkq);
            }
        }

        private void Nhap_Lieu_tblSinhVien()
        {
            // Nhap lieu cho tblKhoa => Doc du lieu tu tap tin SINHVIEN.txt
            string[] Mang_SV = File.ReadAllLines(@"..\..\..\data\SINHVIEN.txt");
            foreach (string Chuoi_SV in Mang_SV)
            {
                // Tach chuoi khoa thanh cac thanh phan tuong ung voi cac cot tblSinhVien
                string[] Mang_Thanh_Phan = Chuoi_SV.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                // Tao 1 dong moi co cau truc giong cau truc cua 1 dong trong tblSinhVien
                DataRow rsv = tblSinhVien.NewRow();
                // Gan gia tri cho cac cot cua dong moi tao ra
                // Cach 1:
                //rkh[0] = Mang_Thanh_Phan[0];
                //rkh[1] = Mang_Thanh_Phan[1];
                // Cach 2:
                for (int i = 0; i < Mang_Thanh_Phan.Length; i++)
                {
                    rsv[i] = Mang_Thanh_Phan[i];
                }


                // Them dong vua tao vao tblSinhVien
                tblSinhVien.Rows.Add(rsv);
            }

        }
            private void Nhap_Lieu_tblKhoa()
            {
                // Nhap lieu cho tblKhoa => Doc du lieu tu tap tin KHOA.txt
                string[] Mang_Khoa = File.ReadAllLines(@"..\..\..\data\KHOA.txt");
                foreach (string Chuoi_Khoa in Mang_Khoa)
                {
                    // Tach chuoi khoa thanh cac thanh phan tuong ung voi MaKH va TenKH
                    string[] Mang_Thanh_Phan = Chuoi_Khoa.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    // Tao 1 dong moi co cau truc giong cau truc cua 1 dong trong tblKhoa
                    DataRow rkh = tblKhoa.NewRow();
                    // Gan gia tri cho cac cot cua dong moi tao ra
                    rkh[0] = Mang_Thanh_Phan[0];
                    rkh[1] = Mang_Thanh_Phan[1];


                    // Them dong vua tao vao tblKhoa
                    tblKhoa.Rows.Add(rkh);

                }
            }

            private void Moc_Noi_Quan_He_Cac_Bang()
            {
                // Tao quan he giua tblkhoa va tblsinhvien
                ds.Relations.Add("FK_KH_SV", ds.Tables["KHOA"].Columns["MaKH"], ds.Tables["SINHVIEN"].Columns["MaKH"], true);

                // Tao quan he giua tblsinhvien va tnlketqua
                ds.Relations.Add("FK_SV_KQ", ds.Tables["SINHVIEN"].Columns["MaSV"], ds.Tables["KETQUA"].Columns["MaSV"], true);

                // Loai bo Cascade delete trong cac quan he
                ds.Relations["FK_KH_SV"].ChildKeyConstraint.DeleteRule = Rule.None;
                ds.Relations["FK_SV_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;
            }

            private void Tao_Cau_Truc_Cac_Bang()
            {
                // Tao cau truc cho DataTable tuong ung voi bang KHOA
                tblKhoa.Columns.Add("MaKH", typeof(string));
                tblKhoa.Columns.Add("TenKH", typeof(string));
                // Tao khoa chinh cho tblKhoa
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
                // Tao khoa chinh cho tblSinhVien
                tblSinhVien.PrimaryKey = new DataColumn[] { tblSinhVien.Columns["MaSV"] };

                // Tạo cấu trúc cho DataTable tương ứng với bảng KETQUA
                tblKetQua.Columns.Add("MaSV", typeof(string));
                tblKetQua.Columns.Add("MaMH", typeof(string));
                tblKetQua.Columns.Add("Diem", typeof(Single));
                // Tao Khoa chinh cho KETQUA
                tblKetQua.PrimaryKey = new DataColumn[] { tblKetQua.Columns["MaSV"], tblKetQua.Columns["MaMH"] };


                // Them cac DataTable cho DataSet
                //ds.Tables.Add(tblKhoa);
                //ds.Tables.Add(tblSinhVien);
                //ds.Tables.Add(tblKetQua);

                // Them dong thoi nhieu DataTable vao dataset
                ds.Tables.AddRange(new DataTable[] { tblKhoa, tblSinhVien, tblKetQua });

            }
        } 
}
// Thành phần DataTable
// 1. Dùng để lưu trữ dữ liệu của một Table trong bộ nhớ
// 2. Tạo một đối tượng DataTable: New DataTable ("<Tên DataTable>");
// 3. Tạo ra các cột (DataColumn): <Biến DataTable>.Column.add("<Tên Cột>", <Kểu dữ liệu>);
// 4. Tạo khóa chính cho DataTable => PrimaryKey => Là mảng các DataColumn
// 5. Thêm các DataTable và DataSet
// 6. Móc nối quan hệ giữa các DataTable