﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace qlkdst.Tools
{
    public static class EntityToTable
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> entityList) where T : class
        {
            try
            {
                var properties = typeof(T).GetProperties();
                var table = new DataTable();

                foreach (var property in properties)
                {
                    var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    table.Columns.Add(property.Name, type);
                }
                foreach (var entity in entityList)
                {
                    table.Rows.Add(properties.Select(p => p.GetValue(entity, null)).ToArray());
                }
                return table;
            }
            catch
            {
                return null;
            }
        }



        //internal static DataTable ToDataTable(int result)
        //{
        //    throw new NotImplementedException();
        //}
    }

}