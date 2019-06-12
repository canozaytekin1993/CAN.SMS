using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors.Mask;

namespace CAN.SMS.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyIbanTextEdit : MyTextEdit
    {
        public MyIbanTextEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.AliceBlue;
            Properties.Mask.EditMask = @"UK\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?";
            Properties.Mask.AutoComplete = AutoCompleteType.None;
            statusBarDescription = "Enter Iban No";
        }
    }
}