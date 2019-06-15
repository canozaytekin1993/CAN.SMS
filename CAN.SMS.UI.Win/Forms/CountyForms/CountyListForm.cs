using CAN.SMS.Bll.General;
using CAN.SMS.Common.Enums;
using CAN.SMS.UI.Win.Forms.BaseForms;
using CAN.SMS.UI.Win.Show;

namespace CAN.SMS.UI.Win.Forms.CountyForms
{
    public partial class CountyListForm : BaseListForm
    {
        #region Variables

        private readonly long _countryId;
        private readonly string _countryName;

        #endregion

        public CountyListForm(params object[] prm)
        {
            InitializeComponent();
            bll = new CountyBll();

            _countryId = (long)prm[0];
            _countryName = prm[1].ToString();
        }

        protected override void VariableFill()
        {
            Table = table;
            cardType = CardType.County;
            navigator = longNavigator.Navigator;
        }

        protected override void Lists()
        {
            Table.GridControl.DataSource =
                ((CountyBll)bll).List(x => x.Statu == activeCardShow && x.CountryId == _countryId);
        }

        protected override void ShowEditForm(long id)
        {
            var result = new ShowEditForms<CountyEditForm>().ShowDialogEditForm(CardType.County, id, _countryId, _countryName);
            // process
        }
    }
}