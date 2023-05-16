using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report_02
{
    public partial class Form2 : Form
    {

        QLSinhVien ds = new QLSinhVien();
        QLSinhVienTableAdapters.KHOATableAdapter adpKhoa = new QLSinhVienTableAdapters.KHOATableAdapter();
        QLSinhVienTableAdapters.SINHVIENTableAdapter adpSinhvien = new QLSinhVienTableAdapters.SINHVIENTableAdapter();
        BindingSource bssv = new BindingSource();
        BindingSource bskh = new BindingSource();


        ReportDataSource rds = new ReportDataSource();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {


            // Nạp data
            adpKhoa.Fill(ds.KHOA);
            adpSinhvien.Fill(ds.SINHVIEN);
            bskh.DataSource = ds.KHOA;
            bssv.DataSource = ds.SINHVIEN;



            //lien ket controls
            txtmakh.DataBindings.Add("text", bskh, "MaKH", true);
            txttenkh.DataBindings.Add("text", bskh, "TenKH", true);
        }

        private void btninan_Click(object sender, EventArgs e)
        {
            rds.Name = "DS_SINHVIEN";
            rds.Value = bssv;
            // Ghi nhận vị trí trên report
            int vt = bssv.Position;
            //Lọc dữ liệu hiển thị trên Repot
            bssv.Filter = "MaKH='" + txtmakh.Text + "'";
            if(bssv.Count == 0)
            {
                MessageBox.Show("Khoong co sinh vien");
                return;
            }

            // Khai báo control report view
            ReportViewer rv = new ReportViewer();

            rv.LocalReport.DataSources.Add(rds);
            //rv.LocalReport.ReportEmbeddedResource = "Report_02.RSinhVien.rdlc";
            //rv.LocalReport.ReportEmbeddedResource = "Report_02.RSV2.rdlc";
            rv.LocalReport.ReportEmbeddedResource = "Report_02.RSV3.rdlc";



            rv.SetDisplayMode(DisplayMode.PrintLayout);
            rv.Dock = DockStyle.Fill;


            Form f = new Form();
            f.WindowState = FormWindowState.Maximized;
            f.Controls.Add(rv);
            f.ShowDialog();



            // lam moi report
            rv.RefreshReport();



            // Hủy lọc
            bssv.Filter = "";
            bssv.Position = vt;
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            bskh.MovePrevious();
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            bskh.MoveNext();
        }
    }
}
