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
            //validate UI
            if (tbTravellerEmail.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณากรอกอีเมล");
            }
            else if (tbTravellerPassword.Text.Trim().Length == 0)
            {
                ShareInfo.showWarningMSG("กรุณากรอกรหัสผ่าน");
            }
            else
            {
                //Save to DB
                //Connect to DB
                SqlConnection conn = new SqlConnection(ShareInfo.conStr);
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                //===============================================================
                //SQL command
                string strSql = "SELECT * FROM traveller_tb WHERE " +
                                "travellerEmail = @travellerEmail and " +
                                "travellerPassword = @travellerPassword";
                //===============================================================
                //Create sql transaction and sql command for working with SQL
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = strSql;
                sqlCommand.Transaction = sqlTransaction;
                //===============================================================
                //BindParam
                sqlCommand.Parameters.AddWithValue("@travellerEmail", tbTravellerEmail.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@travellerPassword", tbTravellerPassword.Text.Trim());
                //===============================================================
                //Run SQL
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                conn.Close();

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                //===============================================================
                if (dt.Rows.Count > 0)
                {
                    //packing data to shareInfo
                    ShareInfo.travellerId = (int)dt.Rows[0]["travellerId"];
                    ShareInfo.travellerFullname = dt.Rows[0]["travellerFullname"].ToString();
                    ShareInfo.travellerEmail = dt.Rows[0]["travellerEmail"].ToString();
                    ShareInfo.travellerPassword = dt.Rows[0]["travellerPassword"].ToString();
                    ShareInfo.travellerImage = (byte[])dt.Rows[0]["travellerImage"];

                    //incase login success
                    FrmTravelOpt frmMain = new FrmTravelOpt();
                    frmMain.Show();
                    Hide();
                }
                else
                {
                    //incase login fail
                    //sqlTransaction.Rollback();

                    ShareInfo.showWarningMSG("อีเมลหรือรหัสผ่านไม่ถูกต้อง");
                }


            }
        }
    }
}