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
        byte[] travelImage;

        private int travelId;
        public FrmTravelEdit(int travelId)
        {
            InitializeComponent();
            this.travelId = travelId;
        }

        private void FrmTravelEdit_Load(object sender, EventArgs e)
        {
            //connect to database
            SqlConnection conn = new SqlConnection(ShareInfo.connStr);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            //คำสั่ง SQL
            string strSql = "SELECT * FROM travel_tb " +
                "WHERE travelId = @travelId";

            //สร้าง Sql Transaction และ Command
            SqlTransaction sqlTransaction = conn.BeginTransaction();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = strSql;
            sqlCommand.Transaction = sqlTransaction;

            //bind parameter
            sqlCommand.Parameters.AddWithValue("@travelId", travelId);

            //สั่งให้ SQL ทำงาน
            SqlDataAdapter adaptor = new SqlDataAdapter(sqlCommand);
            conn.Close();

            DataTable dt = new DataTable();
            adaptor.Fill(dt);

            //เอาข้อมูลใน DataTable ไปแสดงใน form
            tbTravelPlace.Text = dt.Rows[0]["travelPlace"].ToString().Trim();
            tbTravelCostTotal.Text = dt.Rows[0]["travelCostTotal"].ToString();
            dtpTravelStartDate.Value = (DateTime)dt.Rows[0]["travelStartDate"];
            dtpTravelEndDate.Value = Convert.ToDateTime(dt.Rows[0]["travelEndDate"]);
            pbTravelImage.Image = Image.FromStream(new MemoryStream((byte[])dt.Rows[0]["travelImage"]));
            travelImage = (byte[])dt.Rows[0]["travelImage"];

        }

        private void tsbtSave_Click(object sender, EventArgs e)
        {
            //validate UI
            if (tbTravelPlace.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณาป้อนชื่อสถานที่ท่องเที่ยว");
            }
            else if (tbTravelCostTotal.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณาป้อนค่าใช้จ่าย");
            }
            else if (travelImage == null)
            {
                ShareInfo.showWarningMSG("กรุณาเลือกรูปภาพ");
            }
            else if (dtpTravelEndDate.Value.Date < dtpTravelStartDate.Value.Date)
            {
                ShareInfo.showWarningMSG("วันที่กลับต้องไม่น้อยกว่าวันที่ออกเดินทาง");
            }
            else
            {
                //connect to database
                SqlConnection conn = new SqlConnection(ShareInfo.connStr);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();

                string strSql = "INSERT INTO travel_tb(travelPlace, travelStartDate, travelEndDate, travelCostTotal, travelImage, travellerId) " +
                    "VALUES(@travelPlace, @travelStartDate, @travelEndDate, @travelCostTotal, @travelImage, @travellerId)";

                //สร้าง Sql Transaction และ Command
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = strSql;
                sqlCommand.Transaction = sqlTransaction;

                //bind parameter
                sqlCommand.Parameters.AddWithValue("@travelPlace", tbTravelPlace.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@travelStartDate", dtpTravelStartDate.Value.Date);
                sqlCommand.Parameters.AddWithValue("@travelEndDate", dtpTravelEndDate.Value.Date);
                sqlCommand.Parameters.AddWithValue("@travelCostTotal", float.Parse(tbTravelCostTotal.Text.Trim()));
                sqlCommand.Parameters.AddWithValue("@travelImage", travelImage);
                sqlCommand.Parameters.AddWithValue("@travellerId", ShareInfo.travellerId);

                try
                {

                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    conn.Close();

                    MessageBox.Show("บันทึกข้อมูลการเดินทางสำเร็จ", "ผลการทำงาน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dispose();

                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conn.Close();

                    ShareInfo.showWarningMSG("เกิดข้อผิดพลาดในการบันทึกข้อมูล Error: " + ex.Message);
                }

            }
        }
    }
}
