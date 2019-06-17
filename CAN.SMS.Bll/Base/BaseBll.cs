using CAN.SMS.Bll.Functions;
using CAN.SMS.Bll.Interfaces;
using CAN.SMS.Common.Enums;
using CAN.SMS.Common.Functions;
using CAN.SMS.Common.Messages;
using CAN.SMS.Dal.Interfaces;
using CAN.SMS.Model.Entities.Base;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using CAN.SMS.Model.Attributes;

namespace CAN.SMS.Bll.Base
{
    public class BaseBll<T, TContext> : IBaseBll where T : BaseEntity where TContext : DbContext
    {
        private readonly Control _ctrl;
        private IUnitOfWork<T> _ww;

        private bool Validation(ProcessType processType, BaseEntity oldEntity, BaseEntity currentEntity,
            Expression<Func<T, bool>> filter)
        {
            var errorControl = GetValidationErrorControl();

            if (errorControl == null) return true;
            _ctrl.Controls[errorControl].Focus();
            return false;

            string GetValidationErrorControl()
            {
                string genericCode()
                {
                    foreach (var property in typeof(T).GetPropertyAttributesFromType<Code>())
                    {
                        if (property.Attribute == null) continue;

                        if ((processType == ProcessType.EntityInsert || oldEntity.Code == currentEntity.Code) && processType == ProcessType.EntityUpdate) continue;

                        if (_ww.Rep.Count(filter) < 1) continue;

                        Messages.RepeatedRegisterErrorMessage(property.Attribute._description);
                        return property.Attribute._controlName;
                    }

                    return null;
                }

                string incorrectEntry()
                {
                    foreach (var property in typeof(T).GetPropertyAttributesFromType<RequiredFields>())
                    {
                        if (property.Attribute == null) continue;
                        var value = property.Property.GetValue(currentEntity);

                        if (property.Property.PropertyType == typeof(long))
                            if ((long)value == 0) value = null;

                        if (!string.IsNullOrEmpty(value?.ToString())) continue;

                        Messages.IncorrectDataMessage(property.Attribute._description);
                        return property.Attribute._controlName;
                    }

                    return null;
                }

                return incorrectEntry() ?? genericCode();
            }
        }

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

        protected bool BaseInsert(BaseEntity entity, Expression<Func<T, bool>> filter)
        {
            try
            {
                GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _ww);
                if (!Validation(ProcessType.EntityInsert, null, entity, filter)) return false;
                _ww.Rep.Insert(entity.EntityConvert<T>());
                return _ww.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        protected bool BaseUpdate(BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<T, bool>> filter)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _ww);
            if (!Validation(ProcessType.EntityUpdate, null, currentEntity, filter)) return false;
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