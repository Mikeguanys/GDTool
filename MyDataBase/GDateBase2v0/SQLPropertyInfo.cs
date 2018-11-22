using GDateBase2v.Enums;
using GDateBase2v.GDTools;
using GDAttributes;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Reflection;

namespace GDateBase2v
{
    public class SQLPropertyInfo
    {
        public List<GDModel.SQLModel> GDGetPropertys<T>(T Model, SQLEnum.DataBaseType Type)
        {
            List<GDModel.SQLModel> ListParameter = new List<GDModel.SQLModel>();
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
                if (objAttrs != null)
                {
                    GDModel.SQLModel sqlmodel = new GDModel.SQLModel();
                    object obj = pi.GetValue(Model, null);
                    if (obj != null)
                    {
                        object o = null;
                        switch (Type)
                        {
                            case SQLEnum.DataBaseType.SqlServer:
                                o = new SqlParameter("@" + pi.Name, obj);
                                break;
                            case SQLEnum.DataBaseType.MySql:
                                o = new MySqlParameter("@" + pi.Name, obj);
                                break;
                            case SQLEnum.DataBaseType.Sqlite:
                                o = new SQLiteParameter("@" + pi.Name, obj);
                                break;
                            default:
                                break;
                        }
                        ListParameter.Add(new GDModel.SQLModel()
                        {
                            Field = pi.Name,
                            Value = obj,
                            ValueStr = obj.ToValStr(),
                            Parameter = o,
                            ParameterName = "@" + pi.Name,
                            IsKey = objAttrs.IsKey,
                            IsIncrease = (objAttrs.IsKey && objAttrs.IsIncrease)
                        });
                    }
                }
            }
            return ListParameter;
        }
        /// <summary>
        /// 存在多条数据的Parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <param name="Type"></param>
        /// <param name="编号"></param>
        /// <returns></returns>
        public List<GDModel.SQLModel> GDGetPropertys<T>(T Model, SQLEnum.DataBaseType Type, int Nums)
        {
            List<GDModel.SQLModel> ListParameter = new List<GDModel.SQLModel>();
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
                if (objAttrs != null)
                {
                    GDModel.SQLModel sqlmodel = new GDModel.SQLModel();
                    object obj = pi.GetValue(Model, null);
                    if (obj != null)
                    {
                        object o = null;
                        switch (Type)
                        {
                            case SQLEnum.DataBaseType.SqlServer:
                                o = new SqlParameter("@" + pi.Name + Nums, obj);
                                break;
                            case SQLEnum.DataBaseType.MySql:
                                o = new MySqlParameter("@" + pi.Name + Nums, obj);
                                break;
                            case SQLEnum.DataBaseType.Sqlite:
                                o = new SQLiteParameter("@" + pi.Name + Nums, obj);
                                break;
                            default:
                                break;
                        }
                        ListParameter.Add(new GDModel.SQLModel()
                        {
                            Field = pi.Name,
                            Value = obj,
                            ValueStr = obj.ToValStr(),
                            Parameter = o,
                            ParameterName = "@" + pi.Name + Nums,
                            IsKey = objAttrs.IsKey,
                            IsIncrease = (objAttrs.IsKey && objAttrs.IsIncrease)
                        });
                    }
                }
            }
            return ListParameter;
        }
        /// <summary>
        /// 获取主键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public string GDGetIsIncrease<T>(T Model)
        {
            string Keys = string.Empty;
            PropertyInfo[] propertys = Model.GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
                if (objAttrs.IsKey)
                {
                    Keys = pi.Name;
                    continue;
                }
            }
            return Keys;
        }
    }
}
