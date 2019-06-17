using CAN.SMS.Bll.General;
using CAN.SMS.Common.Enums;
using CAN.SMS.UI.Win.Forms.BaseForms;
using CAN.SMS.UI.Win.Show;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;

namespace CAN.SMS.UI.Win.Forms.FilterForms
{
    public partial class FilterListForm : BaseListForm
    {
        #region Variables

        private readonly GridControl _filterGrid;
        private readonly CardType _filterCardType;

        #endregion

        public FilterListForm(params object[] prm)
        {
            InitializeComponent();
            bll = new FilterBll();

            _filterCardType = (CardType)prm[0];
            _filterGrid = (GridControl)prm[1];

            HideItems = new BarItem[] { btnFilter, btnColumns, btnPrint, btnSender, barFilter, barFilterDescription, barColumn, barColumnDescription, barPrint, barPrintDescription, barSender, barSenderDescription };
        }

        protected override void VariableFill()
        {
            Table = table;
            cardType = CardType.Filter;
            navigator = longNavigator.Navigator;
        }

        protected override void Lists()
        {
            Table.GridControl.DataSource = ((FilterBll)bll).List(x => x.CardType == _filterCardType);
        }

        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<FilterEditForm>.ShowDialogEditForm(CardType.Filter, id, _filterCardType, _filterGrid);
            ShowEditFormDefault(result);
        }
    }
}