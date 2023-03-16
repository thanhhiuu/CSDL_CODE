using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridView_02
{
    public partial class Form1 : Form
    {
        // Kết nối CSDL bằng sql 
        string strcon = @"server=HIUIT; database=QL_SVCSDL; integrated security = true";

        // Khoi tao dataset
        DataSet ds = new DataSet();
        // SqlAdapter 
        SqlDataAdapter adpMonHoc, adpKetQua;
        // SqlCommadBuider
        SqlCommandBuilder cmdMonHoc;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Khoi_tao_du_lieu();
            Doc_du_lieu();
            Moc_noi_qua_he();
            // Gán nguoòn dữ liệu cho lưới
            dgvMonHoc.DataSource = ds.Tables["MONHOC"];
            dgvMonHoc.Columns["LoaiMH"].Visible = false;
            DataGridViewRow r = dgvMonHoc.Rows[0];
            r.Selected = true;
            // Gán dữ liệu lên constrol trên form
            Gan_Du_Lieu(r);
        }
        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xảy ra khi có một dòng nào đó trên dgvMonHoc được click
            // // Để lấy thông tin của dòng chứa dữ liệu ô được click => r.RowIndex
            DataGridViewRow r = dgvMonHoc.Rows[e.RowIndex];
            Gan_Du_Lieu(r);
        }
        public void Gan_Du_Lieu(DataGridViewRow r)
        {
            txtmamh.Text = r.Cells["colMaMH"].Value.ToString();
            txttenmh.Text = r.Cells["colTenMH"].Value.ToString();
            txtsotiet.Text = r.Cells["colSoTiet"].Value.ToString();
        }
        private void Moc_noi_qua_he()
        {

            ds.Relations.Add("FK_MH_KQ", ds.Tables["MONHOC"].Columns["MaMH"], ds.Tables["KETQUA"].Columns["MaMH"]);
            ds.Relations["FK_MH_KQ"].ChildKeyConstraint.DeleteRule = Rule.None;

        }
        private void Doc_du_lieu()
        {

            // 1. Sao chep cau truc va du lieu cua DataTable
            adpMonHoc.FillSchema(ds, SchemaType.Source, "MONHOC");
            adpMonHoc.Fill(ds, "MONHOC");

            adpKetQua.FillSchema(ds, SchemaType.Source, "KETQUA");
            adpKetQua.Fill(ds, "KETQUA");
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmamh.ReadOnly = false;
            foreach (Control ctr in this.Controls)
            {
                if (ctr is TextBox)
                    (ctr as TextBox).Clear();
                txtmamh.Focus();
            }
           
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {

            if (dgvMonHoc.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa");
            }
            else
            {
                // Lay dong can huy lay tu dong thu 0 cua tap hop cac dong duoc chon
                DataGridViewRow rhuy = dgvMonHoc.SelectedRows[0];
                // Chuyển đổi dòng rhuy sang dataRow
                DataRow r = (rhuy.DataBoundItem as DataRowView).Row;

              

                // Ktra xem có tồn tại những dòng có liên quan đến dòng trong KETQUA
                if(r.GetChildRows("FK_MH_KQ").Length > 0)
                {
                    MessageBox.Show("Khoong Xoa duoc do co nhung dong lien quan trong ket qua");
                    return;
                }

                // Xóa dòng r
                r.Delete();
                // Xóa trong CSDL
                 int n = adpMonHoc.Update(ds, "MONHOC");
                if (n > 0)
                    MessageBox.Show("Xóa Thành Công");
                Gan_Du_Lieu(dgvMonHoc.Rows[0]);
            }
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (!txtmamh.ReadOnly) // Ghi sau khi sua
            {
                //dgvMonHoc.Rows.Add(txtmamh.TextLength, txttenmh.Text, txtsotiet.Text);
                
                DataRow rmoi = ds.Tables["MONHOC"].NewRow();
                rmoi[0] = txtmamh.Text;
                rmoi[1] = txttenmh.Text;
                rmoi[2] = txtsotiet.Text;

                ds.Tables["MONHOC"].Rows.Add(rmoi);

                int n = adpMonHoc.Update(ds, "MONHOC");
                if (n > 0)
                    MessageBox.Show("Ghi Thành Công");
                txtmamh.ReadOnly = true;
                dgvMonHoc.Rows[ds.Tables["MONHOC"].Rows.Count - 1].Selected = true;
            }
            else // Ghi sau khi them moi
            {
                // Lấy thong tin của dòng cần sửa => Dòng dang được chọn
                DataGridViewRow rsua = dgvMonHoc.SelectedRows[0];
                // Chuyển đổi dòng rhuy sang dataRow
                DataRow r = (rsua.DataBoundItem as DataRowView).Row;
                // Su thong tin cua dong theo thong tin cua cac control
                r[1] = txttenmh.Text;
                r[2] = txtsotiet.Text;

                int n = adpMonHoc.Update(ds, "MONHOC");
                if (n > 0)
                    MessageBox.Show("Thêm Thành Công");
            }
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            Gan_Du_Lieu(dgvMonHoc.SelectedRows[0]);
            txtmamh.ReadOnly = true;
        }

        private void Khoi_tao_du_lieu()
        {
            // 1. Khởi tạo dữ liệu cho DataAdapter
            adpMonHoc = new SqlDataAdapter("select * from monhoc", strcon);
            adpKetQua = new SqlDataAdapter("select * from ketqua", strcon);

            // 2. Khởi tạo CommandBuilder
            cmdMonHoc = new SqlCommandBuilder(adpMonHoc);
        }

    }
}
