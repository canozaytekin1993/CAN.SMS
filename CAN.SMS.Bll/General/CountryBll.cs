using CAN.SMS.Bll.Base;
using CAN.SMS.Bll.Interfaces;
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
    public class CountryBll : BaseBll<Country, StudentTrackingContext>, IBaseGeneralBll, IBaseCommonBll
    {
        public CountryBll() { }

        public CountryBll(Control ctrl) : base(ctrl) { }

        public BaseEntity Single(Expression<Func<Country, bool>> filter)
        {
            return BaseSingle(filter, x => x);
        }

        public IEnumerable<BaseEntity> List(Expression<Func<Country, bool>> filter)
        {
            return BaseList(filter, x => x).OrderBy(x => x.Code).ToList();
        }

        public bool Insert(BaseEntity entity)
        {
            return BaseInsert(entity, x => x.Code == entity.Code);
        }

        public bool Update(BaseEntity oldEntity, BaseEntity currentEntity)
        {
            return BaseUpdate(oldEntity, currentEntity, x => x.Code == currentEntity.Code);
        }

        public string NewCodeCreate()
        {
            return BaseNewCodeGenerate(CardType.Country, x => x.Code);
        }

        public bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity, CardType.Country);
        }
    }
}