using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System;

namespace CAN.SMS.UI.Win.Forms.BaseForms
{
    public partial class BaseListForm : RibbonForm
    {
        public BaseListForm()
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

        #region Function
        private void ShowEditForm(/*long id*/)
        {
            //var result = 
        }
        #endregion

        #region Events
        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == btnSender)
            {
                var link = (BarSubItemLink)e.Item.Links[0];
                link.Focus();
                link.OpenMenu();
                link.Item.ItemLinks[0].Focus();
            }
            else if (e.Item == btnExcelFileStandart)
            { }
            else if (e.Item == btnExcelFileFormat)
            { }
            else if (e.Item == btnExcelFileUnformatted)
            { }
            else if (e.Item == btnWordFile)
            { }
            else if (e.Item == btnPdfFile)
            { }
            else if (e.Item == btnTextFile)
            { }
            else if (e.Item == btnNew)
            {
                // Authorization Control
                ShowEditForm();
            }
        } 
        #endregion
    }
}