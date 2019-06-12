using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System.ComponentModel;

namespace CAN.SMS.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyIdentificationNumberEdit : MyTextEdit
    {
        public MyIdentificationNumberEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.Mask.MaskType = MaskType.Regular;
            Properties.Mask.EditMask = @"\d?\d?\d? \d?\d?\d? \d?\d?\d? \d?\d?";
            Properties.Mask.AutoComplete = AutoCompleteType.None;
            statusBarDescription = "Enter Identification Number";
        }
    }
}