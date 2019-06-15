using CAN.SMS.Bll.General;
using CAN.SMS.Common.Enums;
using CAN.SMS.Model.Entities;
using CAN.SMS.UI.Win.Forms.BaseForms;
using CAN.SMS.UI.Win.Functions;
using CAN.SMS.UI.Win.Show;

namespace CAN.SMS.UI.Win.Forms.CountryForms
{
    public partial class CountryListForm : BaseListForm
    {
        public CountryListForm()
        {
            InitializeComponent();
            bll = new CountryBll();
        }

        protected override void VariableFill()
        {
            Table = table;
            cardType = CardType.Country;
            FormShow = new ShowEditForms<CountryEditForm>();
            navigator = longNavigator.Navigator;
        }

        protected override void Lists()
        {
            table.GridControl.DataSource = ((CountryBll)bll).List(FilterFunctions.Filter<Country>(activeCardShow));
        }
    }
}