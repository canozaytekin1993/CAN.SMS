﻿using System.ComponentModel;
using System.Drawing;
using CAN.SMS.UI.Win.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace CAN.SMS.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyComboBoxEdit : ComboBoxEdit, IStatusBarShortCut
    {
        public MyComboBoxEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string statusBarDescription { get; set; }
        public string statusBarShortCut { get; set; } = "F4 :";
        public string statusBarShortCutDescription { get; set; }
    }
}