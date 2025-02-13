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
        public static void showWarningMSG(string msg) { 
            MessageBox.Show(msg,"คำเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
