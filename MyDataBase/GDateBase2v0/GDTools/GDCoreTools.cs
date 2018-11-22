using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace GDateBase2v.GDTools
{
    /// <summary>
    /// 代码工具
    /// </summary>
    public static class GDCoreTools
    {
        public static DataSet ToDataSet<T>(this List<T> ListT) where T : new()
        {
            Type elementType = typeof(T);
            var ds = new DataSet();
            var t = new DataTable(elementType.Name);
            ds.Tables.Add(t);
            elementType.GetProperties().ToList().ForEach(propInfo => t.Columns.Add(propInfo.Name, Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType));
            foreach (T item in ListT)
            {
                var row = t.NewRow();
                elementType.GetProperties().ToList().ForEach(propInfo => row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value);
                t.Rows.Add(row);
            }
            return ds;
        }
        /// <summary>
        /// 转换数据类型
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string ToValStr(this object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {
                return "";
            }
            if (Value is String)
            {
                return "'" + Value.ToString() + "'";
            }
            else if (Value is Int16)
            {
                return Value.ToString();
            }
            else if (Value is Int32)
            {
                return Value.ToString();
            }
            else if (Value is Int64)
            {
                return Value.ToString();
            }
            else if (Value is Decimal)
            {
                return Value.ToString();
            }
            else if (Value is Double)
            {
                return Value.ToString();
            }
            else if (Value is DateTime)
            {
                return "'" + Value.ToString() + "'";
            }
            else if (Value is float)
            {
                return Value.ToString();
            }
            else if (Value is Single)
            {
                return Value.ToString();
            }
            else if (Value is Enum)
            {
                return ((int)Value).ToString();
            }
            else
            {
                return "'" + Value.ToString() + "'";
            }
        }
        /// <summary>
        /// 转化成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T ToModel<T>(this DataRow row) where T : new()
        {
            T t = new T();
            PropertyInfo[] propertyinfo = t.GetType().GetProperties();
            object value;
            foreach (PropertyInfo p in propertyinfo)
            {
                if (row.Table.Columns.Contains(p.Name))
                {
                    if (row[p.Name] is DBNull)
                    {
                        p.SetValue(t, null, null);
                        continue;
                    }
                    value = row[p.Name];
                    if (value is String)
                    {
                        p.SetValue(t, Convert.ToString(value), null);
                    }
                    else if (value is Int16)
                    {
                        p.SetValue(t, Convert.ToInt32(value.ToString()), null);
                    }
                    else if (value is Int32)
                    {
                        PropertyInfo property = t.GetType().GetProperty(p.Name);
                        var properties = property.PropertyType.GetProperties();
                        if (properties.Count() <= 1)
                        {
                            if (property.PropertyType.IsEnum)
                            {
                                object enumName = Enum.ToObject(property.PropertyType, value);
                                p.SetValue(t, enumName, null);
                            }
                            else
                            {
                                p.SetValue(t, Convert.ToInt32(value), null);
                            }
                        }
                        else
                        {
                            if (properties[1].PropertyType.IsEnum)
                            {
                                object enumName = Enum.ToObject(properties[1].PropertyType, value);
                                p.SetValue(t, enumName, null);
                            }
                            else
                            {
                                p.SetValue(t, Convert.ToInt32(value), null);
                            }
                        }
                    }
                    else if (value is Int64)
                    {
                        p.SetValue(t, Convert.ToInt64(value), null);
                    }
                    else if (value is DateTime)
                    {
                        p.SetValue(t, Convert.ToDateTime(value), null);
                    }
                    else if (value is Boolean)
                    {
                        p.SetValue(t, Convert.ToBoolean(value), null);
                    }
                    else if (value is Decimal)
                    {
                        p.SetValue(t, Convert.ToDecimal(value), null);
                    }
                    else if (value is Double)
                    {
                        p.SetValue(t, Convert.ToSingle(value), null);
                    }
                    else
                    {
                        p.SetValue(t, value, null);
                    }
                }
            }
            return t;
        }
        /// <summary>
        /// 转化成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static List<T> ToModel<T>(this DataTable dt) where T : new()
        {
            T t = new T();
            List<T> tlist = new List<T>();
            foreach (DataRow item in dt.Rows)
            {
                tlist.Add(ToModel<T>(item));
            }
            return tlist;
        }
        /// <summary>
        /// 转化成实体
        /// </summary>
        /// <typeparam name="obj"></typeparam>
        /// <param name="row"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object ToModel(this DataRow row, object obj)
        {
            PropertyInfo[] propertyinfo = obj.GetType().GetProperties();
            object value;
            foreach (PropertyInfo p in propertyinfo)
            {
                if (row.Table.Columns.Contains(p.Name))
                {
                    if (row[p.Name] is DBNull)
                    {
                        p.SetValue(obj, null, null);
                        continue;
                    }
                    value = row[p.Name];
                    if (value is String)
                    {
                        p.SetValue(obj, Convert.ToString(value), null);
                    }
                    else if (value is Int16)
                    {
                        p.SetValue(obj, Convert.ToInt32(value.ToString()), null);
                    }
                    else if (value is Int32)
                    {
                        PropertyInfo property = obj.GetType().GetProperty(p.Name);
                        var properties = property.PropertyType.GetProperties();
                        if (properties.Count() <= 1)
                        {
                            if (property.PropertyType.IsEnum)
                            {
                                object enumName = Enum.ToObject(property.PropertyType, value);
                                p.SetValue(obj, enumName, null);
                            }
                            else
                            {
                                p.SetValue(obj, Convert.ToInt32(value), null);
                            }
                        }
                        else
                        {
                            if (properties[1].PropertyType.IsEnum)
                            {
                                object enumName = Enum.ToObject(properties[1].PropertyType, value);
                                p.SetValue(obj, enumName, null);
                            }
                            else
                            {
                                p.SetValue(obj, Convert.ToInt32(value), null);
                            }
                        }
                    }
                    else if (value is Int64)
                    {
                        p.SetValue(obj, Convert.ToInt64(value), null);
                    }
                    else if (value is DateTime)
                    {
                        p.SetValue(obj, Convert.ToDateTime(value), null);
                    }
                    else if (value is Boolean)
                    {
                        p.SetValue(obj, Convert.ToBoolean(value), null);
                    }
                    else if (value is Decimal)
                    {
                        p.SetValue(obj, Convert.ToDecimal(value), null);
                    }
                    else if (value is Double)
                    {
                        p.SetValue(obj, Convert.ToSingle(value), null);
                    }
                    else
                    {
                        p.SetValue(obj, value, null);
                    }
                }
            }
            return obj;
        }
    }
}
