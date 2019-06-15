using CAN.SMS.Bll.General;
using CAN.SMS.Common.Enums;
using CAN.SMS.Model.Entities;
using CAN.SMS.UI.Win.Forms.BaseForms;
using CAN.SMS.UI.Win.Functions;

namespace CAN.SMS.UI.Win.Forms.CountyForms
{
    public partial class CountyEditForm : BaseEditForm
    {
        #region Variables

        private readonly long _countryId;
        private readonly string _countryName;

        #endregion

        public CountyEditForm(params object[] prm)
        {
            InitializeComponent();

            _countryId = (long)prm[0];
            _countryName = prm[1].ToString();

            dataLayoutControl = myDataLayoutControl;
            bll = new CountyBll();
            cardType = CardType.County;
            EventsLoad();
        }

        protected internal override void Loading()
        {
            oldEntity = processType == ProcessType.EntityInsert
                ? new County()
                : ((CountyBll)bll).Single(FilterFunctions.Filter<County>(Id));
            ControlObjectConnection();
            Text = Text + $" - ({_countryName})";

            if (processType != ProcessType.EntityInsert) return;
            txtCode.Text = ((CountyBll)bll).NewCodeCreate(x => x.CountryId == _countryId);
            txtCountyName.Focus();
        }

        protected override void ControlObjectConnection()
        {
            var entity = (County)oldEntity;

            txtCode.Text = entity.Code;
            txtCountyName.Text = entity.CountyName;
            txtDescription.Text = entity.Description;
            tglStatu.IsOn = entity.Statu;
        }

        protected override void CreateObject()
        {
            currentEntity = new County
            {
                Id = Id,
                Code = txtCode.Text,
                CountyName = txtCountyName.Text,
                CountryId = _countryId,
                Description = txtDescription.Text,
                Statu = tglStatu.IsOn
            };

            ButtonEnableStatus();
        }

        protected override bool EntityInsert()
        {
            return ((CountyBll)bll).Insert(currentEntity, x => x.Code == currentEntity.Code && x.CountryId == _countryId);
        }

        protected override bool EntityUpdate()
        {
            return ((CountyBll)bll).Update(oldEntity, currentEntity, x => x.Code == currentEntity.Code && x.CountryId == _countryId);
        }
    }
}