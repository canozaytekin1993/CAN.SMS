﻿using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CAN.SMS.Common.Messages
{
    public class Messages
    {
        public static void ErrorMessage(string errorMessage)
        {
            XtraMessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void WarningMessage(string errorMessage)
        {
            XtraMessageBox.Show(errorMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult TrueSelectYesNo(string message, string title)
        {
            return XtraMessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
        }

        public static DialogResult NoSelectYesNo(string message, string title)
        {
            return XtraMessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
        }

        public static DialogResult DeleteMessage(string CardName)
        {
            return NoSelectYesNo($"{CardName} deleted. Do you confirm ?", "Delete confirmation");
        }

        public static void CardNotChooseWarningMessage()
        {
            WarningMessage("Please select a card.");
        }
    }
}