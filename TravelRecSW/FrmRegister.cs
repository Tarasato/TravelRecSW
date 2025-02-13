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

        private void btSelectTravellerImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                //เอารูปที่เลือกมาแสดงใน PictureBox
                pbTravellerImage.Image = Image.FromFile(ofd.FileName);

                //แปลงรูปที่เลือกมาเป็น byte[] เก็บใน travellerImage
                //สร้างตัวแปรเก็บประเภทไฟล์
                string extFile = Path.GetExtension(ofd.FileName);
                //แปลงรูปเป็น byte[]
                using (MemoryStream ms = new MemoryStream())
                {
                    if(extFile == ".jpg" || extFile == ".jpeg")
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

        private void tsbtSave_Click(object sender, EventArgs e)
        {
            //Validate
            if (tbTravellerFullname.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณาป้อนชื่อ-นามสกุล");
            }
            else if (tbTravellerEmail.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณาป้อนอีเมล์");
            }
            else if (!tbTravellerEmail.Text.Trim().Contains("@"))
            {
                ShareInfo.showWarningMSG("รูปแบบอีเมล์ไม่ถูกต้อง");
            }
            else if (tbTravellerPassword.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณาป้อนรหัสผ่าน");
            }
            else if (tbTravellerPassword.Text.Trim().Length < 6)
            {
                ShareInfo.showWarningMSG("รหัสผ่านต้องมีความยาวมากกว่า 6 ตัวอักษร");
            }
            else if (tbTravellerPassword.Text.Trim() != tbTravellerPasswordConfirm.Text.Trim())
            {
                ShareInfo.showWarningMSG("รหัสและยืนยันรหัสไม่ตรงกัน");
            } else if (travellerImage == null)
            {
                ShareInfo.showWarningMSG("กรุณาเลือกรูปภาพ");
            }
            else if (!cbConfirm.Checked)
            {
                ShareInfo.showWarningMSG("กรุณายืนยันการลงทะเบียนด้วย");
            }
            else
            {
                //ติดต่อฐานข้อมูล
                SqlConnection conn = new SqlConnection(ShareInfo.connStr);
                if (conn.State == ConnectionState.Open) {
                    conn.Close();
                }
                conn.Open();

                //คำสั่ง SQL
                string strSql = "INSERT INTO traveller_tb "+
                    "(travellerFullname, travellerEmail, travellerPassword, travellerImage)" +
                    "VALUES "+
                    "(@travellerFullname, @travellerEmail, @travellerPassword, @travellerImage)";

                //สร้าง Sql Transaction และ Command
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = strSql;
                sqlCommand.Transaction = sqlTransaction;

                //Bind param เพื่อกำหนดข้อมูลให้กับ SQL Parameter
                sqlCommand.Parameters.AddWithValue("@travellerFullname", tbTravellerFullname.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@travellerEmail", tbTravellerEmail.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@travellerPassword", tbTravellerPassword.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@travellerImage", travellerImage);

                //Execute SQL Command
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    conn.Close();

                    //เมื่อบันทึกสำเร็จ แสดง MessageBox แจ้งผลการลงทะเบียน และเปิดหน้า Login
                    MessageBox.Show("ลงทะเบียนสำเร็จ", "ผลการลงทะเบียน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmLogin frmLogin = new FrmLogin();
                    frmLogin.Show();
                    Hide();
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conn.Close();
                    ShareInfo.showWarningMSG("เกิดข้อผิดพลาดในการบันทึกข้อมูล Error:" + ex.Message);
                }
            }
        }

        private void tsbtCancel_Click(object sender, EventArgs e)
        {
            pbTravellerImage.Image = Properties.Resources.profile;
            travellerImage = null;
            tbTravellerFullname.Clear();
            tbTravellerEmail.Clear();
            tbTravellerPassword.Clear();
            tbTravellerPasswordConfirm.Clear();
            cbConfirm.Checked = false;
        }

        private void tsbtToFrmLogin_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            Hide();
        }
    }
}
