using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CAN.SMS.Common.Messages
{
    public class Messages
    {
        public static void ErrorMessage(string errorMessage)
        {
            XtraMessageBox.Show(errorMessage,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}