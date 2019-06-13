using System;
using System.Configuration;
using System.Data.Entity;
using CAN.SMS.Dal.Interfaces;
using CAN.SMS.Model.Entities.Base.Interfaces;

namespace CAN.SMS.Bll.Functions
{
    public class GeneralFunctions
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["StudentTrackingContext"].ConnectionString;
        }

        private TContext CreateContext<TContext>() where TContext : DbContext
        {
            return (TContext)Activator.CreateInstance(typeof(TContext), GetConnectionString());
        }

        public static void CreateUnitOfWork<T, TContext>(ref IUnitOfWork<T> ww) where T :class, IBaseEntity
        {

        }
    }
}