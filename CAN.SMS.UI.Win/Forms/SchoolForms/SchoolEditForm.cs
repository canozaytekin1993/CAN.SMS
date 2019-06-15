using System;
using CAN.SMS.Bll.General;
using CAN.SMS.Common.Enums;
using CAN.SMS.Model.Dto;
using CAN.SMS.Model.Entities;
using CAN.SMS.UI.Win.Forms.BaseForms;
using CAN.SMS.UI.Win.Functions;

namespace CAN.SMS.UI.Win.Forms.SchoolForms
{
    public partial class SchoolEditForm : BaseEditForm
    {
        public SchoolEditForm()
        {
            InitializeComponent();
            dataLayoutControl = myDataLayoutControl;
            bll = new SchoolBll(myDataLayoutControl);
            cardType = CardType.School;
            EventsLoad();
        }

        protected internal override void Loading()
        {
            oldEntity = processType == ProcessType.EntityInsert
                ? new SchoolS()
                : ((SchoolBll) bll).Single(FilterFunctions.Filter<School>(Id));
            ControlObjectConnection();

            if (processType != ProcessType.EntityInsert) return;
            {
                txtCode.Text = ((SchoolBll) bll).NewCodeCreate();
                txtSchoolName.Focus();
            }
        }

        protected override void ControlObjectConnection()
        {
            var entity = (SchoolS) oldEntity;

            txtCode.Text = entity.Code;
            txtSchoolName.Text = entity.SchoolName;
            txtCountry.Id = entity.CountryId;
            txtCountry.Text = entity.CountryName;
            txtCounty.Id = entity.CountyId;
            txtCounty.Text = entity.CountyName;
            txtDescription.Text = entity.Description;
            tglStatus.IsOn = entity.Statu;
        }

        protected override void CreateObject()
        {
            currentEntity = new School
            {
                Id = Id,
                Code = txtCode.Text,
                SchoolName = txtSchoolName.Text,
                CountryId = Convert.ToInt64(txtCountry.Id),
                CountyId = Convert.ToInt64(txtCounty.Id),
                Description = txtDescription.Text,
                Statu = tglStatus.IsOn
            };

            ButtonEnableStatus();
        }
    }
}