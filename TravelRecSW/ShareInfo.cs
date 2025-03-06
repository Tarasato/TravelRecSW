using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelRecSW
{
    internal class ShareInfo
    {
        public static void showWarningMSG(string msg)
        {
            MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //connection string
        public static string conStr = "Server=Tarasato_L5\\SQLEXPRESS;Database=travel_db;Trusted_connection=True";

        //-------------------traveller Info----------------------
        public static int travellerId;
        public static string travellerFullname;
        public static string travellerEmail;
        public static string travellerPassword;
        public static byte[] travellerImage;
    }
}
