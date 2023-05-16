namespace Luoi_DataGitdView_03
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
            this.MaMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMonHoc
            // 
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
            this.MaMH,
            this.TenMH,
            this.SoTiet});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMonHoc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMonHoc.EnableHeadersVisualStyles = false;
            this.dgvMonHoc.Location = new System.Drawing.Point(13, 185);
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
            this.dgvMonHoc.TabIndex = 5;
            this.dgvMonHoc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMonHoc_CellContentClick);
            this.dgvMonHoc.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMonHoc_RowValidating);
            this.dgvMonHoc.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvMonHoc_UserDeletedRow);
            this.dgvMonHoc.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvMonHoc_UserDeletingRow);
            // 
            // MaMH
            // 
            this.MaMH.DataPropertyName = "MaMH";
            this.MaMH.HeaderText = "Mã Môn Học";
            this.MaMH.MinimumWidth = 6;
            this.MaMH.Name = "MaMH";
            this.MaMH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MaMH.Width = 130;
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
            // SoTiet
            // 
            this.SoTiet.DataPropertyName = "SoTiet";
            this.SoTiet.HeaderText = "Số Tiết";
            this.SoTiet.MinimumWidth = 6;
            this.SoTiet.Name = "SoTiet";
            this.SoTiet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SoTiet.Width = 130;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 591);
            this.Controls.Add(this.dgvMonHoc);
            this.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "DataGirdView _05";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTiet;
    }
}

