using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;

namespace CAN.SMS.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyPhoneNumberTextEdit : MyTextEdit
    {
        public MyPhoneNumberTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.Mask.MaskType = MaskType.Regular;
            Properties.Mask.EditMask = @"(\d?\d?\d?) \d?\d?\d? \d?\d? \d?\d? \d?\d?";
            Properties.Mask.AutoComplete = AutoCompleteType.None;
            statusBarDescription = "Enter Phone Number";
        }
    }
}