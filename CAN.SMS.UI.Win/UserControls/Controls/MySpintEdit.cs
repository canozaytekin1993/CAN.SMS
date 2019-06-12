using System.ComponentModel;
using System.Drawing;
using CAN.SMS.UI.Win.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace CAN.SMS.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MySpintEdit : SpinEdit,IStatusBarDescription
    {
        public MySpintEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DefaultBoolean.False;
            Properties.EditMask = "d";
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string statusBarDescription { get; set; }
    }
}