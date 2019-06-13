using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using CAN.SMS.Dal.Interfaces;

namespace CAN.SMS.Dal.Base
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            if (context == null) return;
            _context = context;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
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
                var sqlEx = (SqlException) ex.InnerException?.InnerException;
                if (sqlEx == null)
                {
                    
                }
            }
        }
    }
}