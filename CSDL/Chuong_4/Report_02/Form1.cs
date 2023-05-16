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
    public partial class Form1 : Form
    {
        QLSinhVien ds = new QLSinhVien();
        QLSinhVienTableAdapters.KHOATableAdapter adpKhoa = new QLSinhVienTableAdapters.KHOATableAdapter();
        QLSinhVienTableAdapters.SINHVIENTableAdapter adpSinhvien = new QLSinhVienTableAdapters.SINHVIENTableAdapter();
        BindingSource bs = new BindingSource();

        ReportDataSource rds = new ReportDataSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rds.Name = "DS_SINHVIEN";
            rds.Value = bs;
            rv.LocalReport.DataSources.Add(rds);
            //rv.LocalReport.ReportEmbeddedResource = "Report_02.RSinhVien.rdlc";
            //rv.LocalReport.ReportEmbeddedResource = "Report_02.RSV2.rdlc";
            rv.LocalReport.ReportEmbeddedResource = "Report_02.RSV3.rdlc";

            rv.SetDisplayMode(DisplayMode.PrintLayout);

            adpKhoa.Fill(ds.KHOA);
            adpSinhvien.Fill(ds.SINHVIEN);
            bs.DataSource = ds.SINHVIEN;
            this.WindowState = FormWindowState.Maximized; 
            this.rv.RefreshReport();
        }

        private void rv_Load(object sender, EventArgs e)
        {

        }
    }
}
