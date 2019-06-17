using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CAN.SMS.Bll.Functions
{
    public static class ValidationFunctions
    {
        public static List<PropertyAttribute<TAttribute>> GetPropertyAttributesFromType<TAttribute>(this Type entityType)
            where TAttribute : Attribute
        {
            var list = new List<PropertyAttribute<TAttribute>>();
            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes<TAttribute>(true).ToList();
                if (!attributes.Any()) continue;

                list.AddRange(attributes.Select(x => new PropertyAttribute<TAttribute>(property, x)));
            }

            var interfaces = entityType.GetInterfaces();
            foreach (var iface in interfaces) list.AddRange(iface.GetPropertyAttributesFromType<TAttribute>());

            return list;
        }


        public class PropertyAttribute<TAttribute>
        {
            public PropertyAttribute(PropertyInfo property, TAttribute attribute)
            {
                Attribute = attribute;
                Property = property;
            }

            public PropertyInfo Property { get; }
            public TAttribute Attribute { get; set; }
        }
    }
}