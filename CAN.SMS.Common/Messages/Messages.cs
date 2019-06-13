using DevExpress.XtraEditors;
using System.Windows.Form;

namespace CAN.SMS.Common.Messages
{
    public class Messages
    {
        public static void ErrorMessage(string errorMessage)
        {
            XtraMessageBox.Show(errorMessage,"Error",new System.Windows.Forms.MessageBoxButtons());
        }
    }
}