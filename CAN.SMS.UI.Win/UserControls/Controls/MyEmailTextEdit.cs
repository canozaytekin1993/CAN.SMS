﻿using System.ComponentModel;
using DevExpress.XtraEditors.Mask;

namespace CAN.SMS.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyEmailTextEdit : MyTextEdit
    {
        public MyEmailTextEdit()
        {
            Properties.Mask.EditMask = MaskType.RegEx.ToString();
            Properties.Mask.EditMask =
                "((([0-9a-zA-Z_%-])+[.])+|([0-9a-zA-Z_%-])+)+@((([0-9a-zA-Z_-])+[.])+|([0-9a-zA-Z_-])+)+";
            Properties.Mask.AutoComplete = AutoCompleteType.Strong;
            statusBarDescription = "Enter Email";
        }
    }
}