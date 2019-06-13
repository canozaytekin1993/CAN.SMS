using System;
using CAN.SMS.Bll.Interfaces;
using CAN.SMS.Model.Entities.Base;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Windows.Forms;
using CAN.SMS.Dal.Interfaces;

namespace CAN.SMS.Bll.Base
{
    public class BaseBll<T, TContext> : IBaseBll where T : BaseEntity where TContext : DbContext
    {
        private readonly Control _control;
        private IUnitOfWork<T> _ww;

        protected BaseBll() { }

        protected BaseBll(Control ctrl)
        {
            _control = ctrl;
        }

        protected TResult BaseSingle<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {

            return _ww.Rep.Find(filter, selector);
        }



        #region IDispossable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}