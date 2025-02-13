using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelRecSW
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void lbToFrmRegister_Click(object sender, EventArgs e)
        {
            FrmRegister frmRegister = new FrmRegister();
            frmRegister.Show();
            this.Hide();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (tbTravellerEmail.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณาป้อนอีเมล์");
            }
            else if (tbTravellerPassword.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณาป้อนรหัสผ่าน");
            }else if(tbTravellerPassword.Text.Trim().Length < 6)
            {
                ShareInfo.showWarningMSG("รหัสผ่านต้องมีความยาวอย่างน้อย 6 ตัวอักษร");
            }
            else
            {
                //เอา Email และ Password ไปเช็คในฐานข้อมูล
                SqlConnection conn = new SqlConnection(ShareInfo.connStr);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();

                //คำสั่ง SQL
                string strSql = "SELECT * FROM traveller_tb WHERE " +
                                "travellerEmail = @travellerEmail and " +
                                "travellerPassword = @travellerPassword";

                //สร้าง Sql Transaction และ Command
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = strSql;
                sqlCommand.Transaction = sqlTransaction;

                //Bind param เพื่อกำหนดข้อมูลให้กับ SQL Parameter
                sqlCommand.Parameters.AddWithValue("@travellerEmail", tbTravellerEmail.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@travellerPassword", tbTravellerPassword.Text.Trim());

                //Execute SQL
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                conn.Close();

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ShareInfo.travellerId = (int) dt.Rows[0]["travellerId"];
                    ShareInfo.travellerFullname = dt.Rows[0]["travellerFullname"].ToString();
                    ShareInfo.travellerEmail = dt.Rows[0]["travellerEmail"].ToString();
                    ShareInfo.travellerPassword = dt.Rows[0]["travellerPassword"].ToString();
                    ShareInfo.travelImage = (byte[])dt.Rows[0]["travellerImage"];

                    FrmTravelOpt frmTravelOption = new FrmTravelOpt();
                    frmTravelOption.Show();
                    Hide();
                }
                else
                {
                    ShareInfo.showWarningMSG("อีเมล์หรือรหัสผ่านไม่ถูกต้อง");
                }
            }
        }
    }
}
