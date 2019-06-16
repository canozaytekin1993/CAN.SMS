using CAN.SMS.Bll.General;
using CAN.SMS.Common.Enums;
using CAN.SMS.Model.Entities;
using CAN.SMS.UI.Win.Forms.BaseForms;
using CAN.SMS.UI.Win.Forms.CountyForms;
using CAN.SMS.UI.Win.Functions;
using CAN.SMS.UI.Win.Show;
using DevExpress.XtraBars;

namespace CAN.SMS.UI.Win.Forms.CountryForms
{
    public partial class CountryListForm : BaseListForm
    {
        public CountryListForm()
        {
            InitializeComponent();
            bll = new CountryBll();
            btnRelatedCards.Caption = "County Cards";
        }

        protected override void VariableFill()
        {
            Table = table;
            cardType = CardType.Country;
            FormShow = new ShowEditForms<CountryEditForm>();
            navigator = longNavigator.Navigator;

            if (IsMdiChild)
                ShowItems = new BarItem[] { btnRelatedCards };
        }

        protected override void Lists()
        {
            table.GridControl.DataSource = ((CountryBll)bll).List(FilterFunctions.Filter<Country>(activeCardShow));
        }

        protected override void OpenRelatedCards()
        {
            var entity = Table.GetRow<Country>();
            if (entity == null) return;
            ShowListForms<CountyListForm>.ShowListForm(CardType.County, entity.Id, entity.CountryName);
        }
    }
}