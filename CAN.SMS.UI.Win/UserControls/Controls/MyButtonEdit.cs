using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace CAN.SMS.UI.Win.UserControls.Controls
{
    public class MyButtonEdit : ButtonEdit
    {
        public MyButtonEdit()
        {
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string statusBarDescription { get; set; }
        public string statusBarShortCut { get; set; }
        public string statusBarShortCutDescription { get; set; }
    }
}