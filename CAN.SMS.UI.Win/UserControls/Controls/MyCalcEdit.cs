using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System.Drawing;
using CAN.SMS.UI.Win.Interfaces;

namespace CAN.SMS.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyCalcEdit : CalcEdit, IStatusBarShortCut
    {
        public MyCalcEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DefaultBoolean.False;
            Properties.EditMask = "n2";
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string statusBarDescription { get; set; }
        public string statusBarShortCut { get; set; } = "F4 :";
        public string statusBarShortCutDescription { get; set; } = "Calculator";
    }
}