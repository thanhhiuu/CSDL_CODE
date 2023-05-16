using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Nguyen_Thanh_Hieu_0X
{
    public partial class Form1 : Form
    {
        // Khai báo các đối tượng using
        QLSinhVien ds = new QLSinhVien();
        QLSinhVienTableAdapters.KHOATableAdapter adpKhoa = new QLSinhVienTableAdapters.KHOATableAdapter();
        QLSinhVienTableAdapters.SINHVIENTableAdapter adpSinhVien = new QLSinhVienTableAdapters.SINHVIENTableAdapter();
        QLSinhVienTableAdapters.KETQUATableAdapter adpKetqua = new QLSinhVienTableAdapters.KETQUATableAdapter();
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            bs.CurrentChanged += Bs_CurrentChanged;
        }

        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            lblSTT.Text = bs.Position + 1 + " / " + bs.Count;
            txttongdiem.Text = TongDiem(txtmasv.Text).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo data
            Khoi_Tao_Du_Lieu();
            Khoi_tao_combobox();
            Lien_ket_dieu_khien();
            txttongdiem.Text = TongDiem(txtmasv.Text).ToString();
        }
        public double TongDiem(string smv)
        {
            double kq = 0;
            Object td = ds.KETQUA.Compute("sum(Diem)", "MaSV='" + smv + "'");
            if(td == DBNull.Value)
                kq = 0;                      
            else
                kq = Convert.ToDouble(td);
                return kq; 
        }
        private void Lien_ket_dieu_khien()
        {
            foreach (Control ctr in this.Controls)
            {
                if (ctr is TextBox && ctr.Name != "txttongdiem")
                    ctr.DataBindings.Add("text", bs, ctr.Name.Substring(3), true);
                else if (ctr is CheckBox)
                    ctr.DataBindings.Add("checked", bs, ctr.Name.Substring(3), true);
                else if (ctr is ComboBox)
                    ctr.DataBindings.Add("selectedvalue", bs, ctr.Name.Substring(3), true);
                else if (ctr is DateTimePicker)
                    ctr.DataBindings.Add("value", bs, ctr.Name.Substring(3), true);
            }
        }

        private void Khoi_tao_combobox()
        {
            cbomakh.DisplayMember = "TenKH";
            cbomakh.ValueMember = "MaKH";
            cbomakh.DataSource = ds.KHOA;
        }

        private void Khoi_Tao_Du_Lieu()
        {
            adpKhoa.Fill(ds.KHOA);
            adpSinhVien.Fill(ds.SINHVIEN);
            adpKetqua.Fill(ds.KETQUA);


            bs.DataSource = ds;
            bs.DataMember = ds.SINHVIEN.TableName;

        }

        private void btntruoc_Click(object sender, EventArgs e)
        {          
                if(bs.Position >= bs.Count - 1)
                {
                    MessageBox.Show("Khong thể tăng trước");
                }
                bs.MoveNext();
        }
         
        private void btnsau_Click(object sender, EventArgs e)
        {
            if (bs.Position <= 0)
            {
                MessageBox.Show("Khong thể lùi trước");
            }
            bs.MovePrevious();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmasv.ReadOnly = false;
            bs.AddNew();
            txtmasv.Focus();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa hay không ?", "Chú Ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == DialogResult.OK)
            {
                QLSinhVien.SINHVIENRow rsv = (bs.Current as DataRowView).Row as QLSinhVien.SINHVIENRow;
                if (rsv.GetKETQUARows().Length > 0)
                {
                    MessageBox.Show("Không thể xóa bỏ được because data đã tồn tại");
                    return;
                }
                bs.RemoveCurrent();

                // Update
                int n = adpSinhVien.Update(ds.SINHVIEN);
                if (n > 0)
                {
                    MessageBox.Show("Xóa thành công");
                }
            }
            else
            {
                bs.CancelEdit();        
            }
           
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if(!txtmasv.ReadOnly)
            {
                QLSinhVien.SINHVIENRow rsv = ds.SINHVIEN.FindByMaSV(txtmasv.Text);
                if(rsv !=null)
                {
                    MessageBox.Show("Trùng khoá chính");
                    txtmasv.Focus();
                    return;
                }
            }
            bs.EndEdit();
            int n = adpSinhVien.Update(ds.SINHVIEN);
            if (n > 0)
            {
                MessageBox.Show("Ghi thành công");
            }
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
        }
    }
}
