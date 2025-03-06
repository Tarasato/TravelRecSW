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
    public partial class FrmTravelOpt : Form
    {
    
        public FrmTravelOpt()
        {
            InitializeComponent();
        }
        //Method ดึงข้อมูลการเดินทางจากDBมาแสดงในDGV
        private void getTravelFromDBToDGV()
        {
            //Connect to DB
            SqlConnection conn = new SqlConnection(ShareInfo.conStr);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            //===============================================================
            //SQL Command

            string strSql = "SELECT travelPlace, travelCostTotal, travelImage, travelId FROM travel_tb " +
                            "WHERE travellerId = @travellerId ";

            //================================================================

            //Create SQL command and SQL transaction for working with SQL
            SqlTransaction sqlTransaction = conn.BeginTransaction();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = strSql;
            sqlCommand.Transaction = sqlTransaction;

            //================================================================

            //-BindParam-
            sqlCommand.Parameters.AddWithValue("@travellerId", ShareInfo.travellerId);

            //================================================================

            //Run SQL
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            conn.Close();

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            //================================================================
            //Get data in DataTable and display in DGV
            if (dt.Rows.Count > 0)
            {
                //ความสูงของแต่ละแถว DGV
                dgvTravel.RowTemplate.Height = 100;


                //incase have data===
                dgvTravel.DataSource = dt;

                
                //กำหนดหัวcolumn DGV
                dgvTravel.Columns[0].HeaderText = "สถานที่ไป";
                dgvTravel.Columns[1].HeaderText = "ค่าใช้จ่าย";
                dgvTravel.Columns[2].HeaderText = "รูปสถานที่ไป";

                //ความกว้าง DGV
                dgvTravel.Columns[0].Width = 150;
                dgvTravel.Columns[1].Width = 115;
                dgvTravel.Columns[2].Width = 200;
                dgvTravel.Columns[3].Width = 0;

                //ปรับรูปให้พอดีกับความสูง
                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dgvTravel.Columns[2];
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;


            }
            else
            {
                //incase no data
                ShareInfo.showWarningMSG("ไม่พบข้อมูลการเดินทาง");
            }
        }
        private void FrmTravelOpt_Load(object sender, EventArgs e)
        {
            //Show travellerImage
            using (MemoryStream ms = new MemoryStream(ShareInfo.travellerImage))
            {
                pbTravellerImage.Image = Image.FromStream(ms);
            }
            //Show travellerFullname
            lbTravellerFullname.Text = ShareInfo.travellerFullname;
            //ดึงจ้อมูลการเดินทางของ traveller คนที่ login เข้ามาแสดงผล
            getTravelFromDBToDGV();

        }
        //btLogout=============================================
        private void tsbtToFrmLogin_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("ต้องการยกเลิกใช่มั้ย", "ยืนยัน",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();              //กรณีที่ frmLogin ใช้บ่อยๆหลายที่
                //new FrmLogin().Show();      //ใช้ไม่เยอะ
                this.Hide();
            }
        }
        //btTravelAdd=============================================
        private void tsbtAdd_Click(object sender, EventArgs e)
        {
            //DialogOpen
            FrmTravelAdd frmTravelAdd = new FrmTravelAdd();
            frmTravelAdd.ShowDialog(this);
            getTravelFromDBToDGV();

        }
        //btTravelEdit=============================================
        private void tsbtEdit_Click(object sender, EventArgs e)
        {
            //Validate user has selected row in DGV
            if (dgvTravel.SelectedRows.Count == 0)
            {
                ShareInfo.showWarningMSG("เลือกรายการที่ต้องการแก้ไข");
            }
            else
            {
                //Create Variable to store row index
                int indexRow = dgvTravel.CurrentRow.Index;

                //Create Variable to store travelId
                int travelId = int.Parse( dgvTravel.Rows[indexRow].Cells[3].Value.ToString() );

                //DialogOpen FrmTravelEdit and sent travelId to travelEdit
                FrmTravelEdit frmTravelEdit = new FrmTravelEdit(travelId);
                frmTravelEdit.ShowDialog(this);
                getTravelFromDBToDGV();
            }
        }
        //btDelete
        private void tsbtDelete_Click(object sender, EventArgs e)
        {
            if (dgvTravel.SelectedRows.Count == 0)
            {
                ShareInfo.showWarningMSG("เลือกรายการที่ต้องการลบ");
            }
            else
            {
                //MSG DIsplay
                DialogResult dialogResult = MessageBox.Show("ต้องการลบใช่หรือไม่", "ยืนยัน",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (dgvTravel.SelectedRows.Count == 0)
                    {
                        ShareInfo.showWarningMSG("เลือกรายการที่ต้องการแก้ไข");
                    }
                    else
                    {
                        //Create Variable to store row index
                        int indexRow = dgvTravel.CurrentRow.Index;
                        //Create Variable to store travelId
                        int travelId = int.Parse(dgvTravel.Rows[indexRow].Cells[3].Value.ToString());
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
                        string strSql = "DELETE FROM travel_tb WHERE travelId = @travelId";
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
                        try
                        {
                            sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();
                            conn.Close();
                            getTravelFromDBToDGV();
                            ShareInfo.showWarningMSG("ลบข้อมูลสำเร็จ");
                        }
                        catch (Exception ex)
                        {
                            ShareInfo.showWarningMSG("ไม่สามารถลบข้อมูลได้");
                            sqlCommand.Transaction.Rollback();
                            conn.Close();
                        }

                    }
                }
            }
        }
    }
}
