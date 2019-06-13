using System;
using System.Linq;
using CAN.SMS.Model.Entities.Base.Interfaces;

namespace CAN.SMS.Bll.Functions
{
    public static class Converts
    {
        public static TTarget EntityConvert<TTarget>(this IBaseEntity source)
        {
            if (source == null) return default;
            var target = Activator.CreateInstance<TTarget>();
            var sourceProp = source.GetType().GetProperties();
            var targetProp = typeof(TTarget).GetProperties();

            foreach (var sp in sourceProp)
            {
                var value = sp.GetValue(source);
                var tp = targetProp.FirstOrDefault(x => x.Name == sp.Name);
                if (tp != null) tp.SetValue(target, ReferenceEquals(value, "") ? null : value);
            }

            return target;
        }
    }
}