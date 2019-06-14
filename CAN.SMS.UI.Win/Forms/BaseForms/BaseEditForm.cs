using CAN.SMS.Common.Enums;
using DevExpress.XtraBars.Ribbon;

namespace CAN.SMS.UI.Win.Forms.BaseForms
{
    public partial class BaseEditForm : RibbonForm
    {
        protected internal ProcessType processType;

        protected internal long Id;

        protected internal bool Refresh;

        public BaseEditForm()
        {
            InitializeComponent();
        }

        #region Functions

        protected internal void Load()
        {

        }

        #endregion

        #region Events



        #endregion
    }
}