using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luoi_DataGitdView_03
{
    public partial class Form1 : Form
    {
        QLSinhVien ds = new QLSinhVien();
        QLSinhVienTableAdapters.MONHOCTableAdapter adpMonhoc = new QLSinhVienTableAdapters.MONHOCTableAdapter();
        QLSinhVienTableAdapters.KETQUATableAdapter adpKetqua = new QLSinhVienTableAdapters.KETQUATableAdapter();
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Doc_du_lieu();
            dgvMonHoc.DataSource = ds.MONHOC;

        }

        private void Doc_du_lieu()
        {
            adpMonhoc.Fill(ds.MONHOC);
            adpKetqua.Fill(ds.KETQUA);
        }

        private void dgvMonHoc_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Ever này xảy ra khi data check tính hợp lệ
            // Thuộc tính IsnewRow => True: Dòng hiện hành là dòng mới và chưa có data
            // Thuộc tính Isnew Của đối tượng DataRowView tương ứng với dòng hiện hành (CurrentRow) => true
            // => Dòng mới có data
            // thuộc tính IsCurrentrowDirty có giá trị là true => Dòng bị chỉnh sửa (Có thể là dòng mới đã có chỉnh sửa)

            if (dgvMonHoc.CurrentRow.IsNewRow == true) return;
            if(dgvMonHoc.IsCurrentRowDirty == true)
            {
                if((dgvMonHoc.CurrentRow.DataBoundItem as DataRowView).IsNew == true)
                {
                    // Check primary key cos trung hay khoong
                    if (ds.MONHOC.FindByMaMH(dgvMonHoc.CurrentRow.Cells["MaMH"].Value.ToString()) != null)
                    {
                        MessageBox.Show("Trung khoa chinh");
                        e.Cancel = true;
                        dgvMonHoc.CurrentCell = dgvMonHoc.CurrentRow.Cells["MaMH"]; // Cho oo mã môn học là hiện hành
                        return;
                    }
                }
                // Kết thúc quá trình chỉnh sửa
                (dgvMonHoc.CurrentRow.DataBoundItem as DataRowView).EndEdit();
                // Update CSDL
                int n = adpMonhoc.Update(ds.MONHOC);
                if (n > 0)
                    MessageBox.Show("Cập nhật thành công");
            }
                
        }

        private void dgvMonHoc_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // Check tính hợp lệ của data khi xóa => Nếu muốn hủy bỏ event: e.Cancel = true;
            // 1. Lấy dòng cần xóa
            QLSinhVien.MONHOCRow r = (dgvMonHoc.CurrentRow.DataBoundItem as DataRowView).Row as QLSinhVien.MONHOCRow;
            if(r.GetKETQUARows().Length > 0)
            {
                MessageBox.Show("Data Da ton tai");
                e.Cancel = true;
                return;
            }

        }

        private void dgvMonHoc_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            // Update CSDL
            int n = adpMonhoc.Update(ds.MONHOC);
            if (n > 0)
                MessageBox.Show("Xoa thành công");
        }

        private void dgvMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
