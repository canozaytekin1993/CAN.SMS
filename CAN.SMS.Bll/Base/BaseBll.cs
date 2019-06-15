using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using CAN.SMS.Bll.Functions;
using CAN.SMS.Bll.Interfaces;
using CAN.SMS.Common.Enums;
using CAN.SMS.Common.Functions;
using CAN.SMS.Common.Messages;
using CAN.SMS.Dal.Interfaces;
using CAN.SMS.Model.Entities.Base;

namespace CAN.SMS.Bll.Base
{
    public class BaseBll<T, TContext> : IBaseBll where T : BaseEntity where TContext : DbContext
    {
        private readonly Control _ctrl;
        private IUnitOfWork<T> _ww;

        protected BaseBll()
        {
        }

        protected BaseBll(Control ctrl)
        {
            _ctrl = ctrl;
        }

        #region Dispose

        public void Dispose()
        {
            _ctrl?.Dispose();
            _ww?.Dispose();
        }

        #endregion

        protected TResult BaseSingle<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _ww);
            return _ww.Rep.Find(filter, selector);
        }

        protected IQueryable<TResult> BaseList<TResult>(Expression<Func<T, bool>> filter,
            Expression<Func<T, TResult>> selector)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _ww);
            return _ww.Rep.Select(filter, selector);
        }

        protected bool BaseInsert(BaseEntity entity, Expression<Func<T, bool>> filters)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _ww);
            // Validation
            _ww.Rep.Insert(entity.EntityConvert<T>());
            return _ww.Save();
        }

        protected bool BaseUpdate(BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<T, bool>> filter)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _ww);
            // Validation
            var changeColumn = oldEntity.ChangeColumnGet(currentEntity);
            if (changeColumn.Count == 0) return true;
            _ww.Rep.Update(currentEntity.EntityConvert<T>(), changeColumn);
            return _ww.Save();
        }

        protected bool BaseDelete(BaseEntity entity, CardType cardType, bool messageGet = true)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _ww);

            if (messageGet)
                if (Messages.DeleteMessage(cardType.ToName()) != DialogResult.Yes)
                    return false;
            _ww.Rep.Delete(entity.EntityConvert<T>());
            return _ww.Save();
        }

        protected string BaseNewCodeGenerate(CardType cardType, Expression<Func<T, string>> filter,
            Expression<Func<T, bool>> where = null)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _ww);
            return _ww.Rep.NewCodeGenerate(cardType, filter, where);
        }
    }
}