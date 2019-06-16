using CAN.SMS.Bll.Interfaces;
using CAN.SMS.Common.Enums;
using CAN.SMS.Model.Entities.Base;
using CAN.SMS.UI.Win.Functions;
using CAN.SMS.UI.Win.Show.Interfaces;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Windows.Forms;

namespace CAN.SMS.UI.Win.Forms.BaseForms
{
    public partial class BaseListForm : RibbonForm
    {
        #region Protected

        private bool _formViewSave;
        private bool _tableViewSave;
        protected IBaseFormShow FormShow;
        protected CardType cardType;
        protected internal GridView Table;
        protected bool activeCardShow = true;
        protected internal bool activePasiveButtonShow = false;
        protected internal bool multiSelect;
        protected internal BaseEntity selectedEntity;
        protected IBaseBll bll;
        protected ControlNavigator navigator;
        protected internal long? selectedId;
        protected BarItem[] ShowItems;
        protected BarItem[] HideItems;

        #endregion

        public BaseListForm()
        {
            InitializeComponent();
        }

        private void EventsLoad()
        {
            // Button Events
            foreach (BarItem button in ribbonControl.Items)
                button.ItemClick += Button_ItemClick;

            // Table Events
            Table.DoubleClick += Table_DoubleClick;
            Table.KeyDown += Table_KeyDown;
            Table.MouseUp += Table_MouseUp;
            Table.ColumnWidthChanged += Table_ColumnWidthChanged;
            Table.ColumnPositionChanged += Table_ColumnPositionChanged;
            Table.EndSorting += Table_EndSorting;

            // Form Events
            Shown += BaseListForm_Show;
            Load += BaseListForm_Load;
            FormClosing += BaseListForm_FormClosing;
            LocationChanged += BaseListForm_LocationChanged;
            SizeChanged += BaseListForm_SizeChanged;
        }

        private void BaseListForm_SizeChanged(object sender, EventArgs e)
        {
            if (!IsMdiChild)
                _formViewSave = true;
        }

        private void BaseListForm_LocationChanged(object sender, EventArgs e)
        {
            if (!IsMdiChild)
                _formViewSave = true;
        }

        private void Table_EndSorting(object sender, EventArgs e)
        {
            _tableViewSave = true;
        }

        private void Table_ColumnPositionChanged(object sender, EventArgs e)
        {
            _tableViewSave = true;
        }

        private void Table_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            _tableViewSave = true;
        }

        private void BaseListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewSave();
        }

        private void BaseListForm_Load(object sender, EventArgs e)
        {
            ViewLoading();
        }

        private void Table_MouseUp(object sender, MouseEventArgs e)
        {
            e.RightClickShow(rightClickMenu);
        }

        private void BaseListForm_Show(object sender, EventArgs e)
        {
            Table.Focus();
            ButtonHideOrShow();
            //ColoumnHideOrShow();

            if (IsMdiChild || !selectedId.HasValue) return; // selectedId == null ) return;
            Table.RowFocus("Id", selectedId);
        }

        private void ButtonHideOrShow()
        {
            btnSelect.Visibility = activePasiveButtonShow ? BarItemVisibility.Never :
                IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;
            barEnter.Visibility = IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;
            barEnterDescription.Visibility = IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;
            btnActivePasiveCards.Visibility = activeCardShow ? BarItemVisibility.Always :
                IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;

            ShowItems?.ForEach(x => x.Visibility = BarItemVisibility.Always);
            HideItems?.ForEach(x => x.Visibility = BarItemVisibility.Never);
        }

        protected internal void Loading()
        {
            VariableFill();
            EventsLoad();

            Table.OptionsSelection.MultiSelect = multiSelect;
            navigator.NavigatableControl = Table.GridControl;

            Cursor.Current = Cursors.WaitCursor;
            Lists();
            Cursor.Current = DefaultCursor;

            // Updated
        }

        #region Function

        protected virtual void ShowEditForm(long id)
        {
            var result = FormShow.ShowDialogEditForm(cardType, id);
            ShowEditFormDefault(result);
        }

        protected void ShowEditFormDefault(long id)
        {
            if (id <= 0) return;
            activeCardShow = true;
            FormCaptionSetting();
            Table.RowFocus("Id", id);
        }

        private void ViewSave()
        {
            if (_formViewSave)
                Name.FormLocationSave(Left, Top, Width, Height, WindowState);

            if (_tableViewSave)
                Table.TableViewSave(IsMdiChild ? Name + " table" : Name + " TableMDI");
        }

        private void ViewLoading()
        {
            if (IsMdiChild)
                Table.TableViewLoading(Name + " Table");

            else
            {
                Name.FormViewLoading(this);
                Table.TableViewLoading(Name + " TableMdi");
            }
        }

        protected virtual void EntityDelete()
        {
            var entity = Table.GetRow<BaseEntity>();
            if (entity == null) return;
            if (!((IBaseCommonBll)bll).Delete(entity)) return;

            Table.DeleteSelectedRows();
            Table.RowFocus(Table.FocusedRowHandle);
        }

        private void SelectEntity()
        {
            if (multiSelect)
            {
                // Update
            }
            else
            {
                selectedEntity = Table.GetRow<BaseEntity>();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        protected virtual void RefreshEntity()
        {
        }

        private void FilterEntity()
        {
        }

        private void Print()
        {
        }

        private void FormCaptionSetting()
        {
            if (btnActivePasiveCards == null)
            {
                Lists();
                return;
            }

            if (activeCardShow)
            {
                btnActivePasiveCards.Caption = "Pasive Cards";
                Table.ViewCaption = Text;
            }
            else
            {
                btnActivePasiveCards.Caption = "Active Cards";
                Table.ViewCaption = Text + " - Pasive Cards";
            }

            Lists();
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
        }

        protected virtual void Lists()
        {
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
                ShowEditForm(Table.GetRowId());
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
                Lists();
            }
            else if (e.Item == btnFilter)
            {
                FilterEntity();
            }
            else if (e.Item == btnColumns)
            {
                if (Table.CustomizationForm == null)
                    Table.ShowCustomization();
                else
                    Table.HideCustomization();
            }
            else if (e.Item == btnRelatedCards)
            {
                OpenRelatedCards();
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

        protected virtual void OpenRelatedCards()
        {

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