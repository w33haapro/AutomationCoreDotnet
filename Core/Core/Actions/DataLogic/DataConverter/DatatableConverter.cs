using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;


public static class DatatableConverter
{
    public static List<T> ToList<T>(this DataTable dt)
    {
        List<T> data = new List<T>();
        foreach (DataRow row in dt.Rows)
        {
            T item = ToObject<T>(row);
            data.Add(item);
        }
        return data;
    }

    public static T ToObject<T>(this DataRow dr)
    {
        Type temp = typeof(T);
        T obj = Activator.CreateInstance<T>();

        foreach (DataColumn column in dr.Table.Columns)
        {
            foreach (PropertyInfo pro in temp.GetProperties())
            {
                if (pro.Name == column.ColumnName)
                    pro.SetValue(obj, dr[column.ColumnName], null);
                else
                    continue;
            }
        }
        return obj;
    }
}
