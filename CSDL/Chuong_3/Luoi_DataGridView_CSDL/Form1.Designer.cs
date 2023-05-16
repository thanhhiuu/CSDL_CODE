namespace Luoi_DataGridView_CSDL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMonHoc = new System.Windows.Forms.DataGridView();
            this.colMaMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnkhong = new System.Windows.Forms.Button();
            this.btnghi = new System.Windows.Forms.Button();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.txtsotiet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txttenmh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmamh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMonHoc
            // 
            this.dgvMonHoc.AllowUserToAddRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMonHoc.ColumnHeadersHeight = 29;
            this.dgvMonHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaMH,
            this.colTenMH,
            this.colSoTiet});
            this.dgvMonHoc.EnableHeadersVisualStyles = false;
            this.dgvMonHoc.Location = new System.Drawing.Point(50, 36);
            this.dgvMonHoc.MultiSelect = false;
            this.dgvMonHoc.Name = "dgvMonHoc";
            this.dgvMonHoc.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DarkOliveGreen;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Brown;
            this.dgvMonHoc.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMonHoc.RowTemplate.Height = 24;
            this.dgvMonHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonHoc.Size = new System.Drawing.Size(662, 220);
            this.dgvMonHoc.TabIndex = 15;
            // 
            // colMaMH
            // 
            this.colMaMH.DataPropertyName = "MaMH";
            this.colMaMH.HeaderText = "Mã Môn Học";
            this.colMaMH.MinimumWidth = 6;
            this.colMaMH.Name = "colMaMH";
            this.colMaMH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMaMH.Width = 130;
            // 
            // colTenMH
            // 
            this.colTenMH.DataPropertyName = "TenMH";
            this.colTenMH.HeaderText = "Tên Môn Học";
            this.colTenMH.MinimumWidth = 6;
            this.colTenMH.Name = "colTenMH";
            this.colTenMH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTenMH.Width = 200;
            // 
            // colSoTiet
            // 
            this.colSoTiet.DataPropertyName = "SoTiet";
            this.colSoTiet.HeaderText = "Số Tiết";
            this.colSoTiet.MinimumWidth = 6;
            this.colSoTiet.Name = "colSoTiet";
            this.colSoTiet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSoTiet.Width = 130;
            // 
            // btnkhong
            // 
            this.btnkhong.Location = new System.Drawing.Point(536, 471);
            this.btnkhong.Name = "btnkhong";
            this.btnkhong.Size = new System.Drawing.Size(86, 31);
            this.btnkhong.TabIndex = 22;
            this.btnkhong.Text = "Không";
            this.btnkhong.UseVisualStyleBackColor = true;
            this.btnkhong.Click += new System.EventHandler(this.btnkhong_Click);
            // 
            // btnghi
            // 
            this.btnghi.Location = new System.Drawing.Point(443, 471);
            this.btnghi.Name = "btnghi";
            this.btnghi.Size = new System.Drawing.Size(86, 31);
            this.btnghi.TabIndex = 23;
            this.btnghi.Text = "Ghi";
            this.btnghi.UseVisualStyleBackColor = true;
            this.btnghi.Click += new System.EventHandler(this.btnghi_Click);
            // 
            // btnhuy
            // 
            this.btnhuy.Location = new System.Drawing.Point(351, 471);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(86, 31);
            this.btnhuy.TabIndex = 24;
            this.btnhuy.Text = "Hủy";
            this.btnhuy.UseVisualStyleBackColor = true;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(259, 471);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(86, 31);
            this.btnthem.TabIndex = 25;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // txtsotiet
            // 
            this.txtsotiet.Location = new System.Drawing.Point(203, 404);
            this.txtsotiet.Name = "txtsotiet";
            this.txtsotiet.Size = new System.Drawing.Size(509, 22);
            this.txtsotiet.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Số Tiết";
            // 
            // txttenmh
            // 
            this.txttenmh.Location = new System.Drawing.Point(203, 347);
            this.txttenmh.Name = "txttenmh";
            this.txttenmh.Size = new System.Drawing.Size(509, 22);
            this.txttenmh.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Tên Môn Học";
            // 
            // txtmamh
            // 
            this.txtmamh.Location = new System.Drawing.Point(203, 288);
            this.txtmamh.Name = "txtmamh";
            this.txtmamh.Size = new System.Drawing.Size(509, 22);
            this.txtmamh.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Mã Môn Học";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 532);
            this.Controls.Add(this.dgvMonHoc);
            this.Controls.Add(this.btnkhong);
            this.Controls.Add(this.btnghi);
            this.Controls.Add(this.btnhuy);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.txtsotiet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txttenmh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtmamh);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "DataGridView CSDL";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTiet;
        private System.Windows.Forms.Button btnkhong;
        private System.Windows.Forms.Button btnghi;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.TextBox txtsotiet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttenmh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmamh;
        private System.Windows.Forms.Label label1;
    }
}

