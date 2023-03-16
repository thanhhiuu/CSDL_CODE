using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luoi_DataGirdView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //Thêm dữ liệu
            Them_dong();
            // Chọn 1 dòng trong lưới
            DataGridViewRow r = dgvMonHoc.Rows[0];
            r.Selected = true;
            // Gán dữ liệu lên constrol trên form
            Gan_Du_Lieu(r);
        }

        private void Them_dong()
        {
            dgvMonHoc.Rows.Add("01", "Toán Đại Cương", 45);
            dgvMonHoc.Rows.Add("02", "Hóa Học Siêu Cấp", 80);
            dgvMonHoc.Rows.Add("03", "Vật Lý Tesla", 100);
            dgvMonHoc.Rows.Add("04", "Anh Văn", 90);
        }
        public void Gan_Du_Lieu(DataGridViewRow r)
        {
            txtmamh.Text = r.Cells["colMaMH"].Value.ToString();
            txttenmh.Text = r.Cells["colTenMH"].Value.ToString();
            txtsotiet.Text = r.Cells["colSoTiet"].Value.ToString();
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xảy ra khi có một dòng nào đó trên dgvMonHoc được click
            // // Để lấy thông tin của dòng chứa dữ liệu ô được click => r.RowIndex
            DataGridViewRow r = dgvMonHoc.Rows[e.RowIndex];
            Gan_Du_Lieu(r);
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
                // Huy row
                dgvMonHoc.Rows.Remove(rhuy);
                if (dgvMonHoc.Rows.Count > 0)
                {
                    dgvMonHoc.Rows[0].Selected = true;
                    Gan_Du_Lieu(dgvMonHoc.Rows[0]);
                }
            }
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if(txtmamh.ReadOnly == true) // Ghi sua
            {
                // Lấy thong tin của dòng cần sửa => Dòng dang được chọn
                DataGridViewRow rsua = dgvMonHoc.Rows[0];
                // Su thong tin cua dong theo thong tin cua cac control
                rsua.Cells[1].Value = txttenmh.Text;
                rsua.Cells[2].Value = txtsotiet.Text;
            }
            else // Ghi sau khi them moi
            {
                dgvMonHoc.Rows.Add(txtmamh.Text, txttenmh.Text, txtsotiet.Text);
                txtmamh.ReadOnly = true;
                dgvMonHoc.Rows[dgvMonHoc.Rows.Count - 1].Selected = true;
                // Cách 2:

                //int stt = dgvMonHoc.Rows.Add(txtmamh.Text, txttenmh.Text, txtsotiet.Text);
                //txtmamh.ReadOnly = true;
                //dgvMonHoc.Rows[stt].Selected = true;
            }
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            Gan_Du_Lieu(dgvMonHoc.SelectedRows[0]);
            txtmamh.ReadOnly = true;
        }
    }
}
