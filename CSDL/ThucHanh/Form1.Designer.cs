namespace ThucHanh
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.colSoTiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvktra = new System.Windows.Forms.DataGridView();
            this.colTenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvmonhoc = new System.Windows.Forms.DataGridView();
            this.dtpngaysinh = new System.Windows.Forms.DateTimePicker();
            this.cbomakh = new System.Windows.Forms.ComboBox();
            this.txthosv = new System.Windows.Forms.TextBox();
            this.txttongdiem = new System.Windows.Forms.TextBox();
            this.txthocbong = new System.Windows.Forms.TextBox();
            this.txtnoisinh = new System.Windows.Forms.TextBox();
            this.txttensv = new System.Windows.Forms.TextBox();
            this.txtmasv = new System.Windows.Forms.TextBox();
            this.btnkhong = new System.Windows.Forms.Button();
            this.btnghi = new System.Windows.Forms.Button();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnsau = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.btntruoc = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.chkphai = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblSTT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvktra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmonhoc)).BeginInit();
            this.SuspendLayout();
            // 
            // colSoTiet
            // 
            this.colSoTiet.DataPropertyName = "SoTiet";
            this.colSoTiet.HeaderText = "Số Tiết";
            this.colSoTiet.MinimumWidth = 6;
            this.colSoTiet.Name = "colSoTiet";
            this.colSoTiet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSoTiet.Width = 125;
            // 
            // colMaMH
            // 
            this.colMaMH.DataPropertyName = "MaMH";
            this.colMaMH.HeaderText = "Mã MH";
            this.colMaMH.MinimumWidth = 6;
            this.colMaMH.Name = "colMaMH";
            this.colMaMH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMaMH.Width = 125;
            // 
            // dgvktra
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvktra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvktra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvktra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaMH,
            this.colTenMH,
            this.colSoTiet});
            this.dgvktra.Location = new System.Drawing.Point(32, 605);
            this.dgvktra.Name = "dgvktra";
            this.dgvktra.RowHeadersWidth = 51;
            this.dgvktra.RowTemplate.Height = 24;
            this.dgvktra.Size = new System.Drawing.Size(939, 143);
            this.dgvktra.TabIndex = 153;
            // 
            // colTenMH
            // 
            this.colTenMH.DataPropertyName = "TenMH";
            this.colTenMH.HeaderText = "Tên MH";
            this.colTenMH.MinimumWidth = 6;
            this.colTenMH.Name = "colTenMH";
            this.colTenMH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTenMH.Width = 125;
            // 
            // Diem
            // 
            this.Diem.DataPropertyName = "Diem";
            this.Diem.HeaderText = "Điểm";
            this.Diem.MinimumWidth = 6;
            this.Diem.Name = "Diem";
            this.Diem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Diem.Width = 140;
            // 
            // TenMH
            // 
            this.TenMH.DataPropertyName = "TenMH";
            this.TenMH.HeaderText = "Tên Môn Học";
            this.TenMH.MinimumWidth = 6;
            this.TenMH.Name = "TenMH";
            this.TenMH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TenMH.Width = 200;
            // 
            // MaMH
            // 
            this.MaMH.DataPropertyName = "MaMH";
            this.MaMH.HeaderText = "Mã Môn Học";
            this.MaMH.MinimumWidth = 6;
            this.MaMH.Name = "MaMH";
            this.MaMH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MaMH.Width = 140;
            // 
            // dgvmonhoc
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dgvmonhoc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvmonhoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvmonhoc.ColumnHeadersHeight = 30;
            this.dgvmonhoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaMH,
            this.TenMH,
            this.Diem});
            this.dgvmonhoc.Location = new System.Drawing.Point(32, 451);
            this.dgvmonhoc.Name = "dgvmonhoc";
            this.dgvmonhoc.RowHeadersWidth = 51;
            this.dgvmonhoc.RowTemplate.Height = 24;
            this.dgvmonhoc.Size = new System.Drawing.Size(939, 148);
            this.dgvmonhoc.TabIndex = 152;
            // 
            // dtpngaysinh
            // 
            this.dtpngaysinh.CustomFormat = "dd/MM/yyyy";
            this.dtpngaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngaysinh.Location = new System.Drawing.Point(696, 207);
            this.dtpngaysinh.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.dtpngaysinh.Name = "dtpngaysinh";
            this.dtpngaysinh.Size = new System.Drawing.Size(271, 28);
            this.dtpngaysinh.TabIndex = 151;
            // 
            // cbomakh
            // 
            this.cbomakh.FormattingEnabled = true;
            this.cbomakh.Location = new System.Drawing.Point(696, 271);
            this.cbomakh.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.cbomakh.Name = "cbomakh";
            this.cbomakh.Size = new System.Drawing.Size(271, 29);
            this.cbomakh.TabIndex = 150;
            // 
            // txthosv
            // 
            this.txthosv.Location = new System.Drawing.Point(190, 144);
            this.txthosv.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txthosv.Name = "txthosv";
            this.txthosv.Size = new System.Drawing.Size(457, 28);
            this.txthosv.TabIndex = 149;
            // 
            // txttongdiem
            // 
            this.txttongdiem.Location = new System.Drawing.Point(696, 335);
            this.txttongdiem.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txttongdiem.Name = "txttongdiem";
            this.txttongdiem.Size = new System.Drawing.Size(271, 28);
            this.txttongdiem.TabIndex = 148;
            // 
            // txthocbong
            // 
            this.txthocbong.Location = new System.Drawing.Point(190, 335);
            this.txthocbong.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txthocbong.Name = "txthocbong";
            this.txthocbong.Size = new System.Drawing.Size(316, 28);
            this.txthocbong.TabIndex = 147;
            // 
            // txtnoisinh
            // 
            this.txtnoisinh.Location = new System.Drawing.Point(190, 271);
            this.txtnoisinh.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtnoisinh.Name = "txtnoisinh";
            this.txtnoisinh.Size = new System.Drawing.Size(316, 28);
            this.txtnoisinh.TabIndex = 146;
            // 
            // txttensv
            // 
            this.txttensv.Location = new System.Drawing.Point(696, 145);
            this.txttensv.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txttensv.Name = "txttensv";
            this.txttensv.Size = new System.Drawing.Size(271, 28);
            this.txttensv.TabIndex = 145;
            // 
            // txtmasv
            // 
            this.txtmasv.Location = new System.Drawing.Point(190, 79);
            this.txtmasv.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtmasv.Name = "txtmasv";
            this.txtmasv.ReadOnly = true;
            this.txtmasv.Size = new System.Drawing.Size(777, 28);
            this.txtmasv.TabIndex = 144;
            // 
            // btnkhong
            // 
            this.btnkhong.BackColor = System.Drawing.Color.Navy;
            this.btnkhong.Location = new System.Drawing.Point(858, 393);
            this.btnkhong.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnkhong.Name = "btnkhong";
            this.btnkhong.Size = new System.Drawing.Size(109, 55);
            this.btnkhong.TabIndex = 143;
            this.btnkhong.Text = "Không";
            this.btnkhong.UseVisualStyleBackColor = false;
            this.btnkhong.Click += new System.EventHandler(this.btnkhong_Click);
            // 
            // btnghi
            // 
            this.btnghi.BackColor = System.Drawing.Color.Navy;
            this.btnghi.Location = new System.Drawing.Point(713, 393);
            this.btnghi.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnghi.Name = "btnghi";
            this.btnghi.Size = new System.Drawing.Size(109, 55);
            this.btnghi.TabIndex = 142;
            this.btnghi.Text = "Ghi";
            this.btnghi.UseVisualStyleBackColor = false;
            this.btnghi.Click += new System.EventHandler(this.btnghi_Click);
            // 
            // btnhuy
            // 
            this.btnhuy.BackColor = System.Drawing.Color.Navy;
            this.btnhuy.Location = new System.Drawing.Point(575, 393);
            this.btnhuy.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(109, 55);
            this.btnhuy.TabIndex = 141;
            this.btnhuy.Text = "Huỷ";
            this.btnhuy.UseVisualStyleBackColor = false;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnsau
            // 
            this.btnsau.BackColor = System.Drawing.Color.Navy;
            this.btnsau.Location = new System.Drawing.Point(298, 393);
            this.btnsau.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnsau.Name = "btnsau";
            this.btnsau.Size = new System.Drawing.Size(109, 55);
            this.btnsau.TabIndex = 140;
            this.btnsau.Text = "Sau";
            this.btnsau.UseVisualStyleBackColor = false;
            this.btnsau.Click += new System.EventHandler(this.btnsau_Click);
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.Color.Navy;
            this.btnthem.Location = new System.Drawing.Point(436, 393);
            this.btnthem.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(109, 55);
            this.btnthem.TabIndex = 139;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = false;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btntruoc
            // 
            this.btntruoc.BackColor = System.Drawing.Color.Navy;
            this.btntruoc.Location = new System.Drawing.Point(28, 393);
            this.btntruoc.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btntruoc.Name = "btntruoc";
            this.btntruoc.Size = new System.Drawing.Size(109, 55);
            this.btntruoc.TabIndex = 138;
            this.btntruoc.Text = "Trước";
            this.btntruoc.UseVisualStyleBackColor = false;
            this.btntruoc.Click += new System.EventHandler(this.btntruoc_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(532, 343);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 21);
            this.label7.TabIndex = 135;
            this.label7.Text = "Tổng điểm";
            // 
            // chkphai
            // 
            this.chkphai.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkphai.Location = new System.Drawing.Point(28, 207);
            this.chkphai.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.chkphai.Name = "chkphai";
            this.chkphai.Size = new System.Drawing.Size(190, 51);
            this.chkphai.TabIndex = 137;
            this.chkphai.Text = "Phái";
            this.chkphai.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 343);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 21);
            this.label6.TabIndex = 134;
            this.label6.Text = "Học bỗng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(532, 278);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 21);
            this.label5.TabIndex = 133;
            this.label5.Text = "Khoa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 280);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 21);
            this.label4.TabIndex = 132;
            this.label4.Text = "Nơi sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 216);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 131;
            this.label3.Text = "Ngày sinh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 152);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 21);
            this.label2.TabIndex = 136;
            this.label2.Text = "Họ tên SV";
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1000, 82);
            this.label8.TabIndex = 129;
            this.label8.Text = "DANH SÁCH SINH VIÊN";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSTT
            // 
            this.lblSTT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSTT.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSTT.Location = new System.Drawing.Point(160, 393);
            this.lblSTT.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSTT.Name = "lblSTT";
            this.lblSTT.Size = new System.Drawing.Size(109, 55);
            this.lblSTT.TabIndex = 130;
            this.lblSTT.Text = "STT";
            this.lblSTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 128;
            this.label1.Text = "Mã SV";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 787);
            this.Controls.Add(this.dgvktra);
            this.Controls.Add(this.dgvmonhoc);
            this.Controls.Add(this.dtpngaysinh);
            this.Controls.Add(this.cbomakh);
            this.Controls.Add(this.txthosv);
            this.Controls.Add(this.txttongdiem);
            this.Controls.Add(this.txthocbong);
            this.Controls.Add(this.txtnoisinh);
            this.Controls.Add(this.txttensv);
            this.Controls.Add(this.txtmasv);
            this.Controls.Add(this.btnkhong);
            this.Controls.Add(this.btnghi);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btnsau);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.btntruoc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkphai);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSTT);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Màn Hình Sub";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvktra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmonhoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMH;
        private System.Windows.Forms.DataGridView dgvktra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMH;
        private System.Windows.Forms.DataGridView dgvmonhoc;
        private System.Windows.Forms.DateTimePicker dtpngaysinh;
        private System.Windows.Forms.ComboBox cbomakh;
        private System.Windows.Forms.TextBox txthosv;
        private System.Windows.Forms.TextBox txttongdiem;
        private System.Windows.Forms.TextBox txthocbong;
        private System.Windows.Forms.TextBox txtnoisinh;
        private System.Windows.Forms.TextBox txttensv;
        private System.Windows.Forms.TextBox txtmasv;
        private System.Windows.Forms.Button btnkhong;
        private System.Windows.Forms.Button btnghi;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnsau;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btntruoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkphai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblSTT;
        private System.Windows.Forms.Label label1;
    }
}

