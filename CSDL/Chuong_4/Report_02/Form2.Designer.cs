namespace Report_02
{
    partial class Form2
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
            this.btntruoc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmakh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txttenkh = new System.Windows.Forms.TextBox();
            this.btninan = new System.Windows.Forms.Button();
            this.btnsau = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btntruoc
            // 
            this.btntruoc.Location = new System.Drawing.Point(53, 149);
            this.btntruoc.Name = "btntruoc";
            this.btntruoc.Size = new System.Drawing.Size(104, 35);
            this.btntruoc.TabIndex = 0;
            this.btntruoc.Text = "Trước";
            this.btntruoc.UseVisualStyleBackColor = true;
            this.btntruoc.Click += new System.EventHandler(this.btntruoc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Khoa";
            // 
            // txtmakh
            // 
            this.txtmakh.Location = new System.Drawing.Point(126, 33);
            this.txtmakh.Name = "txtmakh";
            this.txtmakh.Size = new System.Drawing.Size(251, 22);
            this.txtmakh.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Khoa";
            // 
            // txttenkh
            // 
            this.txttenkh.Location = new System.Drawing.Point(126, 81);
            this.txttenkh.Name = "txttenkh";
            this.txttenkh.Size = new System.Drawing.Size(251, 22);
            this.txttenkh.TabIndex = 2;
            // 
            // btninan
            // 
            this.btninan.Location = new System.Drawing.Point(163, 149);
            this.btninan.Name = "btninan";
            this.btninan.Size = new System.Drawing.Size(104, 35);
            this.btninan.TabIndex = 0;
            this.btninan.Text = "In ấn";
            this.btninan.UseVisualStyleBackColor = true;
            this.btninan.Click += new System.EventHandler(this.btninan_Click);
            // 
            // btnsau
            // 
            this.btnsau.Location = new System.Drawing.Point(273, 149);
            this.btnsau.Name = "btnsau";
            this.btnsau.Size = new System.Drawing.Size(104, 35);
            this.btnsau.TabIndex = 0;
            this.btnsau.Text = "Sau";
            this.btnsau.UseVisualStyleBackColor = true;
            this.btnsau.Click += new System.EventHandler(this.btnsau_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 222);
            this.Controls.Add(this.txttenkh);
            this.Controls.Add(this.txtmakh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsau);
            this.Controls.Add(this.btninan);
            this.Controls.Add(this.btntruoc);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btntruoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmakh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttenkh;
        private System.Windows.Forms.Button btninan;
        private System.Windows.Forms.Button btnsau;
    }
}