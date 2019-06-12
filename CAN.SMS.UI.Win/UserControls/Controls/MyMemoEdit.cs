using System.ComponentModel;
using System.Drawing;
using CAN.SMS.UI.Win.Interfaces;
using DevExpress.XtraEditors;

namespace CAN.SMS.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyMemoEdit : MemoEdit , IStatusBarDescription
    {
        public MyMemoEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.MaxLength = 500;
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string statusBarDescription { get; set; } = "Enter Description";
    }
}