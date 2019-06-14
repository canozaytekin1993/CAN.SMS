namespace CAN.SMS.UI.Win.Forms.SchoolForms
{
    partial class SchoolListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grid = new CAN.SMS.UI.Win.UserControls.Controls.Grid.MyGridControl();
            this.table = new CAN.SMS.UI.Win.UserControls.Controls.Grid.MyGridView();
            this.colId = new CAN.SMS.UI.Win.UserControls.Controls.Grid.MyGridColumn();
            this.colCode = new CAN.SMS.UI.Win.UserControls.Controls.Grid.MyGridColumn();
            this.colSchoolName = new CAN.SMS.UI.Win.UserControls.Controls.Grid.MyGridColumn();
            this.colCountryName = new CAN.SMS.UI.Win.UserControls.Controls.Grid.MyGridColumn();
            this.colCountyName = new CAN.SMS.UI.Win.UserControls.Controls.Grid.MyGridColumn();
            this.colDescription = new CAN.SMS.UI.Win.UserControls.Controls.Grid.MyGridColumn();
            this.longNavigator1 = new CAN.SMS.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            // 
            // 
            // 
            this.ribbonControl.SearchEditItem.EditWidth = 150;
            this.ribbonControl.SearchEditItem.Id = -5000;
            this.ribbonControl.SearchEditItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.Size = new System.Drawing.Size(1123, 102);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 102);
            this.grid.MainView = this.table;
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1123, 347);
            this.grid.TabIndex = 2;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.table});
            // 
            // table
            // 
            this.table.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.table.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Maroon;
            this.table.Appearance.FooterPanel.Options.UseFont = true;
            this.table.Appearance.FooterPanel.Options.UseForeColor = true;
            this.table.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Maroon;
            this.table.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.table.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.table.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.table.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.table.Appearance.ViewCaption.Options.UseForeColor = true;
            this.table.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colCode,
            this.colSchoolName,
            this.colCountryName,
            this.colCountyName,
            this.colDescription});
            this.table.GridControl = this.grid;
            this.table.Name = "table";
            this.table.OptionsMenu.EnableColumnMenu = false;
            this.table.OptionsMenu.EnableFooterMenu = false;
            this.table.OptionsMenu.EnableGroupPanelMenu = false;
            this.table.OptionsNavigation.EnterMoveNextColumn = true;
            this.table.OptionsPrint.AutoWidth = false;
            this.table.OptionsPrint.PrintFooter = false;
            this.table.OptionsPrint.PrintGroupFooter = false;
            this.table.OptionsView.ColumnAutoWidth = false;
            this.table.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.table.OptionsView.RowAutoHeight = true;
            this.table.OptionsView.ShowAutoFilterRow = true;
            this.table.OptionsView.ShowGroupPanel = false;
            this.table.OptionsView.ShowViewCaption = true;
            this.table.statusBarDescription = null;
            this.table.statusBarShortCut = null;
            this.table.statusBarShortCutDescription = null;
            this.table.ViewCaption = "School Cards";
            // 
            // colId
            // 
            this.colId.AppearanceCell.Options.UseTextOptions = true;
            this.colId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            this.colId.statusBarDescription = null;
            this.colId.statusBarShortCut = null;
            this.colId.statusBarShortCutDescription = null;
            // 
            // colCode
            // 
            this.colCode.Caption = "Code";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.statusBarDescription = null;
            this.colCode.statusBarShortCut = null;
            this.colCode.statusBarShortCutDescription = null;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 130;
            // 
            // colSchoolName
            // 
            this.colSchoolName.Caption = "School Name";
            this.colSchoolName.FieldName = "SchoolName";
            this.colSchoolName.Name = "colSchoolName";
            this.colSchoolName.OptionsColumn.AllowEdit = false;
            this.colSchoolName.statusBarDescription = null;
            this.colSchoolName.statusBarShortCut = null;
            this.colSchoolName.statusBarShortCutDescription = null;
            this.colSchoolName.Visible = true;
            this.colSchoolName.VisibleIndex = 1;
            this.colSchoolName.Width = 260;
            // 
            // colCountryName
            // 
            this.colCountryName.Caption = "Country";
            this.colCountryName.FieldName = "CountryName";
            this.colCountryName.Name = "colCountryName";
            this.colCountryName.OptionsColumn.AllowEdit = false;
            this.colCountryName.statusBarDescription = null;
            this.colCountryName.statusBarShortCut = null;
            this.colCountryName.statusBarShortCutDescription = null;
            this.colCountryName.Visible = true;
            this.colCountryName.VisibleIndex = 2;
            this.colCountryName.Width = 130;
            // 
            // colCountyName
            // 
            this.colCountyName.Caption = "County";
            this.colCountyName.FieldName = "CountyName";
            this.colCountyName.Name = "colCountyName";
            this.colCountyName.OptionsColumn.AllowEdit = false;
            this.colCountyName.statusBarDescription = null;
            this.colCountyName.statusBarShortCut = null;
            this.colCountyName.statusBarShortCutDescription = null;
            this.colCountyName.Visible = true;
            this.colCountyName.VisibleIndex = 3;
            this.colCountyName.Width = 130;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.statusBarDescription = null;
            this.colDescription.statusBarShortCut = null;
            this.colDescription.statusBarShortCutDescription = null;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            this.colDescription.Width = 450;
            // 
            // longNavigator1
            // 
            this.longNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.longNavigator1.Location = new System.Drawing.Point(0, 449);
            this.longNavigator1.Name = "longNavigator1";
            this.longNavigator1.Size = new System.Drawing.Size(1123, 24);
            this.longNavigator1.TabIndex = 3;
            // 
            // SchoolCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 504);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.longNavigator1);
            this.Name = "SchoolCards";
            this.Text = "School Cards";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.longNavigator1, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Controls.Grid.MyGridControl grid;
        private UserControls.Controls.Grid.MyGridView table;
        private UserControls.Controls.Grid.MyGridColumn colId;
        private UserControls.Controls.Grid.MyGridColumn colCode;
        private UserControls.Controls.Navigators.LongNavigator longNavigator1;
        private UserControls.Controls.Grid.MyGridColumn colSchoolName;
        private UserControls.Controls.Grid.MyGridColumn colCountryName;
        private UserControls.Controls.Grid.MyGridColumn colCountyName;
        private UserControls.Controls.Grid.MyGridColumn colDescription;
    }
}