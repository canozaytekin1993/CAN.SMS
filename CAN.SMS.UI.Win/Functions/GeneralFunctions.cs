using System;
using System.Windows.Forms;
using CAN.SMS.Common.Enums;
using CAN.SMS.Common.Messages;
using CAN.SMS.Model.Entities.Base;
using CAN.SMS.UI.Win.UserControls.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;

namespace CAN.SMS.UI.Win.Functions
{
    public static class GeneralFunctions
    {
        public static long GetRowId(this GridView table)
        {
            if (table.FocusedRowHandle > -1) return (long)table.GetFocusedRowCellValue("Id");
            Messages.CardNotChooseWarningMessage();
            return -1;
        }

        public static T GetRow<T>(this GridView table, bool Ismessage = true)
        {
            if (table.FocusedRowHandle > -1) return (T)table.GetRow(table.FocusedRowHandle);

            if (Ismessage) Messages.CardNotChooseWarningMessage();

            return default;
        }

        private static DataChangeLocation dataChangeLocationGet<T>(T oldEntity, T currentEntity)
        {
            foreach (var prop in currentEntity.GetType().GetProperties())
            {
                if (prop.PropertyType.Namespace == "System.Collections.Generic") continue;
                var oldValue = prop.GetValue(oldEntity) ?? string.Empty;
                var currentValue = prop.GetValue(currentEntity) ?? string.Empty;

                if (prop.PropertyType == typeof(byte[]))
                {
                    if (string.IsNullOrEmpty(oldValue.ToString())) oldValue = new byte[] { 0 };
                    if (string.IsNullOrEmpty(currentEntity.ToString())) currentValue = new byte[] { 0 };
                    if (((byte[])oldValue).Length != ((byte[])currentValue).Length) return DataChangeLocation.Column;
                }
                else if (!currentValue.Equals(oldValue))
                {
                    return DataChangeLocation.Column;
                }
            }

            return DataChangeLocation.NoChange;
        }

        public static void ButtonEnabledStatus<T>(BarButtonItem btnNew, BarButtonItem btnSave, BarButtonItem btnBack,
            BarButtonItem btnDelete, T oldEntity, T currentEntity)
        {
            var dataChangeLocation = dataChangeLocationGet(oldEntity, currentEntity);
            var buttonEnabledStatus = dataChangeLocation == DataChangeLocation.Column;

            btnSave.Enabled = buttonEnabledStatus;
            btnBack.Enabled = buttonEnabledStatus;
            btnNew.Enabled = !buttonEnabledStatus;
            btnDelete.Enabled = !buttonEnabledStatus;
        }

        public static void ButtonEnabledStatus<T>(BarButtonItem btnSave, BarButtonItem btnSaveAs,
            BarButtonItem btnDelete, ProcessType processType, T oldEntity, T currentEntity)
        {
            var dataChangeLocation = dataChangeLocationGet(oldEntity, currentEntity);
            var buttonEnabledStatus = dataChangeLocation == DataChangeLocation.Column;

            btnSave.Enabled = buttonEnabledStatus;
            btnSaveAs.Enabled = processType != ProcessType.EntityInsert;
            btnDelete.Enabled = !buttonEnabledStatus;
        }

        public static long CreateId(this ProcessType processType, BaseEntity selectedEntity)
        {
            string ZeroAdd(string value)
            {
                if (value.Length == 1)
                    return "0" + value;
                return value;
            }

            string ThreeDigitCreate(string value)
            {
                switch (value.Length)
                {
                    case 1:
                        return "00" + value;
                    case 2:
                        return "0" + value;
                }

                return value;
            }

            string Id()
            {
                var year = ZeroAdd(DateTime.Now.Year.ToString());
                var month = ZeroAdd(DateTime.Now.Month.ToString());
                var day = ZeroAdd(DateTime.Now.Date.Day.ToString());
                var hour = ZeroAdd(DateTime.Now.Hour.ToString());
                var minute = ZeroAdd(DateTime.Now.Minute.ToString());
                var second = ZeroAdd(DateTime.Now.Second.ToString());
                var millisecond = ThreeDigitCreate(DateTime.Now.Millisecond.ToString());
                var random = ZeroAdd(new Random().Next(0, 99).ToString());

                return year + month + day + hour + minute + second + millisecond + random;
            }

            return (long)(processType == ProcessType.EntityUpdate ? selectedEntity.Id : long.Parse(Id()));
        }

        public static void ControlEnabledChange(this MyButtonEdit baseEdit, Control prmEdit)
        {
            switch (prmEdit)
            {
                case MyButtonEdit edt:
                    edt.Enabled = baseEdit.Id.HasValue && baseEdit.Id > 0;
                    edt.Id = null;
                    edt.EditValue = null;
                    break;
            }
        }

        public static void RowFocus(this GridView table, string searchColoumn, object searchValue)
        {
            var rowHandle = 0;

            for (int i = 0; i < table.RowCount; i++)
            {
                var resultValue = table.GetRowCellValue(i, searchColoumn);
                if (searchValue.Equals(resultValue)) rowHandle = 1;
            }

            table.FocusedRowHandle = rowHandle;
        }

        public static void RowFocus(this GridView table, int rowhandle)
        {
            if (rowhandle <= 0) return;

            if (rowhandle == table.RowCount - 1)
                table.FocusedRowHandle = rowhandle;
            else
                table.FocusedRowHandle = rowhandle - 1;
        }

        public static void RightClickShow(this MouseEventArgs e, PopupMenu rightMenu)
        {
            if (e.Button != MouseButtons.Right) return;
            rightMenu.ShowPopup(Control.MousePosition);
        }
    }
}