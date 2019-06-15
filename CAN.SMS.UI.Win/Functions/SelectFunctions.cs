using CAN.SMS.Common.Enums;
using CAN.SMS.UI.Win.Forms.CountryForms;
using CAN.SMS.UI.Win.Show;
using CAN.SMS.UI.Win.UserControls.Controls;
using System;
using CAN.SMS.Model.Entities;
using CAN.SMS.UI.Win.Forms.CountyForms;

namespace CAN.SMS.UI.Win.Functions
{
    public class SelectFunctions : IDisposable
    {
        #region Variables

        private MyButtonEdit _btnEdit;
        private MyButtonEdit _prmEdit;
        private CardType _cardType; 

        #endregion

        public void Choose(MyButtonEdit btnEdit)
        {
            _btnEdit = btnEdit;
            Choosing();
        }

        public void Choose(MyButtonEdit btnEdit, MyButtonEdit prmEdit)
        {
            _btnEdit = btnEdit;
            _prmEdit = prmEdit;
            Choosing();
        }

        public void Choosing()
        {
            switch (_btnEdit.Name)
            {
                case "txtCountry":
                    {
                        var entity = (Country)ShowListForms<CountryListForm>.ShowDialogListForm(_cardType, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.CountryName;
                        }
                    }
                    break;

                case "txtCounty":
                    {
                        var entity =
                            (County)ShowListForms<CountyListForm>.ShowDialogListForm(_cardType, _btnEdit.Id, _prmEdit.Id,
                                _prmEdit.Text);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.CountyName;
                        }
                    }
                    break;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}