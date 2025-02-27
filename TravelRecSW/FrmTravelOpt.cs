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

        private void getTravelFromDVToDGV() {

            //connect to database
            SqlConnection conn = new SqlConnection(ShareInfo.connStr);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            //คำสั่ง SQL
            string strSql = "SELECT travelPlace, travelCostTotal, travelImage, travelId FROM travel_tb " +
                "WHERE travellerId = @travellerId";

            //สร้าง Sql Transaction และ Command
            SqlTransaction sqlTransaction = conn.BeginTransaction();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = conn;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = strSql;
            sqlCommand.Transaction = sqlTransaction;

            //bind parameter
            sqlCommand.Parameters.AddWithValue("@travellerId", ShareInfo.travellerId);

            //สั่งให้ SQL ทำงาน
            SqlDataAdapter adaptor = new SqlDataAdapter(sqlCommand);
            conn.Close();

            DataTable dt = new DataTable();
            adaptor.Fill(dt);

            //เอาข้อมูลใน DataTable ไปแสดงใน DataGridView
            if (dt.Rows.Count > 0)
            {
                //กำหนดความสูงของแถว
                dgvTravel.RowTemplate.Height = 100;
                //กรณีมีข้อมูล
                dgvTravel.DataSource = dt;
                //กำหนดขนาด Column
                dgvTravel.Columns[0].Width = 150;
                dgvTravel.Columns[1].Width = 115;
                dgvTravel.Columns[2].Width = 205;
                //กำหนดหัว Column
                dgvTravel.Columns[0].HeaderText = "สถานที่ที่ไป";
                dgvTravel.Columns[1].HeaderText = "ค่าใช้จ่าย";
                dgvTravel.Columns[2].HeaderText = "รูปสถานที่ที่ไป";
                dgvTravel.Columns[3].Visible = false;
                //ปรับรูปให้พอดีกับความสูง
                DataGridViewImageColumn imCol = (DataGridViewImageColumn)dgvTravel.Columns[2];
                imCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }
            else {
                //กรณีไม่มีข้อมูลให้แสดงแค่หัว Column
            }

        }

        private void FrmTravelOpt_Load(object sender, EventArgs e)
        {
            //เอารูปมาแสดง
            using (MemoryStream ms = new MemoryStream(ShareInfo.travellerImage))
            {
                pbTravellerImage.Image = Image.FromStream(ms);
            }
            //เอาชื่อมาแสดง
            lbTravellerFullname.Text = ShareInfo.travellerFullname;

            getTravelFromDVToDGV();
        }

        private void tsbtToFrmLogin_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("คุณต้องการออกจากระบบใช่หรือไม่", "ยืนยันการออกจากระบบ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
            ShareInfo.travellerId = 0;
            ShareInfo.travellerFullname = "";
            ShareInfo.travellerEmail = "";
            ShareInfo.travellerPassword = "";
            ShareInfo.travellerImage = null;

            //FrmLogin frmLogin = new FrmLogin();
            //frmLogin.Show();
            new FrmLogin().Show();
            this.Hide();
        }

        private void tsbtAdd_Click(object sender, EventArgs e)
        {
            FrmTravelAdd frmTravelAdd = new FrmTravelAdd();
            frmTravelAdd.ShowDialog(this);
            getTravelFromDVToDGV();
        }

        private void tsbtEdit_Click(object sender, EventArgs e)
        {
            //เช็คว่ามีการเลือกแถวไหนหรือไม่
            if (dgvTravel.SelectedRows.Count <= 0)
            {
                ShareInfo.showWarningMSG("กรุณาเลือกรายการที่ต้องการแก้ไข");
                return;
            }
            else
            {
                //สร้างตัวแปรเก็บ travelId ที่เลือก
                DataGridViewRow indexRow = dgvTravel.SelectedRows[0];
                int travelId = (int)indexRow.Cells[3].Value;
                //เปิดหน้า FrmTravelEdit และส่ง travelId ไปด้วย
                FrmTravelEdit frmTravelEdit = new FrmTravelEdit(travelId);
                frmTravelEdit.ShowDialog(this);
                getTravelFromDVToDGV();
            }
        }
    }
}
