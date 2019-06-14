using System;
using System.Windows.Forms;
using CAN.SMS.Common.Enums;
using CAN.SMS.UI.Win.Forms.BaseForms;

namespace CAN.SMS.UI.Win.Show
{
    public class ShowListForms<TForm> where TForm : BaseListForm
    {
        public static void ShowListForm(CardType cardType)
        {
            // Authorization Control

            var frm = (TForm)Activator.CreateInstance(typeof(TForm));
            frm.MdiParent = Form.ActiveForm;

            frm.Load();
            frm.Show();
        }
    }
}
