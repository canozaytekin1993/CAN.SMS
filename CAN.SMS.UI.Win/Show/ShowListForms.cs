using System;
using System.Windows.Forms;
using CAN.SMS.Common.Enums;
using CAN.SMS.Model.Entities.Base;
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

            frm.Loading();
            frm.Show();
        }

        public static void ShowListForm(CardType cardType, params object[] prm)
        {
            // Authorization Control

            var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm);
            frm.MdiParent = Form.ActiveForm;

            frm.Loading();
            frm.Show();
        }

        public static BaseEntity ShowDialogListForm(CardType cardType, long? selectedId, params object[] prm)
        {
            // Authorization Control

            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.selectedId = selectedId;
                frm.Loading();
                frm.ShowDialog();

                return frm.DialogResult == DialogResult.OK ? frm.selectedEntity : null;
            }
        }
    }
}