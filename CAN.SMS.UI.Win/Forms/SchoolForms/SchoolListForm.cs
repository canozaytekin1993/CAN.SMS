using CAN.SMS.Bll.General;
using CAN.SMS.Common.Enums;
using CAN.SMS.Model.Entities;
using CAN.SMS.UI.Win.Forms.BaseForms;
using CAN.SMS.UI.Win.Functions;
using CAN.SMS.UI.Win.Show;

namespace CAN.SMS.UI.Win.Forms.SchoolForms
{
    public partial class SchoolListForm : BaseListForm
    {
        public SchoolListForm()
        {
            InitializeComponent();
            bll = new SchoolBll();
        }

        protected override void VariableFill()
        {
            Table = table;
            cardType = CardType.School;
            FormShow = new ShowEditForms<SchoolEditForm>();
            navigator = longNavigator.Navigator;
        }

        protected override void Lists()
        {
            table.GridControl.DataSource = ((SchoolBll) bll).List(FilterFunctions.Filter<School>(activeCardShow));
        }
    }
}