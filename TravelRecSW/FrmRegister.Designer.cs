namespace TravelRecSW
{
    partial class FrmRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegister));
            this.label1 = new System.Windows.Forms.Label();
            this.btSelectTravellerImage = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbTravellerImage = new System.Windows.Forms.PictureBox();
            this.tbTravellerEmail = new System.Windows.Forms.TextBox();
            this.tbTravellerFullname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTravellerPasswordConfirm = new System.Windows.Forms.TextBox();
            this.tbTravellerPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtSave = new System.Windows.Forms.ToolStripButton();
            this.tsbtCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtToFrmLogin = new System.Windows.Forms.ToolStripButton();
            this.cbConfirm = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTravellerImage)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(43, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(679, 59);
            this.label1.TabIndex = 2;
            this.label1.Text = "ลงทะเบียน";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btSelectTravellerImage
            // 
            this.btSelectTravellerImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSelectTravellerImage.Location = new System.Drawing.Point(116, 385);
            this.btSelectTravellerImage.Margin = new System.Windows.Forms.Padding(4);
            this.btSelectTravellerImage.Name = "btSelectTravellerImage";
            this.btSelectTravellerImage.Size = new System.Drawing.Size(181, 42);
            this.btSelectTravellerImage.TabIndex = 3;
            this.btSelectTravellerImage.Text = "Select your image";
            this.btSelectTravellerImage.UseVisualStyleBackColor = true;
            this.btSelectTravellerImage.Click += new System.EventHandler(this.btSelectTravellerImage_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pbTravellerImage);
            this.panel1.Location = new System.Drawing.Point(111, 135);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 230);
            this.panel1.TabIndex = 4;
            // 
            // pbTravellerImage
            // 
            this.pbTravellerImage.Image = global::TravelRecSW.Properties.Resources.profile;
            this.pbTravellerImage.Location = new System.Drawing.Point(4, 4);
            this.pbTravellerImage.Margin = new System.Windows.Forms.Padding(4);
            this.pbTravellerImage.Name = "pbTravellerImage";
            this.pbTravellerImage.Size = new System.Drawing.Size(181, 220);
            this.pbTravellerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTravellerImage.TabIndex = 1;
            this.pbTravellerImage.TabStop = false;
            // 
            // tbTravellerEmail
            // 
            this.tbTravellerEmail.Location = new System.Drawing.Point(399, 228);
            this.tbTravellerEmail.Margin = new System.Windows.Forms.Padding(4);
            this.tbTravellerEmail.Name = "tbTravellerEmail";
            this.tbTravellerEmail.Size = new System.Drawing.Size(249, 22);
            this.tbTravellerEmail.TabIndex = 9;
            // 
            // tbTravellerFullname
            // 
            this.tbTravellerFullname.Location = new System.Drawing.Point(399, 169);
            this.tbTravellerFullname.Margin = new System.Windows.Forms.Padding(4);
            this.tbTravellerFullname.Name = "tbTravellerFullname";
            this.tbTravellerFullname.Size = new System.Drawing.Size(249, 22);
            this.tbTravellerFullname.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(399, 198);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "อีเมล์";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(399, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "ชื่อ - สกุล";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbTravellerPasswordConfirm
            // 
            this.tbTravellerPasswordConfirm.Location = new System.Drawing.Point(399, 346);
            this.tbTravellerPasswordConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.tbTravellerPasswordConfirm.Name = "tbTravellerPasswordConfirm";
            this.tbTravellerPasswordConfirm.PasswordChar = '*';
            this.tbTravellerPasswordConfirm.Size = new System.Drawing.Size(249, 22);
            this.tbTravellerPasswordConfirm.TabIndex = 13;
            this.tbTravellerPasswordConfirm.Enter += new System.EventHandler(this.tbTravellerPasswordConfirm_Enter);
            // 
            // tbTravellerPassword
            // 
            this.tbTravellerPassword.Location = new System.Drawing.Point(399, 287);
            this.tbTravellerPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbTravellerPassword.Name = "tbTravellerPassword";
            this.tbTravellerPassword.PasswordChar = '*';
            this.tbTravellerPassword.Size = new System.Drawing.Size(249, 22);
            this.tbTravellerPassword.TabIndex = 12;
            this.tbTravellerPassword.Enter += new System.EventHandler(this.tbTravellerPassword_Enter);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(399, 316);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "ยืนยันรหัสผ่าน";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(399, 257);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "รหัสผ่าน";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtSave,
            this.tsbtCancel,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.tsbtToFrmLogin});
            this.toolStrip1.Location = new System.Drawing.Point(756, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(171, 463);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtSave
            // 
            this.tsbtSave.Image = global::TravelRecSW.Properties.Resources.save;
            this.tsbtSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtSave.Name = "tsbtSave";
            this.tsbtSave.Size = new System.Drawing.Size(169, 24);
            this.tsbtSave.Text = "บันทึก";
            this.tsbtSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbtSave.Click += new System.EventHandler(this.tsbtSave_Click);
            // 
            // tsbtCancel
            // 
            this.tsbtCancel.Image = global::TravelRecSW.Properties.Resources.cancel;
            this.tsbtCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtCancel.Name = "tsbtCancel";
            this.tsbtCancel.Size = new System.Drawing.Size(169, 24);
            this.tsbtCancel.Text = "ยกเลิก";
            this.tsbtCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbtCancel.Click += new System.EventHandler(this.tsbtCancel_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripLabel1.Size = new System.Drawing.Size(169, 0);
            this.toolStripLabel1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // tsbtToFrmLogin
            // 
            this.tsbtToFrmLogin.Image = global::TravelRecSW.Properties.Resources.logo;
            this.tsbtToFrmLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtToFrmLogin.Name = "tsbtToFrmLogin";
            this.tsbtToFrmLogin.Size = new System.Drawing.Size(169, 24);
            this.tsbtToFrmLogin.Text = "เข้าใช้งานระบบ";
            this.tsbtToFrmLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbtToFrmLogin.Click += new System.EventHandler(this.tsbtToFrmLogin_Click);
            // 
            // cbConfirm
            // 
            this.cbConfirm.AutoSize = true;
            this.cbConfirm.Location = new System.Drawing.Point(445, 398);
            this.cbConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.cbConfirm.Name = "cbConfirm";
            this.cbConfirm.Size = new System.Drawing.Size(121, 20);
            this.cbConfirm.TabIndex = 15;
            this.cbConfirm.Text = "ยืนยันการลงทะเบียน";
            this.cbConfirm.UseVisualStyleBackColor = true;
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 463);
            this.Controls.Add(this.cbConfirm);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tbTravellerPasswordConfirm);
            this.Controls.Add(this.tbTravellerPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbTravellerEmail);
            this.Controls.Add(this.tbTravellerFullname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btSelectTravellerImage);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ลงทะเบียน - Travel Rec SW V.1.0";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTravellerImage)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTravellerImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSelectTravellerImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbTravellerEmail;
        private System.Windows.Forms.TextBox tbTravellerFullname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTravellerPasswordConfirm;
        private System.Windows.Forms.TextBox tbTravellerPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtSave;
        private System.Windows.Forms.ToolStripButton tsbtCancel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtToFrmLogin;
        private System.Windows.Forms.CheckBox cbConfirm;
    }
}