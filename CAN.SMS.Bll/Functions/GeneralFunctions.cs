using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using CAN.SMS.Dal.Base;
using CAN.SMS.Dal.Interfaces;
using CAN.SMS.Model.Entities.Base.Interfaces;

namespace CAN.SMS.Bll.Functions
{
    public static class GeneralFunctions
    {
        public static IList<string> ChangeColumnGet<T>(this T oldEntity, T currentEntity)
        {
            IList<string> columns = new List<string>();

            foreach (var prop in currentEntity.GetType().GetProperties())
            {
                if (prop.PropertyType.Namespace == "System.Collections.Generic") continue;
                var oldValue = prop.GetValue(oldEntity) ?? string.Empty;
                var currentValue = prop.GetValue(currentEntity) ?? string.Empty;

                if (prop.PropertyType == typeof(byte[]))
                {
                    if (string.IsNullOrEmpty(oldValue.ToString())) oldValue = new byte[] {0};
                    if (string.IsNullOrEmpty(currentEntity.ToString())) currentValue = new byte[] {0};
                    if (((byte[]) oldValue).Length != ((byte[]) currentValue).Length) columns.Add(prop.Name);
                }
                else if (!currentValue.Equals(oldValue))
                {
                    columns.Add(prop.Name);
                }
            }

            return columns;
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["StudentTrackingContext"].ConnectionString;
        }

        private static TContext CreateContext<TContext>() where TContext : DbContext
        {
            return (TContext) Activator.CreateInstance(typeof(TContext), GetConnectionString());
        }

        public static void CreateUnitOfWork<T, TContext>(ref IUnitOfWork<T> ww)
            where T : class, IBaseEntity where TContext : DbContext
        {
            ww?.Dispose();
            ww = new UnitOfWork<T>(CreateContext<TContext>());
        }
    }
}