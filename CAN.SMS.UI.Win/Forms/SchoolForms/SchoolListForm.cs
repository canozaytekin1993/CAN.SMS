using CAN.SMS.Bll.General;
using CAN.SMS.UI.Win.Forms.BaseForms;

namespace CAN.SMS.UI.Win.Forms.SchoolForms
{
    public partial class SchoolListForm : BaseListForm
    {
        public SchoolListForm()
        {
            InitializeComponent();
            SchoolBll bll = new SchoolBll();
            grid.DataSource = (bll.List(null));
        }
    }
}