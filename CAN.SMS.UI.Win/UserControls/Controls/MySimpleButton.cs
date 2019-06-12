using System.ComponentModel;
using System.Drawing;
using CAN.SMS.UI.Win.Interfaces;
using DevExpress.XtraEditors;

namespace CAN.SMS.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MySimpleButton : SimpleButton, IStatusBarDescription
    {
        public MySimpleButton()
        {
            Appearance.ForeColor = Color.LightCyan;
        }

        public string statusBarDescription { get; set; }
    }
}