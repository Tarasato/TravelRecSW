using System;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TravelRecSW
{
    public partial class FrmRegister : Form
    {
        //สร้างตัวแปรเก็บรูปuserในรูปของbyte[] เพื่อเอาไปเก็บในDB แบบ image
        byte[] travellerImage;
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void tbTravellerPassword_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int showTooltipTime = 3000; // milliseconds

            ToolTip tt = new ToolTip();
            tt.Show("รหัสผ่านต้องมีความยาว 6 ตัวอักษร", tb, 20, 20, showTooltipTime);
        }

        private void tbTravellerPasswordConfirm_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            int showTooltipTime = 3000; // milliseconds

            ToolTip tt = new ToolTip();
            tt.Show("รหัสผ่านต้องมีความยาว 6 ตัวอักษร", tb, 20, 20, showTooltipTime);
        }

//bt Function====================================================================
        private void btSelectTravellerImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //เอารูปที่เลือกมาแสดงใน PictureBox
                pbTravellerImage.Image = Image.FromFile(ofd.FileName);

                //แปลงรูปที่เลือกมาเป็น byte[] เก็บใน travellerImage
                //สร้างตัวแปรเก็บประเภทไฟล์
                string extFile = Path.GetExtension(ofd.FileName);
                //แปลงรูปเป็น byte[]
                using (MemoryStream ms = new MemoryStream())
                {
                    if (extFile == ".jpg" || extFile == ".jpeg")
                    {
                        pbTravellerImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else
                    {
                        pbTravellerImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    travellerImage = ms.ToArray();
                }
            }
        }
        //btSave====================================================================
        private void tsbtSave_Click(object sender, EventArgs e)
        {
            //Validate UI
            if (tbTravellerFullname.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณากรอกชื่อ-นามสกุล");
            }
            else if (tbTravellerEmail.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณากรอกEmail");
            }
            else if ( ! tbTravellerEmail.Text.Trim().Contains("@"))
            {
                ShareInfo.showWarningMSG("รูปแบบ Email ไม่ถูกต้อง");
            }
            else if (tbTravellerPassword.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณากรอกรหัสผ่าน");
            }
            else if (tbTravellerPassword.Text.Trim().Length < 6)
            {
                ShareInfo.showWarningMSG("รหัสผ่านต้องมีความยาว 6 ตัวอักษร");
            }
            else if (tbTravellerPasswordConfirm.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณากรอกยืนยันรหัสผ่าน");
            }
            else if (tbTravellerPasswordConfirm.Text.Trim() != tbTravellerPassword.Text.Trim())
            {
                ShareInfo.showWarningMSG("รหัสผ่านไม่ตรงกัน");
            }
            else if (travellerImage == null)
            {
                ShareInfo.showWarningMSG("กรุณาเลือกรูปภาพ");
            }
            else if (cbConfirm.Checked == false)
            {
                ShareInfo.showWarningMSG("กรุณายอมรับเงื่อนไขการใช้งาน");
            }
            else
            {
                //Save to DB
                //connect to DB
                SqlConnection conn = new SqlConnection(ShareInfo.conStr);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                //===============================================================
                //SQL command
                string strSql = "INSERT INTO traveller_tb" +
                                "(travellerFullname, travellerEmail, travellerPassword, travellerImage)" +
                                "VALUES " + 
                                 "(@travellerFullname, @travellerEmail, @travellerPassword, @travellerImage)";
                //===============================================================
                //create sql transaction and sql command for working with SQL
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = strSql;
                sqlCommand.Transaction = sqlTransaction;
                //===============================================================
                //bindParam
                sqlCommand.Parameters.AddWithValue("@travellerFullname", tbTravellerFullname.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@travellerEmail", tbTravellerEmail.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@travellerPassword", tbTravellerPassword.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@travellerImage", travellerImage);
                //===============================================================
                //run SQL
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    conn.Close();

                    MessageBox.Show("ลงทะเบียนสำเร็จ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmLogin frmLogin = new FrmLogin();
                    frmLogin.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conn.Close();

                    ShareInfo.showWarningMSG("Having an exception please try againg or call devleloper" + ex.Message);
                }
                
            }

        }

        

        private void tsbtCancel_Click(object sender, EventArgs e)
        {
            tbTravellerFullname.Clear();
            tbTravellerEmail.Clear();
            tbTravellerPassword.Clear();
            tbTravellerPasswordConfirm.Clear();
            pbTravellerImage.Image = Properties.Resources.profile;
            travellerImage = null;
            cbConfirm.Checked = false;

        }
        private void tsbtToFrmLogin_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }
    }
}
