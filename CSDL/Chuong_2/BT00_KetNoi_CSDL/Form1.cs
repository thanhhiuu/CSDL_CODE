using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; // Sử dụng khi kết nối và làm việc với ACCESS
using System.Data.SqlClient; // Sử dụng khi kết nối và làm việc với SQL Server

namespace BT00_KetNoi_CSDL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnacc2003_Click(object sender, EventArgs e)
        {
            // Khai báo các đối tượng cần sử dụng để tạo kết nối
            //1. Chuỗi kết nối đến CSDL Access 2003
            string strcon = @"provider=microsoft.jet.oledb.4.0; data source=..\..\..\Data\QLSINHVIEN.mdb";
            //2. Khai báo đối tượng kết nối
            OleDbConnection cnn = new OleDbConnection(strcon);
            //3. Mở kết nối
            cnn.Open();
            //4. Kiểm tra xem kết nối có mở được hay không
            if (cnn.State == ConnectionState.Open)
                MessageBox.Show("kết nối đã mở");
            //5. Sau khi sử dụng xong thì đóng kết nối lại
            cnn.Close();
        }

        private void btnacc2019_Click(object sender, EventArgs e)
        {
            // Khai báo các đối tượng cần sử dụng để tạo kết nối
            //1. Chuỗi kết nối đến CSDL Access 2007 trở về sau
            string strcon = @"provider=microsoft.ACE.oledb.12.0; data source=..\..\..\Data\QLSINHVIEN.accdb";
            //2. Khai báo đối tượng kết nối
            OleDbConnection cnn = new OleDbConnection(strcon);
            //3. Mở kết nối
            cnn.Open();
            //4. Kiểm tra xem kết nối có mở được hay không
            if (cnn.State == ConnectionState.Open)
                MessageBox.Show("kết nối đã mở");
            //5. Sau khi sử dụng xong thì đóng kết nối lại
            cnn.Close();
        }

        private void btnSQLWin_Click(object sender, EventArgs e)
        {
            // Khai báo các đối tượng cần sử dụng để tạo kết nối
            //1. Chuỗi kết nối đến SQL Server bằng user của Windows
            string strcon = @"server=.; database=C21TH2_LTCSDL; integrated security=true";
            //2. Khai báo đối tượng kết nối
            SqlConnection cnn = new SqlConnection(strcon);
            //3. Mở kết nối
            cnn.Open();
            //4. Kiểm tra xem kết nối có mở được hay không
            if (cnn.State == ConnectionState.Open)
                MessageBox.Show("kết nối đã mở");
            //5. Sau khi sử dụng xong thì đóng kết nối lại
            cnn.Close();
        }

        private void btnSQLsa_Click(object sender, EventArgs e)
        {
            // Khai báo các đối tượng cần sử dụng để tạo kết nối
            //1. Chuỗi kết nối đến SQL Server bằng user của Windows
            string strcon = @"server=.; database=C21TH2_LTCSDL; uid=sa; pwd=c21th";
            //2. Khai báo đối tượng kết nối
            SqlConnection cnn = new SqlConnection(strcon);
            //3. Mở kết nối
            cnn.Open();
            //4. Kiểm tra xem kết nối có mở được hay không
            if (cnn.State == ConnectionState.Open)
                MessageBox.Show("kết nối đã mở");
            //5. Sau khi sử dụng xong thì đóng kết nối lại
            cnn.Close();
        }
    }
}
