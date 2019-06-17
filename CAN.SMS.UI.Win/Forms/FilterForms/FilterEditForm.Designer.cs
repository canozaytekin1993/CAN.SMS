namespace CAN.SMS.UI.Win.Forms.FilterForms
{
    partial class FilterEditForm
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
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            this.myDataLayoutControl = new CAN.SMS.UI.Win.UserControls.Controls.MyDataLayoutControl();
            this.txtFilterText = new CAN.SMS.UI.Win.UserControls.Controls.MyFilterControl();
            this.txtFilterName = new CAN.SMS.UI.Win.UserControls.Controls.MyTextEdit();
            this.txtCode = new CAN.SMS.UI.Win.UserControls.Controls.MyCodeTextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Code = new DevExpress.XtraLayout.LayoutControlItem();
            this.Filter_Name = new DevExpress.XtraLayout.LayoutControlItem();
            this.Filter_Text = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl)).BeginInit();
            this.myDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Text)).BeginInit();
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
            this.ribbonControl.Size = new System.Drawing.Size(460, 102);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl
            // 
            this.myDataLayoutControl.Controls.Add(this.txtFilterText);
            this.myDataLayoutControl.Controls.Add(this.txtFilterName);
            this.myDataLayoutControl.Controls.Add(this.txtCode);
            this.myDataLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataLayoutControl.Location = new System.Drawing.Point(0, 102);
            this.myDataLayoutControl.Name = "myDataLayoutControl";
            this.myDataLayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1270, 9, 650, 400);
            this.myDataLayoutControl.OptionsFocus.EnableAutoTabOrder = false;
            this.myDataLayoutControl.Root = this.Root;
            this.myDataLayoutControl.Size = new System.Drawing.Size(460, 186);
            this.myDataLayoutControl.TabIndex = 2;
            this.myDataLayoutControl.Text = "myDataLayoutControl1";
            // 
            // txtFilterText
            // 
            this.txtFilterText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtFilterText.Location = new System.Drawing.Point(69, 60);
            this.txtFilterText.Name = "txtFilterText";
            this.txtFilterText.ShowGroupCommandsIcon = true;
            this.txtFilterText.Size = new System.Drawing.Size(379, 114);
            this.txtFilterText.statusBarDescription = "Enter filter text";
            this.txtFilterText.TabIndex = 6;
            this.txtFilterText.Text = "myFilterControl1";
            // 
            // txtFilterName
            // 
            this.txtFilterName.EnterMoveNextControl = true;
            this.txtFilterName.Location = new System.Drawing.Point(69, 36);
            this.txtFilterName.MenuManager = this.ribbonControl;
            this.txtFilterName.Name = "txtFilterName";
            this.txtFilterName.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtFilterName.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtFilterName.Properties.MaxLength = 50;
            this.txtFilterName.Size = new System.Drawing.Size(379, 20);
            this.txtFilterName.statusBarDescription = "Enter filter name";
            this.txtFilterName.StyleController = this.myDataLayoutControl;
            this.txtFilterName.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.EnterMoveNextControl = true;
            this.txtCode.Location = new System.Drawing.Point(69, 12);
            this.txtCode.MenuManager = this.ribbonControl;
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCode.Properties.AppearanceFocused.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtCode.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtCode.Properties.MaxLength = 20;
            this.txtCode.Size = new System.Drawing.Size(139, 20);
            this.txtCode.statusBarDescription = "Enter Code";
            this.txtCode.StyleController = this.myDataLayoutControl;
            this.txtCode.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Code,
            this.Filter_Name,
            this.Filter_Text});
            this.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.Root.Name = "Root";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition1.Width = 200D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition2.Width = 100D;
            this.Root.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2});
            rowDefinition1.Height = 24D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition2.Height = 24D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition3.Height = 100D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            this.Root.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2,
            rowDefinition3});
            this.Root.Size = new System.Drawing.Size(460, 186);
            this.Root.TextVisible = false;
            // 
            // Code
            // 
            this.Code.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.Code.AppearanceItemCaption.Options.UseForeColor = true;
            this.Code.Control = this.txtCode;
            this.Code.Location = new System.Drawing.Point(0, 0);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(200, 24);
            this.Code.TextSize = new System.Drawing.Size(54, 13);
            // 
            // Filter_Name
            // 
            this.Filter_Name.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.Filter_Name.AppearanceItemCaption.Options.UseForeColor = true;
            this.Filter_Name.Control = this.txtFilterName;
            this.Filter_Name.Location = new System.Drawing.Point(0, 24);
            this.Filter_Name.Name = "Filter_Name";
            this.Filter_Name.OptionsTableLayoutItem.ColumnSpan = 2;
            this.Filter_Name.OptionsTableLayoutItem.RowIndex = 1;
            this.Filter_Name.Size = new System.Drawing.Size(440, 24);
            this.Filter_Name.Text = "Filter Name";
            this.Filter_Name.TextSize = new System.Drawing.Size(54, 13);
            // 
            // Filter_Text
            // 
            this.Filter_Text.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.Filter_Text.AppearanceItemCaption.Options.UseForeColor = true;
            this.Filter_Text.Control = this.txtFilterText;
            this.Filter_Text.Location = new System.Drawing.Point(0, 48);
            this.Filter_Text.Name = "Filter_Text";
            this.Filter_Text.OptionsTableLayoutItem.ColumnSpan = 2;
            this.Filter_Text.OptionsTableLayoutItem.RowIndex = 2;
            this.Filter_Text.Size = new System.Drawing.Size(440, 118);
            this.Filter_Text.Text = "Filter Text";
            this.Filter_Text.TextSize = new System.Drawing.Size(54, 13);
            // 
            // FilterEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 319);
            this.Controls.Add(this.myDataLayoutControl);
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(470, 320);
            this.Name = "FilterEditForm";
            this.Text = "Filter Card";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.myDataLayoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl)).EndInit();
            this.myDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFilterName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Filter_Text)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private UserControls.Controls.MyTextEdit txtFilterName;
        private UserControls.Controls.MyCodeTextEdit txtCode;
        private DevExpress.XtraLayout.LayoutControlItem Code;
        private DevExpress.XtraLayout.LayoutControlItem Filter_Name;
        private DevExpress.XtraLayout.LayoutControlItem Filter_Text;
        protected UserControls.Controls.MyFilterControl txtFilterText;
    }
}