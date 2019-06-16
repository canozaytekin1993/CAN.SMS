using CAN.SMS.Bll.Interfaces;
using CAN.SMS.Common.Enums;
using CAN.SMS.Common.Messages;
using CAN.SMS.Model.Entities.Base;
using CAN.SMS.UI.Win.Functions;
using CAN.SMS.UI.Win.UserControls.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CAN.SMS.UI.Win.Forms.BaseForms
{
    public partial class BaseEditForm : RibbonForm
    {
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
            Load += BaseEditForm_Load;
            FormClosing += BaseEditForm_FormClosing;

            void ControlEvents(Control control)
            {
                control.KeyDown += Control_KeyDown;

                switch (control)
                {
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

        private void BaseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // SchemeSave();

            if (btnSave.Visibility == BarItemVisibility.Never || !btnSave.Enabled) return;
            if (!Save(true)) e.Cancel = true;
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
            //SchemeLoading();
            //ButtonHideOrShow();
            Id = processType.CreateId(oldEntity);

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

            else if (e.Item == btnBack)
            {
                Back();
            }

            else if (e.Item == btnDelete)
            {
                // Authorization Control
                EntityDelete();
            }

            else if (e.Item == btnExit)
            {
                Close();
            }

            Cursor.Current = DefaultCursor;
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

        protected internal virtual void ButtonEnableStatus()
        {
            if (!IsLoaded) return;
            GeneralFunctions.ButtonEnabledStatus(btnNew, btnSave, btnBack, btnDelete, oldEntity, currentEntity);
        }

        #endregion

        #region Events

        #endregion
    }
}