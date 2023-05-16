namespace DataGridView_02
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Aqua;
            this.dgvMonHoc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.OrangeRed;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonHoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMonHoc.ColumnHeadersHeight = 29;
            this.dgvMonHoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaMH,
            this.colTenMH,
            this.colSoTiet});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMonHoc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMonHoc.EnableHeadersVisualStyles = false;
            this.dgvMonHoc.Location = new System.Drawing.Point(51, 56);
            this.dgvMonHoc.MultiSelect = false;
            this.dgvMonHoc.Name = "dgvMonHoc";
            this.dgvMonHoc.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.OrangeRed;
            this.dgvMonHoc.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMonHoc.RowTemplate.Height = 24;
            this.dgvMonHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonHoc.Size = new System.Drawing.Size(509, 220);
            this.dgvMonHoc.TabIndex = 4;
            this.dgvMonHoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMonHoc_CellClick);
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
            this.btnkhong.Location = new System.Drawing.Point(473, 496);
            this.btnkhong.Name = "btnkhong";
            this.btnkhong.Size = new System.Drawing.Size(86, 31);
            this.btnkhong.TabIndex = 11;
            this.btnkhong.Text = "Không";
            this.btnkhong.UseVisualStyleBackColor = true;
            this.btnkhong.Click += new System.EventHandler(this.btnkhong_Click);
            // 
            // btnghi
            // 
            this.btnghi.Location = new System.Drawing.Point(374, 496);
            this.btnghi.Name = "btnghi";
            this.btnghi.Size = new System.Drawing.Size(86, 31);
            this.btnghi.TabIndex = 12;
            this.btnghi.Text = "Ghi";
            this.btnghi.UseVisualStyleBackColor = true;
            this.btnghi.Click += new System.EventHandler(this.btnghi_Click);
            // 
            // btnhuy
            // 
            this.btnhuy.Location = new System.Drawing.Point(274, 496);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(86, 31);
            this.btnhuy.TabIndex = 13;
            this.btnhuy.Text = "Hủy";
            this.btnhuy.UseVisualStyleBackColor = true;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(175, 496);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(86, 31);
            this.btnthem.TabIndex = 14;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // txtsotiet
            // 
            this.txtsotiet.Location = new System.Drawing.Point(203, 429);
            this.txtsotiet.Name = "txtsotiet";
            this.txtsotiet.Size = new System.Drawing.Size(357, 28);
            this.txtsotiet.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 429);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Số Tiết";
            // 
            // txttenmh
            // 
            this.txttenmh.Location = new System.Drawing.Point(203, 372);
            this.txttenmh.Name = "txttenmh";
            this.txttenmh.Size = new System.Drawing.Size(357, 28);
            this.txttenmh.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên Môn Học";
            // 
            // txtmamh
            // 
            this.txtmamh.Location = new System.Drawing.Point(203, 313);
            this.txtmamh.Name = "txtmamh";
            this.txtmamh.Size = new System.Drawing.Size(357, 28);
            this.txtmamh.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mã Môn Học";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 591);
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
            this.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "DataGridView";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMonHoc;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTiet;
    }
}

