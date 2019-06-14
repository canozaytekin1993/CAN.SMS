using System;
using CAN.SMS.Common.Enums;
using CAN.SMS.UI.Win.Forms.BaseForms;
using CAN.SMS.UI.Win.Show.Interfaces;

namespace CAN.SMS.UI.Win.Show
{
    public class ShowEditForms<TForm> : IBaseFormShow where TForm : BaseEditForm // Interface
    {
        public long ShowDialogEditForm(CardType cardType, long id)
        {
            // Authorize Control

            using (var frm = (TForm) Activator.CreateInstance(typeof(TForm)))
            {
                frm.processType = id > 0 ? ProcessType.EntityUpdate : ProcessType.EntityInsert;
                frm.Id = id;
                frm.Loading();
                frm.ShowDialog();
                return frm.Refresh ? frm.Id : 0;
            }
        }
    }
}