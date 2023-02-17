
namespace BT00_KetNoi_CSDL
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
            this.btnacc2003 = new System.Windows.Forms.Button();
            this.btnacc2019 = new System.Windows.Forms.Button();
            this.btnSQLWin = new System.Windows.Forms.Button();
            this.btnSQLsa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnacc2003
            // 
            this.btnacc2003.Location = new System.Drawing.Point(22, 36);
            this.btnacc2003.Name = "btnacc2003";
            this.btnacc2003.Size = new System.Drawing.Size(83, 39);
            this.btnacc2003.TabIndex = 0;
            this.btnacc2003.Text = "Access 2003";
            this.btnacc2003.UseVisualStyleBackColor = true;
            this.btnacc2003.Click += new System.EventHandler(this.btnacc2003_Click);
            // 
            // btnacc2019
            // 
            this.btnacc2019.Location = new System.Drawing.Point(111, 36);
            this.btnacc2019.Name = "btnacc2019";
            this.btnacc2019.Size = new System.Drawing.Size(83, 39);
            this.btnacc2019.TabIndex = 0;
            this.btnacc2019.Text = "Access 2019";
            this.btnacc2019.UseVisualStyleBackColor = true;
            this.btnacc2019.Click += new System.EventHandler(this.btnacc2019_Click);
            // 
            // btnSQLWin
            // 
            this.btnSQLWin.Location = new System.Drawing.Point(200, 36);
            this.btnSQLWin.Name = "btnSQLWin";
            this.btnSQLWin.Size = new System.Drawing.Size(83, 39);
            this.btnSQLWin.TabIndex = 0;
            this.btnSQLWin.Text = "SQL Windows";
            this.btnSQLWin.UseVisualStyleBackColor = true;
            this.btnSQLWin.Click += new System.EventHandler(this.btnSQLWin_Click);
            // 
            // btnSQLsa
            // 
            this.btnSQLsa.Location = new System.Drawing.Point(289, 36);
            this.btnSQLsa.Name = "btnSQLsa";
            this.btnSQLsa.Size = new System.Drawing.Size(83, 39);
            this.btnSQLsa.TabIndex = 0;
            this.btnSQLsa.Text = "SQL sa";
            this.btnSQLsa.UseVisualStyleBackColor = true;
            this.btnSQLsa.Click += new System.EventHandler(this.btnSQLsa_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 102);
            this.Controls.Add(this.btnSQLsa);
            this.Controls.Add(this.btnSQLWin);
            this.Controls.Add(this.btnacc2019);
            this.Controls.Add(this.btnacc2003);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết nối CSDL";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnacc2003;
        private System.Windows.Forms.Button btnacc2019;
        private System.Windows.Forms.Button btnSQLWin;
        private System.Windows.Forms.Button btnSQLsa;
    }
}

