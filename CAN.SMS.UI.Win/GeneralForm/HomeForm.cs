using CAN.SMS.UI.Win.Forms.SchoolForms;
using DevExpress.XtraBars;

namespace CAN.SMS.UI.Win.GeneralForm
{
    public partial class HomeForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public HomeForm()
        {
            InitializeComponent();
            EventsLoad();
        }

        private void EventsLoad()
        {
            foreach (var item in ribbonControl.Items)
            {
                switch (item)
                {
                    case BarButtonItem btn:
                        btn.ItemClick += buttons_ItemClick;
                        break;
                }
            }
        }

        private void buttons_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == btnSchoolCards)
            {
                SchoolCards frm = new SchoolCards();
                frm.MdiParent = ActiveForm;
                frm.Show();
            }
        }
    }
}