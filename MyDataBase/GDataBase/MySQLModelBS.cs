using GDAttributes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace GDataBase
{
    /// <summary>
    /// Base升级方法
    /// </summary>
    public static class MySQLModelBS
    {
        /// <summary>
        /// 泛型查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static List<T> MySQLGTMListByParameter<T>(this T Model) where T : new()
        {
            MySQLDBHeper Helper = new MySQLDBHeper();
            List<T> lt = new List<T>();
            List<MySqlParameter> Parameter = new List<MySqlParameter>();
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            string ModelName = Model.GetType().Name;
            List<string> Condition = new List<string>();
            string DbValue = string.Empty;
            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();

                if (objAttrs != null)
                {

                    object obj = pi.GetValue(Model, null);
                    if (obj == null)
                    {
                        DbValue = "''";
                    }
                    else
                    {
                        DbValue = obj.DbTypeStr();
                    }

                    Parameter.Add(new MySqlParameter("@" + pi.Name, DbValue));
                    Condition.Add("and " + pi.Name + "=@" + pi.Name);
                }
            }

            DataTable dt = Helper.BsGetDataTable("select * from " + ModelName + " where 1=1 " + string.Join(" ", Condition));
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lt.Add(dt.Rows[i].ToModel<T>());
                }
            }
            return lt;
        }
        /// <summary>
        /// 泛型查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model">泛型对象</param>
        /// <returns></returns>
        public static List<T> MySQLGTMSearchList<T>(this T Model) where T : new()
        {
            MySQLDBHeper Helper = new MySQLDBHeper();
            List<T> lt = new List<T>();
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            string ModelName = Model.GetType().Name;
            List<string> Condition = new List<string>();
            string DbValue = string.Empty;
            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();

                if (objAttrs != null)
                {
                    object obj = pi.GetValue(Model, null);
                    if (obj == null)
                    {
                        DbValue = "''";
                    }
                    else
                    {
                        DbValue = obj.DbTypeStr();
                    }
                    Condition.Add("and " + pi.Name + "=" + DbValue);
                }
            }

            DataTable dt = Helper.BsGetDataTable("select * from " + ModelName + " where 1=1 " + string.Join(" ", Condition));
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lt.Add(dt.Rows[i].ToModel<T>());
                }
            }
            return lt;
        }
        /// <summary>
        /// 查询Parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model">泛型对象</param>
        /// <returns></returns>
        public static T MySQLGTMInfoByParameter<T>(this T Model) where T : new()
        {
            MySQLDBHeper Helper = new MySQLDBHeper();
            T t = new T();
            List<MySqlParameter> Parameter = new List<MySqlParameter>();
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            string ModelName = Model.GetType().Name;
            List<string> Condition = new List<string>();
            string DbValue = string.Empty;
            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();

                if (objAttrs != null)
                {
                    object obj = pi.GetValue(Model, null);
                    if (obj == null)
                    {
                        DbValue = "''";
                    }
                    else
                    {
                        DbValue = obj.DbTypeStr();
                    }
                    Parameter.Add(new MySqlParameter("@" + pi.Name, DbValue));
                    Condition.Add("and " + pi.Name + "=@" + pi.Name);
                }
            }
            DataRow dr = Helper.BsGetDataReader("select * from " + ModelName + " where 1=1 " + string.Join(" ", Condition), Parameter.ToArray());
            if (dr == null)
            {
                return default(T);
            }
            return dr.ToModel<T>();
        }
        /// <summary>
        /// 泛型约束查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model">泛型对象</param>
        /// <returns></returns>
        public static T MySQLGTMSearch<T>(this T Model) where T : new()
        {
            MySQLDBHeper Helper = new MySQLDBHeper();
            T t = new T();
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            string ModelName = Model.GetType().Name;
            string DbValue = string.Empty;
            List<string> Condition = new List<string>();

            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
                if (objAttrs != null)
                {

                    object obj = pi.GetValue(Model, null);
                    if (obj == null)
                    {
                        DbValue = "''";
                    }
                    else
                    {
                        DbValue = obj.DbTypeStr();
                    }
                    Condition.Add("and " + pi.Name + "=" + DbValue);
                }
            }

            DataRow dr = Helper.BsGetDataReader("select * from " + ModelName + " where 1=1 " + string.Join(" ", Condition));
            if (dr == null)
            {
                return default(T);
            }

            return dr.ToModel<T>();
        }
        /// <summary>
        /// 根据条件进行删除
        /// </summary>
        /// <typeparam name="T">对象名称</typeparam>
        /// <param name="Model">对象</param>
        /// <param name="DelCondition">需要删除条件的字段</param>
        /// <returns></returns>
        public static bool MySQLDeleteByConditon<T>(this T Model, string[] DelCondition) where T : new()
        {
            MySQLDBHeper Helper = new MySQLDBHeper();
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            string ModelName = Model.GetType().Name;
            List<string> Condition = new List<string>();
            string DbValue = string.Empty;

            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();

                if (objAttrs != null)
                {
                    string Colums = DelCondition.Where(w => w == pi.Name).First();
                    if (!string.IsNullOrEmpty(Colums))
                    {
                        object obj = pi.GetValue(Model, null);
                        if (obj == null)
                        {
                            DbValue = "''";
                        }
                        else
                        {
                            DbValue = obj.DbTypeStr();
                        }
                        Condition.Add("and " + pi.Name + "=" + DbValue);
                    }

                }
            }
            return Helper.Delete(string.Join(" ", Condition), ModelName);
        }
        /// <summary>
        /// 根据主键进行删除
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="Model">对象</param>        
        /// <returns></returns>
        public static bool MySQLDelete<T>(this T Model) where T : new()
        {
            MySQLDBHeper Helper = new MySQLDBHeper();
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            string ModelName = Model.GetType().Name;
            string KeyStr = " and 1=2";
            string DbValue = string.Empty;
            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
                if (objAttrs != null)
                {
                    if (objAttrs.IsKey)
                    {
                        object obj = pi.GetValue(Model, null);
                        if (obj == null)
                        {
                            DbValue = "''";
                        }
                        else
                        {
                            DbValue = obj.DbTypeStr();
                        }
                        KeyStr = " and " + pi.Name + "=" + DbValue;
                        break;
                    }
                }
            }
            return Helper.Delete(KeyStr, ModelName);
        }
        /// <summary>
        /// 根据主键进行更新
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="Model">对象</param>        
        /// <returns></returns>
        public static bool MySQLUpdate<T>(this T Model) where T : new()
        {
            MySQLDBHeper Helper = new MySQLDBHeper();
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            string ModelName = Model.GetType().Name;
            string KeyStr = string.Empty;
            string DbValue = string.Empty;
            List<string> FileName = new List<string>();
            bool r = true;
            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
                if (objAttrs == null)
                    r = false;
                else
                {
                    r = true;// objAttrs.IsUpdate;
                    if (objAttrs.IsKey)
                    {
                        object obj = pi.GetValue(Model, null);
                        if (obj == null)
                        {
                            DbValue = "''";
                        }
                        else
                        {
                            DbValue = obj.DbTypeStr();
                        }
                        KeyStr = " and " + pi.Name + "=" + DbValue;
                    }
                }

                if (r)
                {
                    FileName.Add(pi.Name + "=" + DbValue);
                }
            }
            return Helper.Update(string.Join(",", FileName), KeyStr, ModelName);
        }
        /// <summary>
        /// 根据条件进行更新
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="Model">对象</param>
        /// <param name="UpCondition">更新条件</param>
        /// <returns></returns>
        public static bool MySQLUpdateByCondition<T>(this T Model, string UpCondition) where T : new()
        {
            MySQLDBHeper Helper = new MySQLDBHeper();
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            string ModelName = Model.GetType().Name;
            string DbValue = string.Empty;
            List<string> FileName = new List<string>();
            bool r = true;
            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
                if (objAttrs == null)
                    r = false;
                else
                    r = true;// objAttrs.IsUpdate;
                if (r)
                {
                    object obj = pi.GetValue(Model, null);
                    if (obj == null)
                    {
                        DbValue = "''";
                    }
                    else
                    {
                        DbValue = obj.DbTypeStr();
                    }
                    FileName.Add(pi.Name + "=" + DbValue);
                }
            }
            return Helper.Update(string.Join(",", FileName), UpCondition, ModelName);
        }
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static bool MySQLListAdd<T>(this List<T> Model) where T : new()
        {
            MySQLDBHeper Helper = new MySQLDBHeper();
            bool r = true;
            List<string> Listr = new List<string>();
            string ModelName = string.Empty;
            string ColumName = string.Empty;
            string DbValue = string.Empty;
            foreach (T item in Model)
            {
                PropertyInfo[] propertys = item.GetType().GetProperties();
                ModelName = item.GetType().Name;
                List<string> FileName = new List<string>();
                List<string> Value = new List<string>();
                foreach (PropertyInfo pi in propertys)
                {
                    GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
                    if (objAttrs == null)
                        r = false;
                    else
                        r = true;// objAttrs.IsAdd;
                    if (r)
                    {
                        object obj = pi.GetValue(Model, null);
                        if (obj == null)
                        {
                            DbValue = "''";
                        }
                        else
                        {
                            DbValue = obj.DbTypeStr();
                        }
                        FileName.Add(pi.Name);
                        Value.Add(DbValue);
                    }
                }
                ColumName = string.Join(",", FileName);
                Listr.Add("(" + string.Join(",", Value) + ")");
            }
            return Helper.MoreAdd(ColumName, string.Join(",", Listr), ModelName);
        }
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static bool MySQLAdd<T>(this T Model) where T : new()
        {
            MySQLDBHeper Helper = new MySQLDBHeper();
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            string ModelName = Model.GetType().Name;
            string DbValue = string.Empty;
            List<string> FileName = new List<string>();
            List<string> Value = new List<string>();
            bool r = true;
            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
                if (objAttrs == null)
                    r = false;
                else
                    r = true;// objAttrs.IsAdd;
                if (r)
                {
                    object obj = pi.GetValue(Model, null);
                    if (obj == null)
                    {
                        DbValue = "''";
                    }
                    else
                    {
                        DbValue = obj.DbTypeStr();
                    }
                    FileName.Add(pi.Name);
                    Value.Add(DbValue);
                }
            }
            return Helper.Add(string.Join(",", FileName), string.Join(",", Value), ModelName);
        }
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static bool MySQLAddByParameter<T>(this T Model) where T : class
        {
            MySQLDBHeper Helper = new MySQLDBHeper();
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            string tyu = Model.GetType().Name;

            List<MySqlParameter> ListParameter = new List<MySqlParameter>();
            List<string> FileName = new List<string>();
            List<string> Value = new List<string>();
            bool r = true;
            string DbValue = string.Empty;
            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
                if (objAttrs == null)
                    r = false;
                else
                    r = true;// objAttrs.IsAdd;
                if (r)
                {
                    object obj = pi.GetValue(Model, null);
                    if (obj == null)
                    {
                        DbValue = "''";
                    }
                    else
                    {
                        DbValue = obj.DbTypeStr();
                    }
                    FileName.Add(pi.Name);
                    Value.Add("@" + pi.Name);
                    ListParameter.Add(new MySqlParameter("@" + pi.Name, DbValue));
                }
            }
            return Helper.Add(string.Join(",", FileName), string.Join(",", Value), Model.GetType().Name, ListParameter.ToArray());
        }
        /// <summary>
        /// 新增返回自增Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static int MySQLReturnAddId<T>(this T Model) where T : new()
        {
            MySQLDBHeper Helper = new MySQLDBHeper();
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            string ModelName = Model.GetType().Name;
            string DbValue = string.Empty;
            List<string> FileName = new List<string>();
            List<string> Value = new List<string>();
            bool r = true;
            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
                if (objAttrs == null)
                    r = false;
                else
                    r = true;// objAttrs.IsAdd;
                if (r)
                {
                    object obj = pi.GetValue(Model, null);
                    if (obj == null)
                    {
                        DbValue = "''";
                    }
                    else
                    {
                        DbValue = obj.DbTypeStr();
                    }
                    FileName.Add(pi.Name);
                    Value.Add(DbValue);
                }
            }
            return Convert.ToInt32(Helper.GetAddGetId(string.Join(",", FileName), string.Join(",", Value), ModelName));
        }
        /// <summary>
        /// 新增一条记录返回Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static int MySQLReturnAddIdByParameter<T>(this T Model) where T : new()
        {
            MySQLDBHeper Helper = new MySQLDBHeper();
            List<MySqlParameter> Parameter = new List<MySqlParameter>();
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            string ModelName = Model.GetType().Name;
            List<string> FileName = new List<string>();
            List<string> Value = new List<string>();
            bool r = true;
            string DbValue = string.Empty;
            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
                if (objAttrs == null)
                    r = false;
                else
                    r = true;// objAttrs.IsAdd;
                if (r)
                {
                    object obj = pi.GetValue(Model, null);
                    if (obj == null)
                    {
                        DbValue = "''";
                    }
                    else
                    {
                        DbValue = obj.DbTypeStr();
                    }
                    Parameter.Add(new MySqlParameter("@" + pi.Name, DbValue));
                    FileName.Add(pi.Name);
                    Value.Add("@" + pi.Name);
                }
            }
            return Convert.ToInt32(Helper.GetAddGetId(string.Join(",", FileName), string.Join(",", Value), ModelName, Parameter.ToArray()));
        }
    }
}
