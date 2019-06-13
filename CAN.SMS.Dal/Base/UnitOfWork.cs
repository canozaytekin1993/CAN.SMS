using CAN.SMS.Common.Messages;
using CAN.SMS.Dal.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace CAN.SMS.Dal.Base
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        #region Variables

        private readonly DbContext _context;

        #endregion

        public UnitOfWork(DbContext context)
        {
            if (context == null) return;
            _context = context;
        }

        public IRepository<T> Rep => new Repository<T>(_context);
        public bool Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var sqlEx = (SqlException)ex.InnerException?.InnerException;
                if (sqlEx == null)
                {
                    Messages.ErrorMessage(ex.Message);
                    return false;
                }

                switch (sqlEx.Number)
                {
                    case 208:
                        Messages.ErrorMessage("Table is not in the database.");
                        break;
                    case 547:
                        Messages.ErrorMessage("Your selection cannot be deleted.");
                        break;
                    case 2601:
                    case 2627:
                        Messages.ErrorMessage("Id is used.");
                        break;
                    case 4060:
                        Messages.ErrorMessage("No database found.");
                        break;
                    case 18456:
                        Messages.ErrorMessage("Database username and password are incorrect.");
                        break;
                    default:
                        Messages.ErrorMessage(sqlEx.Message);
                        break;
                }

                return false;
            }
            catch (Exception ex)
            {
                Messages.ErrorMessage(ex.Message);
                return false;
            }

            return true;
        }

        #region Dispose

        private bool _disposedValue = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool dispossing)
        {
            if (!_disposedValue)
            {
                if (dispossing)
                {
                    _context.Dispose();
                }

                _disposedValue = true;
            }
        }

        #endregion
    }
}