using System.Windows.Forms;
using CAN.SMS.Bll.Base;
using CAN.SMS.Data.Contexts;
using CAN.SMS.Model.Entities;

namespace CAN.SMS.Bll.General
{
    public class SchoolBll : BaseBll<School, StudentTrackingContext>
    {
        public SchoolBll()
        {
        }

        protected SchoolBll(Control ctrl) : base(ctrl)
        {
        }
    }
}