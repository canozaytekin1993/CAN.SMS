namespace CAN.SMS.UI.Win.UserControls.Controls.Navigators
{
    partial class LongNavigator
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LongNavigator));
            this.Navigator = new DevExpress.XtraEditors.ControlNavigator();
            this.ImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // Navigator
            // 
            this.Navigator.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Navigator.Appearance.Options.UseForeColor = true;
            this.Navigator.Buttons.Append.Visible = false;
            this.Navigator.Buttons.CancelEdit.Visible = false;
            this.Navigator.Buttons.Edit.Visible = false;
            this.Navigator.Buttons.EnabledAutoRepeat = false;
            this.Navigator.Buttons.EndEdit.Visible = false;
            this.Navigator.Buttons.First.ImageIndex = 0;
            this.Navigator.Buttons.ImageList = this.ImageCollection;
            this.Navigator.Buttons.Last.ImageIndex = 1;
            this.Navigator.Buttons.Next.ImageIndex = 2;
            this.Navigator.Buttons.NextPage.ImageIndex = 4;
            this.Navigator.Buttons.Prev.ImageIndex = 3;
            this.Navigator.Buttons.PrevPage.ImageIndex = 5;
            this.Navigator.Buttons.Remove.Visible = false;
            this.Navigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Navigator.Location = new System.Drawing.Point(0, 0);
            this.Navigator.Name = "Navigator";
            this.Navigator.Size = new System.Drawing.Size(608, 24);
            this.Navigator.TabIndex = 0;
            this.Navigator.Text = "controlNavigator1";
            this.Navigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Begin;
            this.Navigator.TextStringFormat = "Cards {0} of {1}";
            // 
            // ImageCollection
            // 
            this.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageCollection.ImageStream")));
            this.ImageCollection.InsertImage(global::CAN.SMS.UI.Win.Properties.Resources.first_16x161, "first_16x161", typeof(global::CAN.SMS.UI.Win.Properties.Resources), 0);
            this.ImageCollection.Images.SetKeyName(0, "first_16x161");
            this.ImageCollection.InsertImage(global::CAN.SMS.UI.Win.Properties.Resources.last_16x161, "last_16x161", typeof(global::CAN.SMS.UI.Win.Properties.Resources), 1);
            this.ImageCollection.Images.SetKeyName(1, "last_16x161");
            this.ImageCollection.InsertImage(global::CAN.SMS.UI.Win.Properties.Resources.next_16x161, "next_16x161", typeof(global::CAN.SMS.UI.Win.Properties.Resources), 2);
            this.ImageCollection.Images.SetKeyName(2, "next_16x161");
            this.ImageCollection.InsertImage(global::CAN.SMS.UI.Win.Properties.Resources.prev_16x161, "prev_16x161", typeof(global::CAN.SMS.UI.Win.Properties.Resources), 3);
            this.ImageCollection.Images.SetKeyName(3, "prev_16x161");
            this.ImageCollection.InsertImage(global::CAN.SMS.UI.Win.Properties.Resources.doublenext_16x161, "doublenext_16x161", typeof(global::CAN.SMS.UI.Win.Properties.Resources), 4);
            this.ImageCollection.Images.SetKeyName(4, "doublenext_16x161");
            this.ImageCollection.InsertImage(global::CAN.SMS.UI.Win.Properties.Resources.doubleprev_16x161, "doubleprev_16x161", typeof(global::CAN.SMS.UI.Win.Properties.Resources), 5);
            this.ImageCollection.Images.SetKeyName(5, "doubleprev_16x161");
            // 
            // LongNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Navigator);
            this.Name = "LongNavigator";
            this.Size = new System.Drawing.Size(608, 24);
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.ImageCollection ImageCollection;
        public DevExpress.XtraEditors.ControlNavigator Navigator;
    }
}
