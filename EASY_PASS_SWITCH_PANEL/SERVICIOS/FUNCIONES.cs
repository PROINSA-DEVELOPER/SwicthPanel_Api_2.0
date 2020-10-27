using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

namespace EASY_PASS_SWITCH_PANEL.SERVICIOS
{
    static class FUNCIONES
    {


        /// <summary>
        /// Esta funcion no admite columnas que permitan valores nulos
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<TSource>(IEnumerable<TSource> source)
        {
            var props = typeof(TSource).GetProperties();

            var dt = new DataTable("DataTable");
            dt.Columns.AddRange(
                props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray()
            );

            source.ToList().ForEach(
              i => dt.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );

            return dt;
        }


        /// <summary>
        /// Converts a Generic Var into a DataTable
        /// </summary>
        /// <param name="list">enumberable</param>
        /// <param name="type">IEnumerable<T></param>
        /// <returns>DataTable </returns>
        /// 
        public static DataTable AsDataTable<T>(this IEnumerable<T> enumberable)
        {
            DataTable table = new DataTable("Generated");

            T first = enumberable.FirstOrDefault();

            if (first == null)
                return table;


            // Get a list of all the properties on the object
            PropertyInfo[] properties = first.GetType().GetProperties();


            // Loop through each property, and add it as a column to the datatable
            foreach (PropertyInfo pi in properties)
            {
                // The the type of the property
                Type columnType = pi.PropertyType;

                // We need to check whether the property is NULLABLE
                if (pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    // If it is NULLABLE, then get the underlying type. eg if "Nullable<int>" then this will return just "int"
                    columnType = pi.PropertyType.GetGenericArguments()[0];
                }

                table.Columns.Add(new DataColumn(pi.Name, columnType));
            }


            // For each object in the enumberable list, loop through and add the data to the datatable.
            foreach (T t in enumberable)
            {
                DataRow row = table.NewRow();
                foreach (PropertyInfo pi in properties)
                    row[pi.Name] = t.GetType().InvokeMember(pi.Name, BindingFlags.GetProperty, null, t, null);
                table.Rows.Add(row);
            }

            return table;
        }


    }
}
