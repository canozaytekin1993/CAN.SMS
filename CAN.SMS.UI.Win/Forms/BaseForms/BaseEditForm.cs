﻿using System;
using CAN.SMS.Bll.Interfaces;
using CAN.SMS.Common.Enums;
using CAN.SMS.Model.Entities.Base;
using CAN.SMS.UI.Win.Functions;
using CAN.SMS.UI.Win.UserControls.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace CAN.SMS.UI.Win.Forms.BaseForms
{
    public partial class BaseEditForm : RibbonForm
    {
        protected internal ProcessType processType;
        protected internal long Id;
        protected internal bool Refresh;
        protected MyDataLayoutControl dataLayoutControl;
        protected IBaseBll bll;
        protected CardType cardType;
        protected BaseEntity oldEntity;
        protected BaseEntity currentEntity;
        protected bool IsLoaded;

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
            Id = 
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
            throw new System.NotImplementedException();
        }

        private void Back()
        {
            throw new System.NotImplementedException();
        }

        private void Save(bool b)
        {
            throw new System.NotImplementedException();
        }

        protected internal virtual void Loading() { }

        protected virtual void ControlObjectConnection() { }

        protected virtual void CreateObject() { }

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