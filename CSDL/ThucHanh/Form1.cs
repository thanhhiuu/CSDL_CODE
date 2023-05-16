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

namespace ThucHanh
{
    public partial class Form1 : Form
    {
        QLMonHoc ds = new QLMonHoc();
        QLMonHocTableAdapters.KHOATableAdapter adpKhoa = new QLMonHocTableAdapters.KHOATableAdapter();
        QLMonHocTableAdapters.SINHVIENTableAdapter adpSinhvien = new QLMonHocTableAdapters.SINHVIENTableAdapter();
        QLMonHocTableAdapters.KETQUATableAdapter adpKetqua = new QLMonHocTableAdapters.KETQUATableAdapter();
        QLMonHocTableAdapters.MONHOCTableAdapter adpMonhoc = new QLMonHocTableAdapters.MONHOCTableAdapter();
        BindingSource bdsv = new BindingSource();
        BindingSource bdkq = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            bdsv.CurrentChanged += Bdsv_CurrentChanged;
        }

        private void Bdsv_CurrentChanged(object sender, EventArgs e)
        {
            lblSTT.Text = bdsv.Position + 1 + " / " + bdsv.Count;

            // Tính tổng điểm
            txttongdiem.Text = Tong_Diem(txtmasv.Text).ToString();
        }
        private  double Tong_Diem(string sum)
        {
            double n = 0;
            Object td = ds.Tables["KETQUA"].Compute("sum(Diem)", "MaSV='" + sum + "'");
            if(td == DBNull.Value) 
                n = 0;
            
            else 
                n = Convert.ToDouble(td);
                return n;
            

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Doc_du_lieu();
            txttongdiem.Text = Tong_Diem(txtmasv.Text).ToString();
            Lien_ket_dieu_khien();
            dgvmonhoc.AutoGenerateColumns = false;
            dgvktra.DataSource = ds.MONHOC;

        }

        private void Lien_ket_dieu_khien()
        {
            foreach (Control ctr in this.Controls)
                if (ctr is TextBox && ctr.Name != "txttongdiem")
                    ctr.DataBindings.Add("text", bdsv, ctr.Name.Substring(3), true);
                else if (ctr is ComboBox)
                    ctr.DataBindings.Add("selectedvalue", bdsv, ctr.Name.Substring(3), true);
                else if (ctr is CheckBox)
                    ctr.DataBindings.Add("checked", bdsv, ctr.Name.Substring(3), true);
                else if (ctr is DateTimePicker)
                    ctr.DataBindings.Add("value", bdsv, ctr.Name.Substring(3), true);


            // Dinh dang Hien thi gia tri Hoc bong
            txthocbong.DataBindings[0].FormatString = "#,##0 vnđ";
            
        }

        private void Doc_du_lieu()
        {
            // Nap du lieu DataAdapter
            adpKhoa.Fill(ds.KHOA);
            adpSinhvien.Fill(ds.SINHVIEN);
            adpKetqua.Fill(ds.KETQUA);
            adpMonhoc.Fill(ds.MONHOC);

            // Khoi tao combobox
            cbomakh.DataSource = ds.KHOA;
            cbomakh.ValueMember = "MaKH";
            cbomakh.DisplayMember = "Name";


            // Khoi tao BinDing dbsv
            bdsv.DataSource = ds.SINHVIEN;


            bdkq.DataSource = bdsv;
            bdkq.DataMember = "FK_KETQUA_SINHVIEN";

            // Khoi tao du lieu cho dgvMonhoc
            dgvmonhoc.DataSource = bdkq;
            // Loai bo cac ban khoong can thiet
            dgvmonhoc.Columns["MaSV"].Visible = false;

        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            txtmasv.ReadOnly = true;
            bdsv.CancelEdit();
            txtmasv.Focus();
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            bdsv.MovePrevious();
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            bdsv.MoveNext();
                
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            DataRow rhuy = (bdsv.Current as DataRowView).Row;
            if (rhuy.GetChildRows("FK_MONHOC_KETQUA").Length > 0)
            {
                MessageBox.Show("Da ton tại ở bảng KETQUA");
                txtmasv.Focus();
            }
            rhuy.Delete();
            // Cap nhat csdl
            int n = adpSinhvien.Update(ds.SINHVIEN);
            if(n > 0)
            {
                MessageBox.Show("Huy thanh cong");
            }
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (!txtmasv.ReadOnly)
            {
                QLMonHoc.SINHVIENRow rmt = ds.SINHVIEN.FindByMaSV(txtmasv.Text);
                if(rmt != null)
                {
                    MessageBox.Show("Bij trung khoa chinh ");
                    txtmasv.Focus();
                    btnkhong.PerformClick();
                    return;
                }
                else
                {
                    bdsv.EndEdit();
                    // Cap nhat csdl
                    int n = adpSinhvien.Update(ds.SINHVIEN);
                    if (n > 0)
                    {
                        MessageBox.Show("Ghi thanh cong");
                    }
                }
                txtmasv.ReadOnly = true;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmasv.ReadOnly = false;
            bdsv.AddNew();
            txtmasv.Focus();
        }
    }
}
