using System;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace CAN.SMS.UI.Win.Forms.BaseForms
{
    public partial class BaseCardsForm : RibbonForm
    {
        public BaseCardsForm()
        {
            InitializeComponent();
        }

        private void EventsLoad()
        {
            foreach (var item in ribbonControl.Items)
            {
                switch (item)
                {
                    case BarItem button:
                        button.ItemClick += Button_ItemClick;
                        break;
                }
            }
        }

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}