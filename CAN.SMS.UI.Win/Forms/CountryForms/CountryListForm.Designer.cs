namespace CAN.SMS.UI.Win.Forms.CountryForms
{
    partial class CountryListForm
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
            this.longNavigator = new CAN.SMS.UI.Win.UserControls.Controls.Navigators.LongNavigator();
            this.grid = new CAN.SMS.UI.Win.UserControls.Controls.Grid.MyGridControl();
            this.table = new CAN.SMS.UI.Win.UserControls.Controls.Grid.MyGridView();
            this.colId = new CAN.SMS.UI.Win.UserControls.Controls.Grid.MyGridColumn();
            this.colCode = new CAN.SMS.UI.Win.UserControls.Controls.Grid.MyGridColumn();
            this.colCountryName = new CAN.SMS.UI.Win.UserControls.Controls.Grid.MyGridColumn();
            this.colDescription = new CAN.SMS.UI.Win.UserControls.Controls.Grid.MyGridColumn();
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
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // longNavigator
            // 
            this.longNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.longNavigator.Location = new System.Drawing.Point(0, 445);
            this.longNavigator.Name = "longNavigator";
            this.longNavigator.Size = new System.Drawing.Size(1097, 24);
            this.longNavigator.TabIndex = 2;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 102);
            this.grid.MainView = this.table;
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1097, 343);
            this.grid.TabIndex = 3;
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
            this.colCountryName,
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
            this.table.ViewCaption = "Country Cards";
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
            this.colCode.Width = 150;
            // 
            // colCountryName
            // 
            this.colCountryName.Caption = "County Name";
            this.colCountryName.FieldName = "CountyName";
            this.colCountryName.Name = "colCountryName";
            this.colCountryName.OptionsColumn.AllowEdit = false;
            this.colCountryName.statusBarDescription = null;
            this.colCountryName.statusBarShortCut = null;
            this.colCountryName.statusBarShortCutDescription = null;
            this.colCountryName.Visible = true;
            this.colCountryName.VisibleIndex = 1;
            this.colCountryName.Width = 250;
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
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 450;
            // 
            // CountryListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 500);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.longNavigator);
            this.Name = "CountryListForm";
            this.Text = "Country Cards";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.longNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Controls.Navigators.LongNavigator longNavigator;
        private UserControls.Controls.Grid.MyGridControl grid;
        private UserControls.Controls.Grid.MyGridView table;
        private UserControls.Controls.Grid.MyGridColumn colId;
        private UserControls.Controls.Grid.MyGridColumn colCode;
        private UserControls.Controls.Grid.MyGridColumn colCountryName;
        private UserControls.Controls.Grid.MyGridColumn colDescription;
    }
}