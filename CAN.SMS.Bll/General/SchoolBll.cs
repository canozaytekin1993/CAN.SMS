﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using CAN.SMS.Bll.Base;
using CAN.SMS.Bll.Interfaces;
using CAN.SMS.Common.Enums;
using CAN.SMS.Data.Contexts;
using CAN.SMS.Model.Dto;
using CAN.SMS.Model.Entities;
using CAN.SMS.Model.Entities.Base;

namespace CAN.SMS.Bll.General
{
    public class SchoolBll : BaseBll<School, StudentTrackingContext>, IBaseGeneralBll, IBaseCommonBll
    {
        public SchoolBll()
        {
        }

        public SchoolBll(Control ctrl) : base(ctrl)
        {
        }

        public BaseEntity Single(Expression<Func<School, bool>> filter)
        {
            return BaseSingle(filter, x => new SchoolS
            {
                Id = x.Id,
                Code = x.Code,
                SchoolName = x.SchoolName,
                CountryId = x.CountryId,
                CountryName = x.Country.CountryName,
                CountyId = x.CountyId,
                CountyName = x.County.CountyName,
                Description = x.Description,
                Statu = x.Statu
            });
        }

        public IEnumerable<BaseEntity> List(Expression<Func<School, bool>> filter)
        {
            return BaseList(filter, x => new SchoolL
            {
                Id = x.Id,
                Code = x.Code,
                SchoolName = x.SchoolName,
                CountryName = x.Country.CountryName,
                CountyName = x.County.CountyName,
                Description = x.Description
            }).OrderBy(x => x.Code).ToList();
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
            return BaseNewCodeGenerate(CardType.School, x => x.Code);
        }

        public bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity, CardType.School);
        }
    }
}