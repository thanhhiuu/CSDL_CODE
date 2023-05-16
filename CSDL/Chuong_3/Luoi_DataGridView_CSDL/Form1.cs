using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Luoi_DataGridView_CSDL
{
    public partial class Form1 : Form
    {
        // Ket noi CSDL
        string conn = @"server=HIUIT; database=QLSV_CSDL; integrated security = true";
        // Khoi tao dataset
        DataSet ds = new DataSet();
        // Adapter
        SqlDataAdapter adpMonhoc, adpKetqua;
        // CommandBuilder
        SqlCommandBuilder cmdMonHoc;
        // Khoi tao bindingSource
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Khoi_tao_du_lieu();
            Doc_du_lieu();
            Moc_noi_quan_he();
            
            // Khoi tao đối tượng BinDingScource 
            // Khoi tao đối tượng BinDingScource 
            bs.DataSource = ds;
            bs.DataMember = "MONHOC";
            
            // Gán nguồn cho lưới
            dgvMonHoc.DataSource = bs;
            dgvMonHoc.Columns["LoaiMH"].Visible = false;

            Lien_ket_dieu_khien();
        }

        private void Lien_ket_dieu_khien()
        {
            txtmamh.DataBindings.Add("text", bs, "MaMH", true);
            txttenmh.DataBindings.Add("text", bs, "TenMH", true);
            txtsotiet.DataBindings.Add("text", bs, "SoTiet", true);
        }

        private void Moc_noi_quan_he()
        {
            ds.Relations.Add("FK_MH_KQ", ds.Tables["MONHOC"].Columns["MaMH"], ds.Tables["KETQUA"].Columns["MaMH"]);
            ds.Relations["FK_MH_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;
        }

        private void Doc_du_lieu()
        {
            // Truy xuat vao ban de lay cac thong so cua ban MonHoc bang (FillSchema) và dùng Fill để đưa thông tin dữ liệu vào bảng 
            adpMonhoc.FillSchema(ds, SchemaType.Source, "MONHOC");
            adpMonhoc.Fill(ds, "MONHOC");

            // Truy xuat vao ban de lay cac thong so cua ban MonHoc bang (FillSchema) và dùng Fill để đưa thông tin dữ liệu vào bảng 

            adpKetqua.FillSchema(ds, SchemaType.Source, "KETQUA");
            adpKetqua.Fill(ds, "KETQUA");
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            int a = adpMonhoc.Update(ds, "MONHOC");
            if(a > 0) {
                MessageBox.Show("Cập nhật thành công");
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            // Lấy dong cần hủy ra và ktra xem dòng đó có tỏng BẢNG KETQUA khong
            DataRow rhuy = (bs.Current as DataRowView).Row;
            if(rhuy.GetChildRows("FK_MH_KQ").Length > 0)
            {
                MessageBox.Show("Dòng đã tồn tại ở bảng Ketqua Không thể xóa");
                return;
            }
            rhuy.Delete();
            // Cập nhật csdl
            int n = adpMonhoc.Update(ds, "MONHOC");
            if(n > 0)
            {
                MessageBox.Show("Hủy thành công");
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmamh.ReadOnly = false;
            bs.AddNew();
            txtmamh.Focus();
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            txtmamh.ReadOnly = true;
        }

        private void Khoi_tao_du_lieu()
        {
            // lay du lieu tu CSDL dua vao adapter
            adpMonhoc = new SqlDataAdapter("select * from monhoc", conn);
            adpKetqua = new SqlDataAdapter("select * from ketqua", conn);

            // Khoi tao cmd
            cmdMonHoc = new SqlCommandBuilder(adpMonhoc);

        }
    }
}
