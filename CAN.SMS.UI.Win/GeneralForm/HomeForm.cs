using CAN.SMS.Common.Enums;
using CAN.SMS.UI.Win.Forms.SchoolForms;
using CAN.SMS.UI.Win.Show;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace CAN.SMS.UI.Win.GeneralForm
{
    public partial class HomeForm : RibbonForm
    {
        public HomeForm()
        {
            InitializeComponent();
            EventsLoad();
        }

        private void EventsLoad()
        {
            foreach (var item in ribbonControl.Items)
                switch (item)
                {
                    case BarButtonItem btn:
                        btn.ItemClick += buttons_ItemClick;
                        break;
                }
        }

        private void buttons_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == btnSchoolCards)
                ShowListForms<SchoolListForm>.ShowListForm(CardType.School);
        }
    }
}