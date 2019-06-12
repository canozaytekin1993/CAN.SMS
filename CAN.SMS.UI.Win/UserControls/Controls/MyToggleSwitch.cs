using System.ComponentModel;
using System.Drawing;
using CAN.SMS.UI.Win.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace CAN.SMS.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyToggleSwitch : ToggleSwitch, IStatusBarDescription
    {
        public MyToggleSwitch()
        {
            Name = "tglStatu";
            Properties.OffText = "Pasive";
            Properties.OnText = "Active";
            Properties.AutoHeight = false;
            Properties.AutoWidth = false;
            Properties.GlyphAlignment = HorzAlignment.Far;
            Properties.Appearance.ForeColor = Color.Maroon;
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string statusBarDescription { get; set; } = "Select the usage status of the card";
    }
}