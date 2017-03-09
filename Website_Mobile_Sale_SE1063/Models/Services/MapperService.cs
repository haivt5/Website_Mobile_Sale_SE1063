using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace Website_Mobile_Sale_SE1063.Models.Services
{
    public static class MapperService<TSource, TDestination>
    {

        public static TDestination Map(TSource source, TDestination destination)
        {
            PropertyInfo[] sourceProps = source.GetType().GetProperties();
            PropertyInfo[] destinationProps = destination.GetType().GetProperties();
            PropertyInfo p;
            foreach (var prop in sourceProps)
            {
                if ((p = destinationProps.SingleOrDefault(q => q.Name == prop.Name)) != null)
                {
                    p.SetValue(destination, prop.GetValue(source, null));
                }
            }

            return destination;
        }
    }
}