using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;

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