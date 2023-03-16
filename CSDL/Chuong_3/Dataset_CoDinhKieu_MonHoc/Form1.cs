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

namespace Dataset_CoDinhKieu_MonHoc
{
    public partial class Form1 : Form
    {
        // Khai báo dataset co dinh kieu ds
        QLSINHVIEN ds = new QLSINHVIEN();
        // Khai bao doi tuong DataDapter
        QLSINHVIENTableAdapters.MonHocTableAdapter dapMonHoc = new QLSINHVIENTableAdapters.MonHocTableAdapter();
        QLSINHVIENTableAdapters.KetQuaTableAdapter dapKetQua = new QLSINHVIENTableAdapters.KetQuaTableAdapter();

        BindingSource bs = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            // Phat sinh su kien Current_Changed cua BinDingSource
            bs.CurrentChanged += Bs_CurrentChanged;
        }

        private void Bs_CurrentChanged(object sender, EventArgs e)
        {
            // Methods nay duoc tu dong thi hanh khi co Event di chuyen mau tin
            lblSTT.Text = bs.Position + 1 + " / " + bs.Count;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Doc_Du_Lieu();
            Khoi_Tao_BinDingSource();
            Lien_Ket_Dieu_Kien();
        }

        private void Lien_Ket_Dieu_Kien()
        {
            // 1. Su dung loop de lien ket cac dieu khien tren form voisw BinDingSource
            foreach (Control ctrl in this.Controls)
                if (ctrl is TextBox && ctrl.Name != "txtloaimh")
                    ctrl.DataBindings.Add("text", bs, ctrl.Name.Substring(3), true);

            // Dinh dang lai so tiet truoc khi hien thi
            txtsotiet.DataBindings[0].FormatString = "00 Tiet";
            // BinDing Rieng cho txtloaimh chua du lieu kieu boolean
            Binding bdmh = new Binding("text", bs, "LoaiMH", true);

            // Phat sinh Event Format va Parse cho Object dbmh
            bdmh.Format += Bdmh_Format;
            bdmh.Parse += Bdmh_Parse;

            // Them doi tuong BinDing dbmh vao dieu kien txtloaimh
            txtloaimh.DataBindings.Add(bdmh);
        }
        private void Bdmh_Parse(object sender, ConvertEventArgs e)
        {
            // Xay ra khi data duoc chuyen tu dieu khien tren Form ve DataTable (Data duoc chua trong e.Value)
            if (e.Value == null) return;
            e.Value = e.Value.ToString().ToUpper() == "Bắt buộc" ? true : false;
        }

        private void Bdmh_Format(object sender, ConvertEventArgs e)
        {
            // Xay ra khi du lieu (e.Value) duoc chuyen tu DataTable den form hoac khi chinh sua data cua Control tren Form 
            if (e.Value == DBNull.Value || e.Value == null) return;
            e.Value = (Boolean)e.Value ? "Bắt buộc" : "Tự chọn";
        }
        private void Khoi_Tao_BinDingSource()
        {
            bs.DataSource = ds;
            bs.DataMember = ds.MonHoc.TableName;

            bdnmonhoc.BindingSource = bs;
        }

        private void Doc_Du_Lieu()
        {

            dapMonHoc.Fill(ds.MonHoc);

            dapKetQua.Fill(ds.KetQua);
        }

        private void btndau_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void btntruoc_Click(object sender, EventArgs e)
        {
            bs.MoveNext();
        }

        private void btnsau_Click(object sender, EventArgs e)
        {
            bs.MovePrevious();
        }

        private void btncuoi_Click(object sender, EventArgs e)
        {
            bs.MoveLast();
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            txtmamh.ReadOnly = true;
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            if (!txtmamh.ReadOnly) // Them moi
            {
                QLSINHVIEN.MonHocRow rmh = ds.MonHoc.FindByMAMH(txtmamh.Text);
                if (rmh!=null)
                {
                    MessageBox.Show("Trung khoa chinh nhap lai !");
                    txtmamh.Focus();
                    return;
                }
            }
            txtmamh.ReadOnly = true;
            // Cap nhat lai viec them moi hay sua trong DataTable 
            bs.EndEdit();
            // Cap nhat lai CSDL
            int n = dapMonHoc.Update(ds.MonHoc);
            if (n > 0)
                MessageBox.Show("Cap nhat mon hoc thanh cong");
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            // Hủy trong DataTable
            // 1. Kiểm tra có tồn tại các mẫu tin có liên quan trong KETQUA hay không trước khi hủy
            QLSINHVIEN.MonHocRow rmh = (bs.Current as DataRowView).Row as QLSINHVIEN.MonHocRow;

            if (rmh.GetKetQuaRows().Length > 0)
            {
                MessageBox.Show("Khong xoa duoc do ton tai dong lien quan trong KETQUA");
                return;
            }
            bs.RemoveCurrent();
            // Hủy trong CSDL
            int n = dapMonHoc.Update(ds.MonHoc);
            if (n > 0)
                MessageBox.Show("Huy mon hoc thanh cong");
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            txtmamh.ReadOnly = false;
            // Create
            bs.AddNew();
            txtmamh.Focus();
        }
    }
}
/// Dataset co dinh kieu (typed Dataset)
/// 1.Ket noi CSDL: ket noi den SQL Server hoac Access (using server Eplorer)
/// 2. Tao Dataset: R - Click Project => Add new Items => Dataset => Dat ten
/// 3. Drag mouse keo cac Table trong CSDL vao vua so Dataset
/// 4. Cac class duoc tao ra trong Dataset co dinh kieu
/// 4.1 Class Dataset voi ten la ten duoc dac khi tao doi tuong Dataset
/// 4.2 Cac class DataAdapter tuong ung voi tung DataTable cung duoc tao ra (Chua trong namespace bat dau bang Dataset)
/// 4.3 Cac class tuong ung voi DataTable voi DataRow cua tuong 
/// 4.4 Cac Object duoc tao ra: tuong ung voi cac DataTable