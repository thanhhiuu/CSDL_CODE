namespace DinhDangLuoi
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
            this.dgvluoi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvluoi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvluoi
            // 
            this.dgvluoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvluoi.Location = new System.Drawing.Point(12, 12);
            this.dgvluoi.Name = "dgvluoi";
            this.dgvluoi.RowHeadersWidth = 51;
            this.dgvluoi.RowTemplate.Height = 24;
            this.dgvluoi.Size = new System.Drawing.Size(662, 360);
            this.dgvluoi.TabIndex = 0;
            this.dgvluoi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvluoi_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 524);
            this.Controls.Add(this.dgvluoi);
            this.Name = "Form1";
            this.Text = "Định dạng lưới";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvluoi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvluoi;
    }
}

