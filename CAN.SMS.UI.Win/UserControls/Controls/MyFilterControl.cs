using System.ComponentModel;
using CAN.SMS.UI.Win.Interfaces;
using DevExpress.XtraEditors;

namespace CAN.SMS.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyFilterControl : FilterControl, IStatusBarDescription
    {
        public MyFilterControl()
        {
            ShowGroupCommandsIcon = true;
        }

        public string statusBarDescription { get; set; } = "Enter filter text";
    }
}