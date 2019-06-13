using CAN.SMS.Bll.General;
using CAN.SMS.UI.Win.Forms.BaseForms;

namespace CAN.SMS.UI.Win.Forms.SchoolForms
{
    public partial class SchoolCards : BaseCardsForm
    {
        public SchoolCards()
        {
            InitializeComponent();
            SchoolBll bll = new SchoolBll();
            grid.DataSource = (bll.List(null));
        }
    }
}