namespace TravelRecSW
{
    partial class FrmTravelOpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTravelOpt));
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbtEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbtDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtToFrmLogin = new System.Windows.Forms.ToolStripButton();
            this.dgvTravel = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbTravellerImage = new System.Windows.Forms.PictureBox();
            this.lbTravellerFullname = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTravel)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTravellerImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(48, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(963, 59);
            this.label1.TabIndex = 3;
            this.label1.Text = "การเดินทางของฉัน";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtAdd,
            this.tsbtEdit,
            this.tsbtDelete,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.tsbtToFrmLogin});
            this.toolStrip1.Location = new System.Drawing.Point(1064, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(171, 587);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtAdd
            // 
            this.tsbtAdd.Image = global::TravelRecSW.Properties.Resources.add;
            this.tsbtAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtAdd.Name = "tsbtAdd";
            this.tsbtAdd.Size = new System.Drawing.Size(169, 24);
            this.tsbtAdd.Text = "เพิ่ม";
            this.tsbtAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbtAdd.Click += new System.EventHandler(this.tsbtAdd_Click);
            // 
            // tsbtEdit
            // 
            this.tsbtEdit.Image = global::TravelRecSW.Properties.Resources.update;
            this.tsbtEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtEdit.Name = "tsbtEdit";
            this.tsbtEdit.Size = new System.Drawing.Size(169, 24);
            this.tsbtEdit.Text = "แก้ไข";
            this.tsbtEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbtEdit.Click += new System.EventHandler(this.tsbtEdit_Click);
            // 
            // tsbtDelete
            // 
            this.tsbtDelete.Image = global::TravelRecSW.Properties.Resources.delete;
            this.tsbtDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtDelete.Name = "tsbtDelete";
            this.tsbtDelete.Size = new System.Drawing.Size(169, 24);
            this.tsbtDelete.Text = "ลบ";
            this.tsbtDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbtDelete.Click += new System.EventHandler(this.tsbtDelete_Click);
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
            this.tsbtToFrmLogin.Image = global::TravelRecSW.Properties.Resources.logout;
            this.tsbtToFrmLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtToFrmLogin.Name = "tsbtToFrmLogin";
            this.tsbtToFrmLogin.Size = new System.Drawing.Size(169, 24);
            this.tsbtToFrmLogin.Text = "ออกจากระบบ";
            this.tsbtToFrmLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbtToFrmLogin.Click += new System.EventHandler(this.tsbtToFrmLogin_Click);
            // 
            // dgvTravel
            // 
            this.dgvTravel.AllowUserToAddRows = false;
            this.dgvTravel.AllowUserToDeleteRows = false;
            this.dgvTravel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTravel.Location = new System.Drawing.Point(293, 123);
            this.dgvTravel.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTravel.Name = "dgvTravel";
            this.dgvTravel.ReadOnly = true;
            this.dgvTravel.RowHeadersWidth = 51;
            this.dgvTravel.Size = new System.Drawing.Size(684, 420);
            this.dgvTravel.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pbTravellerImage);
            this.panel2.Location = new System.Drawing.Point(79, 214);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 187);
            this.panel2.TabIndex = 29;
            // 
            // pbTravellerImage
            // 
            this.pbTravellerImage.Image = global::TravelRecSW.Properties.Resources.profile;
            this.pbTravellerImage.Location = new System.Drawing.Point(4, 4);
            this.pbTravellerImage.Margin = new System.Windows.Forms.Padding(4);
            this.pbTravellerImage.Name = "pbTravellerImage";
            this.pbTravellerImage.Size = new System.Drawing.Size(153, 177);
            this.pbTravellerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTravellerImage.TabIndex = 1;
            this.pbTravellerImage.TabStop = false;
            // 
            // lbTravellerFullname
            // 
            this.lbTravellerFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTravellerFullname.ForeColor = System.Drawing.Color.Blue;
            this.lbTravellerFullname.Location = new System.Drawing.Point(57, 423);
            this.lbTravellerFullname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTravellerFullname.Name = "lbTravellerFullname";
            this.lbTravellerFullname.Size = new System.Drawing.Size(212, 25);
            this.lbTravellerFullname.TabIndex = 30;
            this.lbTravellerFullname.Text = "Traveller Fullname";
            this.lbTravellerFullname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmTravelOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 587);
            this.Controls.Add(this.lbTravellerFullname);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvTravel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmTravelOpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "การเดินทางของฉัน - Travel Rec SW V.1.0";
            this.Load += new System.EventHandler(this.FrmTravelOpt_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTravel)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTravellerImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtToFrmLogin;
        private System.Windows.Forms.DataGridView dgvTravel;
        private System.Windows.Forms.ToolStripButton tsbtAdd;
        private System.Windows.Forms.ToolStripButton tsbtEdit;
        private System.Windows.Forms.ToolStripButton tsbtDelete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbTravellerImage;
        private System.Windows.Forms.Label lbTravellerFullname;
    }
}