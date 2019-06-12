using System.ComponentModel;
using System.Drawing;
using DevExpress.Utils;

namespace CAN.SMS.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyCodeTextEdit : MyTextEdit
    {
        public MyCodeTextEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.PaleGoldenrod;
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.MaxLength = 20;
            statusBarDescription = "Enter Code";
        }
    }
}