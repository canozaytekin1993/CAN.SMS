using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CAN.SMS.Common.Enums;
using CAN.SMS.Common.Functions;
using CAN.SMS.Dal.Interfaces;

namespace CAN.SMS.Dal.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(DbContext context)
        {
            if (context == null) return;
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Insert(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach (var entity in entities) _context.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(T entity, IEnumerable<string> fields)
        {
            _dbSet.Attach(entity);
            var entry = _context.Entry(entity);
            foreach (var field in fields) entry.Property(field).IsModified = true;
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities) _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities) _context.Entry(entity).State = EntityState.Deleted;
        }

        public TResult Find<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
        {
            return filter == null
                ? _dbSet.Select(selector).FirstOrDefault()
                : _dbSet.Where(filter).Select(selector).FirstOrDefault();
        }

        public IQueryable<TResult> Select<TResult>(Expression<Func<T, bool>> filter,
            Expression<Func<T, TResult>> selector)
        {
            return filter == null ? _dbSet.Select(selector) : _dbSet.Where(filter).Select(selector);
        }

        public string NewCodeGenerate(CardType cardType, Expression<Func<T, string>> filter, Expression<Func<T, bool>> @where = null)
        {
            string Code()
            {
                string code = null;
                var codeArray = cardType.ToName().Split(' ');

                for (int i = 0; i < codeArray.Length; i++)
                {
                    code += codeArray[i];
                }
            }
        }

        #region Variables

        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        #endregion

        #region IDisposable Support

        private bool _disposedValue; // to detact redundent calls

        public void Dispose(bool dispossing)
        {
            if (!_disposedValue)
            {
                if (dispossing) _context.Dispose();

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}