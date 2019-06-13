namespace CAN.SMS.UI.Win.UserControls.Controls.Navigators
{
    partial class InsUpNavigator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsUpNavigator));
            this.controlNavigator1 = new DevExpress.XtraEditors.ControlNavigator();
            this.ImageCollection = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection)).BeginInit();
            this.SuspendLayout();
            // 
            // controlNavigator1
            // 
            this.controlNavigator1.Buttons.Append.ImageIndex = 6;
            this.controlNavigator1.Buttons.CancelEdit.Visible = false;
            this.controlNavigator1.Buttons.Edit.Visible = false;
            this.controlNavigator1.Buttons.EndEdit.Visible = false;
            this.controlNavigator1.Buttons.First.ImageIndex = 0;
            this.controlNavigator1.Buttons.ImageList = this.ImageCollection;
            this.controlNavigator1.Buttons.Last.ImageIndex = 4;
            this.controlNavigator1.Buttons.Next.ImageIndex = 2;
            this.controlNavigator1.Buttons.NextPage.Visible = false;
            this.controlNavigator1.Buttons.Prev.ImageIndex = 3;
            this.controlNavigator1.Buttons.PrevPage.Visible = false;
            this.controlNavigator1.Buttons.Remove.ImageIndex = 7;
            this.controlNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator1.Location = new System.Drawing.Point(0, 0);
            this.controlNavigator1.Name = "controlNavigator1";
            this.controlNavigator1.Size = new System.Drawing.Size(597, 24);
            this.controlNavigator1.TabIndex = 0;
            this.controlNavigator1.Text = "controlNavigator1";
            // 
            // ImageCollection
            // 
            this.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageCollection.ImageStream")));
            this.ImageCollection.InsertImage(global::CAN.SMS.UI.Win.Properties.Resources.first_16x16, "first_16x16", typeof(global::CAN.SMS.UI.Win.Properties.Resources), 0);
            this.ImageCollection.Images.SetKeyName(0, "first_16x16");
            this.ImageCollection.InsertImage(global::CAN.SMS.UI.Win.Properties.Resources.last_16x16, "last_16x16", typeof(global::CAN.SMS.UI.Win.Properties.Resources), 1);
            this.ImageCollection.Images.SetKeyName(1, "last_16x16");
            this.ImageCollection.InsertImage(global::CAN.SMS.UI.Win.Properties.Resources.next_16x16, "next_16x16", typeof(global::CAN.SMS.UI.Win.Properties.Resources), 2);
            this.ImageCollection.Images.SetKeyName(2, "next_16x16");
            this.ImageCollection.InsertImage(global::CAN.SMS.UI.Win.Properties.Resources.prev_16x16, "prev_16x16", typeof(global::CAN.SMS.UI.Win.Properties.Resources), 3);
            this.ImageCollection.Images.SetKeyName(3, "prev_16x16");
            this.ImageCollection.InsertImage(global::CAN.SMS.UI.Win.Properties.Resources.doublenext_16x16, "doublenext_16x16", typeof(global::CAN.SMS.UI.Win.Properties.Resources), 4);
            this.ImageCollection.Images.SetKeyName(4, "doublenext_16x16");
            this.ImageCollection.InsertImage(global::CAN.SMS.UI.Win.Properties.Resources.doubleprev_16x16, "doubleprev_16x16", typeof(global::CAN.SMS.UI.Win.Properties.Resources), 5);
            this.ImageCollection.Images.SetKeyName(5, "doubleprev_16x16");
            this.ImageCollection.InsertImage(global::CAN.SMS.UI.Win.Properties.Resources.addfile_16x16, "addfile_16x16", typeof(global::CAN.SMS.UI.Win.Properties.Resources), 6);
            this.ImageCollection.Images.SetKeyName(6, "addfile_16x16");
            this.ImageCollection.InsertImage(global::CAN.SMS.UI.Win.Properties.Resources.deletelist_16x16, "deletelist_16x16", typeof(global::CAN.SMS.UI.Win.Properties.Resources), 7);
            this.ImageCollection.Images.SetKeyName(7, "deletelist_16x16");
            // 
            // InsUpNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controlNavigator1);
            this.Name = "InsUpNavigator";
            this.Size = new System.Drawing.Size(597, 24);
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ControlNavigator controlNavigator1;
        private DevExpress.Utils.ImageCollection ImageCollection;
    }
}
