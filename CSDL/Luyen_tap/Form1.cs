using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Luyen_tap
{
    public partial class Form1 : Form
    {
        // Khai bao Dataset co sinh kieu ds
        QLSinhVien ds = new QLSinhVien();
        // Khai bao cac doi tuong dataDapter
        QLSinhVienTableAdapters.KHOATableAdapter adpKhoa = new QLSinhVienTableAdapters.KHOATableAdapter();
        QLSinhVienTableAdapters.KETQUATableAdapter adpKetQua = new QLSinhVienTableAdapters.KETQUATableAdapter();
        QLSinhVienTableAdapters.SINHVIENTableAdapter adpSinhVien = new QLSinhVienTableAdapters.SINHVIENTableAdapter();
        // Khoi tao BindingSoucre
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            bs.CurrentChanged += Bs_CurrentChanged;
        }

        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            // Gan gia tri dong cho lblSTT
            lblSTT.Text = bs.Position + 1 + " /" + bs.Count;
            // Tinh tong diem
            txttongdiem.Text = Tong_Diem(txtmasv.Text).ToString();
        }
        private double Tong_Diem(string mss)
        {
            double kq = 0;
            Object td = ds.Tables["KETQUA"].Compute("sum(Diem)", "MaSV='" + mss + "'");
            if (td == DBNull.Value) 
                kq = 0;       
            else           
                kq = Convert.ToDouble(td);
                return kq;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Doc_du_lieu();
            Khoi_tao_BinDing();
            Khoi_tao_Combobox();
            Lien_ket_dieu_khien();
            // Tinh tong diem
            txttongdiem.Text = Tong_Diem(txtmasv.Text).ToString();
        }

        private void Lien_ket_dieu_khien()
        {
            foreach (Control ctr in this.Controls)
                if (ctr is TextBox && ctr.Name != "txttongdiem" && ctr.Name != "txtphai")
                    ctr.DataBindings.Add("text", bs, ctr.Name.Substring(3), true);
                else if (ctr is CheckBox)
                    ctr.DataBindings.Add("selectedvalue", bs, ctr.Name.Substring(3), true);
                else if (ctr is DateTimePicker)
                    ctr.DataBindings.Add("value", bs, ctr.Name.Substring(3), true);
            // Dinh dang kieu hien thi cua txthocbong
            txthocbong.DataBindings[0].FormatString = "#,##0 vnd";

            // Truong hop txtphai la textbox
            Binding bdphai = new Binding("text",bs, "Phai", true);
            bdphai.Format += Bdphai_Format;
            bdphai.Parse += Bdphai_Parse;


            txtphai.DataBindings.Add(bdphai);
        }

        private void Bdphai_Parse(object sender, ConvertEventArgs e)
        {
            if (e.Value == null) return;
            e.Value = e.Value.ToString().ToUpper() == "Men" ? true : false ;
        }

        private void Bdphai_Format(object sender, ConvertEventArgs e)
        {
            if(e.Value == DBNull.Value || e.Value == null) return;
            e.Value = (Boolean)e.Value ? "Men" : "Women";
        }

        private void Khoi_tao_Combobox()
        {
            cbokhoa.DataSource = ds.KHOA;
            cbokhoa.ValueMember = "MaKH";
            cbokhoa.DisplayMember = "TenKH";
        }

        private void Khoi_tao_BinDing()
        {
            bs.DataSource = ds;
            bs.DataMember = ds.SINHVIEN.TableName;
        }

        private void Doc_du_lieu()
        {
            adpKhoa.Fill(ds.KHOA);
            adpKetQua.Fill(ds.KETQUA);
            adpSinhVien.Fill(ds.SINHVIEN);
        }
    }
}
