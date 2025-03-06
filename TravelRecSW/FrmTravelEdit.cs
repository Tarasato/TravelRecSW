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
    public partial class FrmTravelEdit : Form
    {
        private int travelId;
        public FrmTravelEdit(int travelId)
        {
            InitializeComponent();
            this.travelId = travelId;

        }
        //MethodGetTravelForEdit===============================================
        public void getTravelForEdit()
        {
            //เอา travelId ไปดึงข้อมูลจาก DB มาแสดงผล
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
            string strSql = "SELECT * FROM travel_tb WHERE travelId = @travelId";
            //create sql transaction and sql command for working with SQL
            SqlTransaction sqlTransaction = conn.BeginTransaction();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = strSql;
            sqlCommand.Transaction = sqlTransaction;
            //===============================================================
            //bindParam
            sqlCommand.Parameters.AddWithValue("@travelId", travelId);

            //===============================================================
            //Run SQL
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            conn.Close();

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            //===============================================================
            //เอาไปกำหนดค่าให้แต่ละส่วนของ UI
            tbTravelPlace.Text = dt.Rows[0]["travelPlace"].ToString();
            dtpTravelStartDate.Value = (DateTime)dt.Rows[0]["travelStartDate"];
            dtpTravelEndDate.Value = (DateTime)dt.Rows[0]["travelEndDate"];
            tbTravelCostTotal.Text = dt.Rows[0]["travelCostTotal"].ToString();

            //Show travelImage
            using (MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["travelImage"]))
            {
                pbTravelImage.Image = Image.FromStream(ms);
            }
            //===============================================================
        }
        //btSelectTravelImage===============================================
        //สร้างตัวแปรเก็บรูปuserในรูปของbyte[] เพื่อเอาไปเก็บในDB แบบ image
        byte[] travelImage, travelNewImage;
        
        private void FrmTravelEdit_Load(object sender, EventArgs e)
        {
            getTravelForEdit();
        }

        private void tsbtSave_Click(object sender, EventArgs e)
        {
            //Validate data
            if (tbTravelPlace.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณากรอกชื่อการเดินทาง");
            }
            else if (dtpTravelEndDate.Value < dtpTravelStartDate.Value)
            {
                ShareInfo.showWarningMSG("วันที่กลับต้องไม่น้อยกว่าหรือวันเดียวกันกับวันที่ไป");
            }
            else if (tbTravelCostTotal.Text.Trim().Length == 0)
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
                //=========================================================================================================
                //Sql Command
                string strSql = "";

                //Validate Image
                if (travelNewImage == null)
                {
                    strSql = "UPDATE travel_tb SET travelPlace = @travelPlace,travelStartDate = @travelStartDate, " +
                        "travelEndDate = @travelEndDate, travelCostTotal = @travelCostTotal WHERE travelId = @travelId";
                }
                else
                {
                    strSql = "UPDATE travel_tb SET travelPlace = @travelPlace, travelStartDate = @travelStartDate, " +
                        "travelEndDate = @travelEndDate, travelCostTotal = @travelCostTotal, travelImage = @travelImage " +
                        "WHERE travelId = @travelId";
                }
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

                if (travelNewImage != null)
                {
                    sqlCommand.Parameters.AddWithValue("@travelImage", travelNewImage); //byte[]
                }
                sqlCommand.Parameters.AddWithValue("@travellerId", ShareInfo.travellerId);
                sqlCommand.Parameters.AddWithValue("@travelId",travelId);
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

                    ShareInfo.showWarningMSG("Having an exception please try againg or call devleloper" + ex.Message);
                }
            }
        }
        //btCancel============================================================================
        private void tsbtCancel_Click(object sender, EventArgs e)
        {
            getTravelForEdit();
            travelImage = null;
        }
        //Keypress CostTotal=============================================================**************
        private void tbTravelCostTotal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //btSelectTravelImage===============================================
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
                    travelNewImage = ms.ToArray();
                }
            }
        }
    }

}
