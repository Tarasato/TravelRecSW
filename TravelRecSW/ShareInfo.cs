using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelRecSW
{
    internal class ShareInfo
    {
        public static void showWarningMSG(string msg) { 
            MessageBox.Show(msg,"คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static string connStr = "Data Source=Tarasato_L5\\SQLEXPRESS;Database=travel_DB;Trusted_connection=True";

        public static int travellerId;
        public static string travellerFullname;
        public static string travellerEmail;
        public static string travellerPassword;
        public static byte[] travelImage;
    }
}
