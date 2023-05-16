using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Man_Hinh_Main_Sub
{
    public partial class Form1 : Form
    {
        QL_SVCSDL ds = new QL_SVCSDL();
        QL_SVCSDLTableAdapters.KHOATableAdapter adpKhoa = new QL_SVCSDLTableAdapters.KHOATableAdapter();
        QL_SVCSDLTableAdapters.SINHVIENTableAdapter adpSinhvien = new QL_SVCSDLTableAdapters.SINHVIENTableAdapter();
        QL_SVCSDLTableAdapters.KETQUATableAdapter adpKetqua = new QL_SVCSDLTableAdapters.KETQUATableAdapter();
        QL_SVCSDLTableAdapters.MONHOCTableAdapter adpMonhoc = new QL_SVCSDLTableAdapters.MONHOCTableAdapter();
        BindingSource bs = new BindingSource();
        BindingSource bskq = new BindingSource(); // Nguon du lieu cho luoi dgvmonhoc

        public Form1()
        {
            InitializeComponent();
            bs.CurrentChanged += Bs_CurrentChanged;
        }

        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            // Methods nay duoc tu dong thi hanh khi co Event di chuyen mau tin
            lblSTT.Text = bs.Position + 1 + " / " + bs.Count;
            // Tính tổng điểm
            txttongdiem.Text = Tong_diem(txtmasv.Text).ToString();
        }
        private double Tong_diem(string msv)
        {
            double kq = 0;
            Object td = ds.Tables["KETQUA"].Compute("sum(Diem)", "MaSV='" + msv + "'");
            // Lưu ý: trường hợp sinh viên không có điểm thì phương thức Compute trả về giá trị DBNull
            if (td == DBNull.Value)
                kq = 0;
            else
                kq = Convert.ToDouble(td); 
            return kq;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Doc_Du_Lieu();
            Lien_ket_dieu_khien();
            txttongdiem.Text = Tong_diem(txtmasv.Text).ToString();
            //adpKetqua.Fill(ds.KETQUA);
            //adpMonhoc.Fill(ds.MONHOC);
            //bs.DataSource = ds.KETQUA;
            //dgvmonhoc.DataSource = bs;
            //dgvmonhoc.Columns["MaSV"].Visible = false;
            // Không phát sinh cột khi gán nguồn
            dgvktra.AutoGenerateColumns = false;
            dgvktra.DataSource = ds.MONHOC;
        }
        private void Lien_ket_dieu_khien()
        {
            // Dung vòng lặp để liên kết dự liệu của BinDingSoucre với các điều khiển
            foreach (Control ctr in this.Controls)
                if (ctr is TextBox && ctr.Name != "txttongdiem" )
                    ctr.DataBindings.Add("text", bs, ctr.Name.Substring(3), true);
                else if (ctr is CheckBox)
                    ctr.DataBindings.Add("checked", bs, ctr.Name.Substring(3), true);
                else if (ctr is ComboBox)
                    ctr.DataBindings.Add("selectedvalue", bs, ctr.Name.Substring(3), true);
                else if (ctr is DateTimePicker)
                    ctr.DataBindings.Add("value", bs, ctr.Name.Substring(3), true);


            // Dinh dang lai txthocbong hien thi
            txthocbong.DataBindings[0].FormatString = "#,##0 đ";
        }
        public void Doc_Du_Lieu()
        {
            // Nạp dữ liệu cho các DataTable
            adpKhoa.Fill(ds.KHOA);
            adpSinhvien.Fill(ds.SINHVIEN);
            adpKetqua.Fill(ds.KETQUA);
            adpMonhoc.Fill(ds.MONHOC);

            // Nap nguon cho Combobox Khoa
            cbomakh.DataSource = ds.KHOA;
            cbomakh.DisplayMember = "TenKH";
            cbomakh.ValueMember = "MaKH";

            // Nap nguon cho bindingscource bs
            bs.DataSource = ds.SINHVIEN;

            // Nguon du lieu binDingSource bskq
            bskq.DataSource = bs;
            bskq.DataMember = "FK_KETQUA_SINHVIEN";

            // Gan nguon cho luoi dgvmohoc
            dgvmonhoc.DataSource = bskq;

            // Gan nguon cho kq


            // Ngat hien thi MaSV trong luoi
            dgvmonhoc.Columns["MaSV"].Visible = false;
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
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
            DataRow rhuy = (bs.Current as DataRowView).Row;
            if(rhuy.GetChildRows("FK_MONHOC_KETQUA").Length > 0)
            {
                MessageBox.Show("Data already exists in table KETQUA");
            }
            rhuy.Delete();
            // Cập nhật CSDL
            int n = adpSinhvien.Update(ds.SINHVIEN);
            if(n > 0)
            {
                MessageBox.Show("Hủy thành công");
            }
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if(!txtmasv.ReadOnly) /// Ghi sau khi sửa
            {
                QL_SVCSDL.SINHVIENRow rmh = ds.SINHVIEN.FindByMaSV(txtmasv.Text);
                if(rmh != null)
                {
                    MessageBox.Show("Bị trùng khóa chính");
                    txtmasv.Focus();
                    btnkhong.PerformClick();
                    return;
                }
                else
                {
                    bs.EndEdit();
                    int n = adpSinhvien.Update(ds.SINHVIEN);
                    if (n > 0)
                    {
                        MessageBox.Show("Ghi thành công");
                    }
                }
            }
            txtmasv.ReadOnly = true;

        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            txtmasv.ReadOnly = true;
            dgvmonhoc.Rows[0].Selected = true;
        }

        private void dgvktra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xác định dòng vừa click vô là dòng gì
            // Lấy ra dòng hiện hành 
            DataGridViewRow r = dgvktra.CurrentRow;
            if(r.IsNewRow == true)
            {
                MessageBox.Show("Dòng mới");
            }
            else if((r.DataBoundItem as DataRowView).IsNew == true)
            {
                MessageBox.Show("Dòng mới có dữ liệu");
            }
            else
            {
                MessageBox.Show("Dòng cũ");
            }
        }

     
    }
    
}
