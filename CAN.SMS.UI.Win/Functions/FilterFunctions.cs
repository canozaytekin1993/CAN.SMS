﻿using System;
using System.Linq.Expressions;
using CAN.SMS.Model.Entities.Base;

namespace CAN.SMS.UI.Win.Functions
{
    public class FilterFunctions
    {
        public static Expression<Func<T, bool>> Filter<T>(bool activeCardsShow) where T : BaseEntityStatu
        {
            return x => x.Statu == activeCardsShow;
        }

        public static Expression<Func<T, bool>> Filter<T>(long id) where T : BaseEntity
        {
            return x => x.Id == id;
        }
    }
}