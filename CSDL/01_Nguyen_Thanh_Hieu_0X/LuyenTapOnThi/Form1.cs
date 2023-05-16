using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuyenTapOnThi
{
    public partial class Form1 : Form
    {
        QLSV ds = new QLSV();
        QLSVTableAdapters.KHOATableAdapter adpKhoa = new QLSVTableAdapters.KHOATableAdapter();
        QLSVTableAdapters.SINHVIENTableAdapter adpSinhVien = new QLSVTableAdapters.SINHVIENTableAdapter();
        QLSVTableAdapters.KETQUATableAdapter adpKetqua = new QLSVTableAdapters.KETQUATableAdapter();
        QLSVTableAdapters.MONHOCTableAdapter adpMonHoc = new QLSVTableAdapters.MONHOCTableAdapter();
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
            Khoi_tao_du_lieu();
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
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox && ctrl.Name != "txttongdiem")
                    ctrl.DataBindings.Add("text", bs, ctrl.Name.Substring(3), true);
                else if (ctrl is CheckBox)
                    ctrl.DataBindings.Add("checked", bs, ctrl.Name.Substring(3), true);
                else if (ctrl is ComboBox)
                    ctrl.DataBindings.Add("selectedvalue", bs, ctrl.Name.Substring(3), true);
                else if (ctrl is DateTimePicker)
                    ctrl.DataBindings.Add("value", bs, ctrl.Name.Substring(3), true);

            // Định dạng lại bảng điểmm
            txthocbong.DataBindings[0].FormatString = "#,##0 vnđ";
        }

        private void Khoi_tao_combobox()
        {
            cbomakh.DataSource = ds.KHOA;
            cbomakh.DisplayMember = "TenKH";
            cbomakh.ValueMember = "MaKH";
        }

        private void Khoi_tao_du_lieu()
        {
            adpKhoa.Fill(ds.KHOA);
            adpSinhVien.Fill(ds.SINHVIEN);
            adpKetqua.Fill(ds.KETQUA);
            adpMonHoc.Fill(ds.MONHOC);

            bs.DataSource = ds;
            bs.DataMember = ds.SINHVIEN.TableName;
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            if(bs.Position == bs.Count - 1)
            {
                MessageBox.Show("Không di chuyển lên được nữa !");
            }
            bs.MoveNext();
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            if(bs.Position == 0)
            {
                MessageBox.Show("Không lùi được nữa !");
            }
            bs.MovePrevious();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmasv.ReadOnly = false;
            bs.AddNew();
            cbomakh.SelectedIndex = 0;
            txtmasv.Focus();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không !", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                QLSV.SINHVIENRow rsv = (bs.Current as DataRowView).Row as QLSV.SINHVIENRow;
                if(rsv.GetKETQUARows().Length > 0)
                {
                    MessageBox.Show("Không xóa được do đã tồn tại ở bản KETQUA !");
                    return;
                }
                bs.RemoveCurrent();
                // Update
                int n = adpSinhVien.Update(ds.SINHVIEN);
                if(n > 0)
                {
                    MessageBox.Show("Xóa thành công");
                }
            }
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if(!txtmasv.ReadOnly)
            {
                QLSV.SINHVIENRow rvmoi = ds.SINHVIEN.FindByMaSV(txtmasv.Text);
                    if (rvmoi != null)
                    {
                        MessageBox.Show("Đã trùng khóa chính !");
                        txtmasv.Focus();
                        return;
                    }
                    else if (txtmasv.TextLength > 3 || txtmasv.Text == "")
                    {
                        MessageBox.Show("Mã sinh viên chỉ tối đa 3 chữ số! không được bỏ trống");
                        txtmasv.Focus();
                        return;
                    }
                    else if (txthosv.Text == "" || txttensv.Text == "" )
                    {
                        MessageBox.Show("Họ và tên sinh viên không được bỏ trống và phải là kiểu chữ");
                        txtmasv.Focus();
                        return;
                    }
                    else if (txtnoisinh.Text == "")
                    {
                        MessageBox.Show("Nơi sinh sinh viên không được bỏ trống và phải là kiểu chữ");
                        txtmasv.Focus();
                        return;
                    }
                        bs.EndEdit();
                        // Update
                        int n = adpSinhVien.Update(ds.SINHVIEN);
                        if (n > 0)
                        {
                            MessageBox.Show("Cập nhật thành công");
                        }                                      
            }
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            txtmasv.ReadOnly = true;
            bs.CancelEdit();
        }
    }
}
