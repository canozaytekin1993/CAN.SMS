using CAN.SMS.Bll.General;
using CAN.SMS.Common.Enums;
using CAN.SMS.Model.Entities;
using CAN.SMS.UI.Win.Forms.BaseForms;
using CAN.SMS.UI.Win.Functions;

namespace CAN.SMS.UI.Win.Forms.CountryForms
{
    public partial class CountryEditForm : BaseEditForm
    {
        public CountryEditForm()
        {
            InitializeComponent();
            dataLayoutControl = myDataLayoutControl;
            bll = new CountryBll(myDataLayoutControl);
            cardType = CardType.Country;
            EventsLoad();
        }

        protected internal override void Loading()
        {
            oldEntity = processType == ProcessType.EntityInsert
                ? new Country()
                : ((CountryBll)bll).Single(FilterFunctions.Filter<Country>(Id));
            ControlObjectConnection();

            if (processType != ProcessType.EntityInsert) return;
            txtCode.Text = ((CountryBll)bll).NewCodeCreate();
            txtCountryName.Focus();
        }

        protected override void ControlObjectConnection()
        {
            var entity = (Country)oldEntity;

            txtCode.Text = entity.Code;
            txtCountryName.Text = entity.CountryName;
            txtDescription.Text = entity.Description;
            tglStatu.IsOn = entity.Statu;
        }

        protected override void CreateObject()
        {
            currentEntity = new Country()
            {
                Id = Id,
                Code = txtCode.Text,
                CountryName = txtCountryName.Text,
                Description = txtDescription.Text,
                Statu = tglStatu.IsOn
            };

            ButtonEnableStatus();
        }
    }
}