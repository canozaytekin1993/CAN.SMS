using CAN.SMS.Bll.Base;
using CAN.SMS.Common.Enums;
using CAN.SMS.Data.Contexts;
using CAN.SMS.Model.Entities;
using CAN.SMS.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace CAN.SMS.Bll.General
{
    public class CountyBll : BaseBll<County, StudentTrackingContext>
    {
        public CountyBll() { }

        public CountyBll(Control ctrl) : base(ctrl) { }

        public BaseEntity Single(Expression<Func<County, bool>> filter)
        {
            return BaseSingle(filter, x => x);
        }

        public IEnumerable<BaseEntity> List(Expression<Func<County, bool>> filter)
        {
            return BaseList(filter, x => x).OrderBy(x => x.Code).ToList();
        }

        public bool Insert(BaseEntity entity, Expression<Func<County, bool>> filter)
        {
            return BaseInsert(entity, filter);
        }

        public bool Update(BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<County, bool>> filter)
        {
            return BaseUpdate(oldEntity, currentEntity, filter);
        }

        public string NewCodeCreate(Expression<Func<County, bool>> filter)
        {
            return BaseNewCodeGenerate(CardType.County, x => x.Code, filter);
        }

        public bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity, CardType.County);
        }
    }
}