using System.ComponentModel;
using CAN.SMS.UI.Win.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Registrator;

namespace CAN.SMS.UI.Win.UserControls.Controls.Grid
{
    [ToolboxItem(true)]
    public class MyGridControl : GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            var view = (GridView)CreateView("MyGridView");

            view.Appearance.ViewCaption.ForeColor = Color.Maroon;
            view.Appearance.HeaderPanel.ForeColor = Color.Maroon;
            view.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            view.Appearance.FooterPanel.ForeColor = Color.Maroon;
            view.Appearance.FooterPanel.Font = new Font(new FontFamily("Tahoma"), 8.25f, FontStyle.Bold);

            view.OptionsMenu.EnableColumnMenu = false;
            view.OptionsMenu.EnableFooterMenu = false;
            view.OptionsMenu.EnableGroupPanelMenu = false;

            view.OptionsNavigation.EnterMoveNextColumn = true;

            view.OptionsPrint.AutoWidth = false;
            view.OptionsPrint.PrintFooter = false;
            view.OptionsPrint.PrintGroupFooter = false;

            view.OptionsView.ShowViewCaption = true;
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ColumnAutoWidth = false;
            view.OptionsView.RowAutoHeight = true;
            view.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;

            var idColumn = new MyGridColumn { Caption = "Id", FieldName = "Id" };
            idColumn.OptionsColumn.AllowEdit = false;
            idColumn.Visible = false;
            idColumn.OptionsColumn.ShowInCustomizationForm = false;
            view.Columns.Add(idColumn);

            var codeColumn = new MyGridColumn { Caption = "Code", FieldName = "Code" };
            idColumn.OptionsColumn.AllowEdit = false;
            idColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            idColumn.AppearanceCell.Options.UseTextOptions = true;
            view.Columns.Add(codeColumn);

            return view;
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyGridInfoRegistrator());
        }

        public class MyGridInfoRegistrator : GridInfoRegistrator
        {
            public override string ViewName => "MyGridView";
            public override BaseView CreateView(GridControl grid) => new MyGridView(grid);
        }
    }

    public class MyGridView : GridView, IStatusBarShortCut
    {
        #region Properties

        public string statusBarDescription { get; set; }
        public string statusBarShortCut { get; set; }
        public string statusBarShortCutDescription { get; set; }

        #endregion

        public MyGridView() { }

        public MyGridView(GridControl overGrid) : base(overGrid) { }

        protected override void OnColumnChangedCore(GridColumn column)
        {
            base.OnColumnChangedCore(column);

            if (column.ColumnEdit == null) return;
            if (column.ColumnEdit.GetType() == typeof(RepositoryItemDateEdit))
            {
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                ((RepositoryItemDateEdit)column.ColumnEdit).Mask.MaskType = MaskType.DateTimeAdvancingCaret;
            }
        }

        protected override GridColumnCollection CreateColumnCollection()
        {
            return new MyGridColumnCollection(this);
        }

        public class MyGridColumnCollection : GridColumnCollection
        {
            public MyGridColumnCollection(ColumnView view) : base(view) { }
            protected override GridColumn CreateColumn()
            {
                var column = new MyGridColumn();
                column.OptionsColumn.AllowEdit = false;
                return column;
            }
        }
    }

    public class MyGridColumn : GridColumn, IStatusBarShortCut
    {
        #region Propoerties

        public string statusBarDescription { get; set; }
        public string statusBarShortCut { get; set; }
        public string statusBarShortCutDescription { get; set; }

        #endregion
    }
}