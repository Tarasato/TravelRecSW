using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelRecSW
{
    public partial class FrmTravelAdd : Form
    {       

        public FrmTravelAdd()
        {
            InitializeComponent();
        }
        //btSelectTravelImage===============================================
        //สร้างตัวแปรเก็บรูปuserในรูปของbyte[] เพื่อเอาไปเก็บในDB แบบ image
        byte[] travelImage;
        private void btSelectTravelImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //เอารูปที่เลือกมาแสดงใน PictureBox
                pbTravelImage.Image = Image.FromFile(ofd.FileName);

                //แปลงรูปที่เลือกมาเป็น byte[] เก็บใน travellerImage
                //สร้างตัวแปรเก็บประเภทไฟล์
                string extFile = Path.GetExtension(ofd.FileName);
                //แปลงรูปเป็น byte[]
                using (MemoryStream ms = new MemoryStream())
                {
                    if (extFile == ".jpg" || extFile == ".jpeg")
                    {
                        pbTravelImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else
                    {
                        pbTravelImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    travelImage = ms.ToArray();
                }
            }
        }
        //btSave===============================================
        private void tsbtSave_Click(object sender, EventArgs e)
        {
            //Validate data
            if (tbTravelPlace.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณากรอกชื่อการเดินทาง");
            }
            else if (pbTravelImage.Image == null)
            {
                ShareInfo.showWarningMSG("เลือกรูปภาพด้วย");
            }
            else if (dtpTravelEndDate.Value < dtpTravelStartDate.Value.Date)
            {
                ShareInfo.showWarningMSG("วันที่กลับต้องไม่น้อยกว่าหรือวันเดียวกันกับวันที่ไป");
            }
            else if (tbTravelCostTotal.Text.Trim().Length ==0) 
            {
                ShareInfo.showWarningMSG("ป้อนค่าใช้จ่านตลอดการเดินทางด้วย");
            }
            
            else
            {
                //sent data to DB
                //connect to DB
                SqlConnection conn = new SqlConnection(ShareInfo.conStr);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open(); // Open the connection
                //Sql Command

                string strSql = "INSERT INTO travel_tb (travelPlace, travelStartDate, travelEndDate, travelCostTotal, travelImage, travellerId) " +
                "VALUES (@travelPlace, @travelStartDate, @travelEndDate, @travelCostTotal, @travelImage, @travellerId)";

                //create sql transaction and sql command for working with SQL
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = strSql;
                sqlCommand.Transaction = sqlTransaction;

                //bindParam
                sqlCommand.Parameters.AddWithValue("@travelPlace", tbTravelPlace.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@travelStartDate", dtpTravelStartDate.Value.Date);
                sqlCommand.Parameters.AddWithValue("@travelEndDate", dtpTravelEndDate.Value.Date);
                sqlCommand.Parameters.AddWithValue("@travelCostTotal", float.Parse(tbTravelCostTotal.Text.Trim()));
                sqlCommand.Parameters.AddWithValue("@travelImage", travelImage); //byte[]
                sqlCommand.Parameters.AddWithValue("@travellerId", ShareInfo.travellerId);
                //==========================================================================================================
                //run SQL
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    conn.Close();

                    MessageBox.Show("บันทึกการเดินทางสำเร็จ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //FrmLogin frmLogin = new FrmLogin();
                    //frmLogin.Show();
                    //this.Hide();
                    
                    Dispose();//DIalogClose
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conn.Close();

                    ShareInfo.showWarningMSG("Having an exception please try againg or call devleloper " + ex.Message + "TwT");
                }
            }
        }
        //btCancel============================================================================
        private void tsbtCancel_Click(object sender, EventArgs e)
        {
            tbTravelPlace.Clear();
            tbTravelCostTotal.Clear();
            dtpTravelEndDate.Value = DateTime.Now;
            dtpTravelStartDate.Value = DateTime.Now;
            travelImage = null;
            pbTravelImage.Image = Properties.Resources.logo;
        }

        private void tbTravelCostTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && textBox.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }
    }
}
