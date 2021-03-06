﻿using CAN.SMS.Bll.Interfaces;
using CAN.SMS.Common.Enums;
using CAN.SMS.Common.Messages;
using CAN.SMS.Model.Entities.Base;
using CAN.SMS.UI.Win.Functions;
using CAN.SMS.UI.Win.Interfaces;
using CAN.SMS.UI.Win.UserControls.Controls;
using CAN.SMS.UI.Win.UserControls.Controls.Grid;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting.Native;
using System;
using System.Windows.Forms;

namespace CAN.SMS.UI.Win.Forms.BaseForms
{
    public partial class BaseEditForm : RibbonForm
    {
        private bool _formViewSave;
        protected IBaseBll bll;
        protected CardType cardType;
        protected BaseEntity currentEntity;
        protected MyDataLayoutControl dataLayoutControl;
        protected MyDataLayoutControl[] dataLayoutControls;
        protected internal long Id;
        protected bool IsLoaded;
        protected BaseEntity oldEntity;
        protected internal ProcessType processType;
        protected internal bool Refresh;
        protected bool saveBeforeFormClose = true;
        protected BarItem[] ShowItem;
        protected BarItem[] HideItem;

        public BaseEditForm()
        {
            InitializeComponent();
        }

        #region Functions

        protected void EventsLoad()
        {
            // Buttons Events
            foreach (BarItem button in ribbonControl.Items)
                button.ItemClick += Button_ItemClick;

            // Form Events
            LocationChanged += BaseEditForm_Changed;
            SizeChanged += BaseEditForm_SizeChanged;
            Load += BaseEditForm_Load;
            FormClosing += BaseEditForm_FormClosing;

            void ControlEvents(Control control)
            {
                control.KeyDown += Control_KeyDown;
                control.GotFocus += Control_GotFocus;
                control.Leave += Control_Leave;

                switch (control)
                {
                    case FilterControl edt:
                        edt.FilterChanged += Control_EditValueChanged;
                        break;
                    case MyButtonEdit edt:
                        edt.IdChanged += Control_IdChanged;
                        edt.EnabledChange += Control_EnableChange;
                        edt.ButtonClick += Control_ButtonClick;
                        edt.DoubleClick += Control_DoubleClick;
                        break;
                    case BaseEdit edt:
                        edt.EditValueChanged += Control_EditValueChanged;
                        break;
                }
            }

            if (dataLayoutControls == null)
            {
                if (dataLayoutControl == null) return;
                foreach (Control ctrl in dataLayoutControl.Controls) ControlEvents(ctrl);
            }
            else
            {
                foreach (var layout in dataLayoutControls)
                    foreach (Control ctrl in layout.Controls)
                        ControlEvents(ctrl);
            }
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            statusShortCut.Visibility = BarItemVisibility.Never;
            statusShortCutInfo.Visibility = BarItemVisibility.Never;
        }

        private void Control_GotFocus(object sender, EventArgs e)
        {
            var type = sender.GetType();

            if (type == typeof(MyButtonEdit) || type == typeof(MyGridView) || type == typeof(MyPictureEdit) ||
                type == typeof(MyComboBoxEdit) || type == typeof(MyDateEdit))
            {
                statusShortCut.Visibility = BarItemVisibility.Always;
                statusShortCut.Visibility = BarItemVisibility.Always;

                statusBarInfo.Caption = ((IStatusBarDescription)sender).statusBarDescription;
                statusShortCut.Caption = ((IStatusBarShortCut)sender).statusBarShortCut;
                statusShortCutInfo.Caption = ((IStatusBarShortCut)sender).statusBarShortCutDescription;
            }
            else if (sender is IStatusBarDescription ctrl)
                statusBarInfo.Caption = ctrl.statusBarDescription;
        }

        private void BaseEditForm_SizeChanged(object sender, EventArgs e)
        {
            _formViewSave = true;
        }

        private void BaseEditForm_Changed(object sender, EventArgs e)
        {
            _formViewSave = true;
        }

        private void BaseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ViewSave();

            if (btnSave.Visibility == BarItemVisibility.Never || !btnSave.Enabled) return;
            if (!Save(true)) e.Cancel = true;
        }

        protected virtual void ApplyFilter() { }

        protected virtual void ViewSave()
        {
            if (_formViewSave)
                Name.FormLocationSave(Left, Top, Width, Height, WindowState);
        }

        private void ViewLoading()
        {
            Name.FormViewLoading(this);
        }

        protected virtual void Control_EnableChange(object sender, EventArgs e) { }

        private void Control_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsLoaded) return;
            CreateObject();
        }

        private void Control_DoubleClick(object sender, EventArgs e)
        {
            Choosing(sender);
        }

        private void Control_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            Choosing(sender);
        }

        private void Control_IdChanged(object sender, IdChangedEventArgs e)
        {
            if (IsLoaded) return;
            CreateObject();
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();

            if (sender is MyButtonEdit edt)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete when e.Control && e.Shift:
                        edt.Id = null;
                        edt.EditValue = null;
                        break;

                    case Keys.F4:
                    case Keys.Down when e.Modifiers == Keys.Alt:
                        Choosing(edt);
                        break;
                }
            }
        }

        private void BaseEditForm_Load(object sender, EventArgs e)
        {
            IsLoaded = true;
            CreateObject();
            ViewLoading();
            ButtonHideOrShow();

            // Update process.
        }

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (e.Item == btnNew)
            {
                // Authorization Control
                processType = ProcessType.EntityInsert;
                Loading();
            }

            else if (e.Item == btnSave)
            {
                Save(false);
            }

            else if (e.Item == btnSaveAs)
            {
                // Authorization Control
                SaveAs();
            }

            else if (e.Item == btnBack)
            {
                Back();
            }

            else if (e.Item == btnDelete)
            {
                // Authorization Control
                EntityDelete();
            }

            else if (e.Item == btnApply)
            {
                ApplyFilter();
            }

            else if (e.Item == btnExit)
            {
                Close();
            }

            Cursor.Current = DefaultCursor;
        }

        private void SaveAs()
        {
            if (Messages.YesSelectYesNo("A new filter will be created.Do you confirm?", "Do you confirm?") !=
                DialogResult.Yes)
                return;
            processType = ProcessType.EntityInsert;
            Loading();
            if (Save(true))
                Close();
        }

        protected virtual void Choosing(object sender)
        {

        }

        private void EntityDelete()
        {
            if (!((IBaseCommonBll)bll).Delete(oldEntity)) return;
            Refresh = true;
            Close();
        }

        private void Back()
        {
            if (Messages.NoSelectYesNo("Changes will be undone. Do you confirm?", "Confirmation") !=
                DialogResult.Yes) return;

            if (processType == ProcessType.EntityUpdate)
                Loading();
            else
                Close();
        }

        private bool Save(bool closing)
        {
            bool SaveProcess()
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (processType)
                {
                    case ProcessType.EntityInsert:
                        if (EntityInsert())
                            return SaveAfterProcess();
                        break;
                    case ProcessType.EntityUpdate:
                        if (EntityUpdate())
                            return SaveAfterProcess();
                        break;
                }

                bool SaveAfterProcess()
                {
                    oldEntity = currentEntity;
                    Refresh = true;
                    ButtonEnableStatus();

                    if (saveBeforeFormClose)
                        Close();
                    else
                        processType = processType == ProcessType.EntityInsert ? ProcessType.EntityUpdate : processType;

                    return true;
                }

                return false;
            }

            var result = closing ? Messages.ClosingMessage() : Messages.SaveResultMessage();

            switch (result)
            {
                case DialogResult.Yes:
                    return SaveProcess();

                case DialogResult.No:
                    if (closing)
                        btnSave.Enabled = false;
                    return true;

                case DialogResult.Cancel:
                    return false;
            }

            return false;
        }

        protected virtual bool EntityInsert()
        {
            return ((IBaseGeneralBll)bll).Insert(currentEntity);
        }

        protected virtual bool EntityUpdate()
        {
            return ((IBaseGeneralBll)bll).Update(oldEntity, currentEntity);
        }

        protected internal virtual void Loading()
        {
        }

        protected virtual void ControlObjectConnection()
        {
        }

        protected virtual void CreateObject()
        {
        }

        protected virtual void ButtonEnableStatus()
        {
            if (!IsLoaded) return;
            GeneralFunctions.ButtonEnabledStatus(btnNew, btnSave, btnBack, btnDelete, oldEntity, currentEntity);
        }

        private void ButtonHideOrShow()
        {
            ShowItem?.ForEach(x => x.Visibility = BarItemVisibility.Always);
            HideItem?.ForEach(x => x.Visibility = BarItemVisibility.Never);
        }

        #endregion

        #region Events

        #endregion
    }
}