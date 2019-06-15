using System;
using System.Windows.Forms;
using CAN.SMS.Bll.Interfaces;
using CAN.SMS.Common.Enums;
using CAN.SMS.Common.Messages;
using CAN.SMS.Model.Entities.Base;
using CAN.SMS.UI.Win.Functions;
using CAN.SMS.UI.Win.UserControls.Controls;
using DevExpress.Utils.Internal.DTE;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace CAN.SMS.UI.Win.Forms.BaseForms
{
    public partial class BaseEditForm : RibbonForm
    {
        protected IBaseBll bll;
        protected CardType cardType;
        protected BaseEntity currentEntity;
        protected MyDataLayoutControl dataLayoutControl;
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
        }

        private void EntityDelete()
        {
            throw new NotImplementedException();
        }

        private void Back()
        {
            throw new NotImplementedException();
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
                    return true;
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