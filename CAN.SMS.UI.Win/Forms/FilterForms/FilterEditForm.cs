using CAN.SMS.Bll.General;
using CAN.SMS.Common.Enums;
using CAN.SMS.Model.Entities;
using CAN.SMS.UI.Win.Forms.BaseForms;
using CAN.SMS.UI.Win.Functions;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;

namespace CAN.SMS.UI.Win.Forms.FilterForms
{
    public partial class FilterEditForm : BaseEditForm
    {
        #region Variables

        private readonly CardType _filterCardType;
        private readonly GridControl _filterGrid;

        #endregion

        public FilterEditForm(params object[] prm)
        {
            InitializeComponent();

            _filterCardType = (CardType)prm[0];
            _filterGrid = (GridControl)prm[1];

            HideItem = new BarItem[] { btnNew, btnBack };
            ShowItem = new BarItem[] { btnApply, btnSaveAs };

            dataLayoutControl = myDataLayoutControl;
            bll = new FilterBll(myDataLayoutControl);
            cardType = CardType.Filter;
            EventsLoad();
        }

        protected internal override void Loading()
        {
            txtFilterText.SourceControl = _filterGrid;

            while (true)
            {
                if (processType == ProcessType.EntityInsert)
                {
                    oldEntity = new Filter();
                    Id = processType.CreateId(oldEntity);
                    txtCode.Text = ((FilterBll)bll).NewCodeCreate(x => x.CardType == _filterCardType);
                }
                else
                {
                    oldEntity = ((FilterBll)bll).Single(FilterFunctions.Filter<Filter>(Id));
                    if (oldEntity == null)
                    {
                        processType = ProcessType.EntityInsert;
                        continue;
                    }

                    ControlObjectConnection();
                }

                break;
            }
        }

        protected override void ControlObjectConnection()
        {
            var entity = (Filter)oldEntity;

            txtCode.Text = entity.Code;
            txtFilterName.Text = entity.FilterName;
            txtFilterText.FilterString = entity.FilterText;
        }

        protected override void CreateObject()
        {
            currentEntity = new Filter
            {
                Id = Id,
                Code = txtCode.Text,
                FilterName = txtFilterName.Text,
                FilterText = txtFilterText.FilterString,
                CardType = _filterCardType
            };

            ButtonEnableStatus();
        }

        protected override bool EntityInsert()
        {
            return ((FilterBll)bll).Insert(currentEntity, x => x.Code == currentEntity.Code && x.CardType == _filterCardType);
        }

        protected override bool EntityUpdate()
        {
            return ((FilterBll)bll).Update(oldEntity, currentEntity, x => x.Code == currentEntity.Code && x.CardType == _filterCardType);
        }

        protected override void ApplyFilter()
        {
            txtFilterText.Select();
            txtFilterText.ApplyFilter();
        }

        protected override void ButtonEnableStatus()
        {
            if (!IsLoaded) return;
            GeneralFunctions.ButtonEnabledStatus(btnSave, btnSaveAs, btnDelete, processType, oldEntity, currentEntity);
        }
    }
}