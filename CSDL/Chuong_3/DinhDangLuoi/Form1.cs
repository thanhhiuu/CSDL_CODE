using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DinhDangLuoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Them_cot_vao_luoi();
            Them_hang_vao_luoi();
            Dinh_Dang_Luoi();
        }

        private void Dinh_Dang_Luoi()
        {
            // Chọn cả dòng
            dgvluoi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Không chọn nhiều dòng
            dgvluoi.MultiSelect = false;
            // Thiết lập không cho thêm mới
            dgvluoi.AllowUserToAddRows = false;
        }

        private void Them_hang_vao_luoi()
        {
            dgvluoi.Rows.Add("01", "Toán Đại Cương", 45);
            dgvluoi.Rows.Add("02", "Hóa Học Siêu Cấp", 80);
            dgvluoi.Rows.Add("03", "Vật Lý Tesla", 100);
            dgvluoi.Rows.Add("04", "Anh Văn", 90);
        }

        private void Them_cot_vao_luoi()
        {
            dgvluoi.Columns.Add("colMaMH", "Mã Môn Học");
            dgvluoi.Columns.Add("colTenMH", "Tên Môn Học");
            dgvluoi.Columns.Add("colSoTiet", "Số Tiết");
        }

        private void dgvluoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
