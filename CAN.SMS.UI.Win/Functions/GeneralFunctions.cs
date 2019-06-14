using CAN.SMS.Common.Enums;
using CAN.SMS.Common.Messages;
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

            return default(T);
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
                    return DataChangeLocation.Column;
            }

            return DataChangeLocation.NoChange;
        }

        public static void ButtonEnabledStatus<T>(BarButtonItem btnNew, BarButtonItem btnSave, BarButtonItem btnBack, BarButtonItem btnDelete, T oldEntity, T currentEntity)
        {
            var dataChangeLocation = dataChangeLocationGet(oldEntity, currentEntity);
            var buttonEnabledStatus = dataChangeLocation == DataChangeLocation.Column;

            btnSave.Enabled = buttonEnabledStatus;
            btnBack.Enabled = buttonEnabledStatus;
            btnNew.Enabled = !buttonEnabledStatus;
            btnDelete.Enabled = !buttonEnabledStatus;

        }
    }
}