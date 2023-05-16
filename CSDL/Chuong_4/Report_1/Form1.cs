using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Report_1
{
    public partial class Form1 : Form
    {
        QLSinhVien ds = new QLSinhVien();
        QLSinhVienTableAdapters.KHOATableAdapter adpKhoa = new QLSinhVienTableAdapters.KHOATableAdapter();
        BindingSource bskh = new BindingSource();
        // Khai bao đối tượng liên quan đến report
        ReportDataSource rvs = new ReportDataSource();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rvs.Name = "DS_Khoa";
            rvs.Value = bskh;
            rv.LocalReport.DataSources.Add(rvs);
            rv.LocalReport.ReportEmbeddedResource = "Report_1.RKhoa.rdlc";


            adpKhoa.Fill(ds.KHOA);
            bskh.DataSource = ds.KHOA;
            this.rv.RefreshReport();
        }

        private void rv_Load(object sender, EventArgs e)
        {

        }
    }
}
