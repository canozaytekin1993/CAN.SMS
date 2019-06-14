using CAN.SMS.Bll.Interfaces;
using CAN.SMS.Common.Enums;
using CAN.SMS.Model.Entities.Base;
using CAN.SMS.UI.Win.Functions;
using CAN.SMS.UI.Win.Show.Interfaces;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Windows.Forms;

namespace CAN.SMS.UI.Win.Forms.BaseForms
{
    public partial class BaseListForm : RibbonForm
    {
        #region Protected

        protected IBaseFormShow FormShow;

        protected CardType cardType;

        protected internal GridView table;

        protected bool activeCardShow;

        protected internal bool multiSelect;

        protected internal BaseEntity selectedEntity;

        protected IBaseBll bll;

        protected ControlNavigator navigator;

        #endregion

        public BaseListForm()
        {
            InitializeComponent();
        }

        private void EventsLoad()
        {
            // Button Events
            foreach (BarItem button in ribbonControl.Items)
            {
                button.ItemClick += Button_ItemClick;
            }

            // Table Events
            table.DoubleClick += Table_DoubleClick;
            table.KeyDown += Table_KeyDown;

            // Form Events

        }

        protected internal void Load()
        {
            VariableFill();
            EventsLoad();

            table.OptionsSelection.MultiSelect = multiSelect;
            navigator.NavigatableControl = table.GridControl;

            Cursor.Current = Cursors.WaitCursor;
            Lists();
            Cursor.Current = DefaultCursor;

            // Updated
        }

        #region Function

        private void ShowEditForm(long id)
        {
            var result = FormShow.ShowDialogEditForm(cardType, id);
        }

        private void EntityDelete()
        {
            throw new NotImplementedException();
        }

        private void SelectEntity()
        {
            if (multiSelect)
            {
                // Update
            }
            else
            {
                selectedEntity = table.GetRow<BaseEntity>();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void RefreshEntity()
        {
            throw new NotImplementedException();
        }

        private void FilterEntity()
        {
            throw new NotImplementedException();
        }

        private void Print()
        {
            throw new NotImplementedException();
        }

        private void FormCaptionSetting()
        {
            throw new NotImplementedException();
        }

        private void ProcessTypeChoose()
        {
            if (!IsMdiChild)
                // Updated
                SelectEntity();
            else
                btnEdit.PerformClick();
        }

        protected virtual void VariableFill()
        {
            throw new NotImplementedException();
        }

        protected virtual void Lists()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Events

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Item == btnSender)
            {
                var link = (BarSubItemLink)e.Item.Links[0];
                link.Focus();
                link.OpenMenu();
                link.Item.ItemLinks[0].Focus();
            }
            else if (e.Item == btnExcelFileStandart)
            {
            }
            else if (e.Item == btnExcelFileFormat)
            {
            }
            else if (e.Item == btnExcelFileUnformatted)
            {
            }
            else if (e.Item == btnWordFile)
            {
            }
            else if (e.Item == btnPdfFile)
            {
            }
            else if (e.Item == btnTextFile)
            {
            }
            else if (e.Item == btnNew)
            {
                // Authorization Control
                ShowEditForm(-1);
            }
            else if (e.Item == btnEdit)
            {
                ShowEditForm(table.GetRowId());
            }
            else if (e.Item == btnDelete)
            {
                EntityDelete();
            }
            else if (e.Item == btnSelect)
            {
                SelectEntity();
            }
            else if (e.Item == btnRefresh)
            {
                RefreshEntity();
            }
            else if (e.Item == btnFilter)
            {
                FilterEntity();
            }
            else if (e.Item == btnColumns)
            {
                if (table.CustomizationForm == null)
                {
                    table.ShowCustomization();
                }
                else
                {
                    table.HideCustomization();
                    ;
                }
            }
            else if (e.Item == btnPrint)
            {
                Print();
            }
            else if (e.Item == btnExit)
            {
                Close();
            }
            else if (e.Item == btnActivePasiveCards)
            {
                activeCardShow = !activeCardShow;
                FormCaptionSetting();
            }

            Cursor.Current = DefaultCursor;
        }

        private void Table_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ProcessTypeChoose();
            Cursor.Current = DefaultCursor;
        }

        private void Table_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ProcessTypeChoose();
                    break;

                case Keys.Escape:
                    Close();
                    break;

            }
        }

        #endregion
    }
}