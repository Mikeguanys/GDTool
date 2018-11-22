using GDateBase2v.Enums;
using GDateBase2v.GDTools;
using GDateBase2v.Interface;
using GDAttributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GDateBase2v.SQLServer
{
    public class SQLServerBSHelper : SQLServerBasis, SQLGDMethodInterface
    {
        private const SQLEnum.DataBaseType BaseType = SQLEnum.DataBaseType.SqlServer;
        /// <summary>
        /// 
        /// </summary>
        public SQLServerBSHelper() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectinName">WebConfig连接名字</param>
        public SQLServerBSHelper(string ConnectinName) : base(ConnectinName) { }
        /// <summary>
        /// 添加并返回自增Id
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="Model">实体</param>
        /// <returns>自增Id</returns>
        public int GDAddGetId<T>(T Model) where T : new()
        {
            SQLPropertyInfo PropertyInfos = new SQLPropertyInfo();
            List<GDModel.SQLModel> ListParameter = PropertyInfos.GDGetPropertys(Model, BaseType);
            if (ListParameter == null || ListParameter.Count == 0)
            {
                return 0;
            }
            var GetColum = ListParameter.Where(w => !w.IsIncrease).Select(s => new { s.Field, s.Parameter }).ToList();
            return BsAddGetId($"insert into {typeof(T).Name}({string.Join(",", GetColum.Select(s => s.Field).ToList())}) VALUES({string.Join(",", GetColum.Select(s => "@" + s.Field).ToList())})", GetColum.Select(s => s.Parameter as SqlParameter).ToArray());

        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="Model">实体</param>
        /// <returns></returns>
        public bool GDAdd<T>(T Model) where T : new()
        {
            SQLPropertyInfo PropertyInfos = new SQLPropertyInfo();
            List<GDModel.SQLModel> ListParameter = PropertyInfos.GDGetPropertys(Model, BaseType);
            if (ListParameter == null || ListParameter.Count == 0)
            {
                return false;
            }
            var GetColum = ListParameter.Where(w => !w.IsIncrease).Select(s => new { s.Field, s.Parameter }).ToList();
            return BsExecute($"insert into {typeof(T).Name}({string.Join(",", GetColum.Select(s => s.Field).ToList())}) VALUES({string.Join(",", GetColum.Select(s => "@" + s.Field).ToList())})", GetColum.Select(s => s.Parameter as SqlParameter).ToArray());
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public bool GDAddBatch<T>(List<T> ListModel) where T : new()
        {
            List<string> ListValue = new List<string>();
            List<SqlParameter> ListObject = new List<SqlParameter>();
            List<GDModel.SQLModel> ListParameter = null;
            int n = 0;
            int c = ListModel.Count;
            foreach (var item in ListModel)
            {
                SQLPropertyInfo PropertyInfos = new SQLPropertyInfo();
                ListParameter = PropertyInfos.GDGetPropertys(item, BaseType, n);
                if (ListParameter == null || ListParameter.Count == 0)
                {
                    return false;
                }
                ListParameter = ListParameter.Where(w => !w.IsIncrease).ToList();
                string[] valuestr = new string[ListParameter.Count];
                for (int i = 0; i < valuestr.Length; i++)
                {
                    valuestr[i] = ListParameter[i].ParameterName;
                    ListObject.Add(ListParameter[i].Parameter as SqlParameter);
                }
                ListValue.Add($"({string.Join(",", valuestr)})");
                n++;
            }
            return BsExecute($"insert into {typeof(T).Name}({string.Join(",", ListParameter.Select(s => s.Field).ToList())}) values {string.Join(",", ListValue)}", c, ListObject.ToArray());
        }
        /// <summary>
        /// 更新操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <param name="Exp"></param>
        /// <returns></returns>
        public bool GDUpdate<T>(T Model, Expression<Func<T, bool>> Exp = null) where T : new()
        {
            string Where = Exp.DealExpress();
            Where = string.IsNullOrEmpty(Where) ? "" : (" and " + Where);
            SQLPropertyInfo PropertyInfos = new SQLPropertyInfo();
            List<GDModel.SQLModel> ListParameter = PropertyInfos.GDGetPropertys(Model, BaseType);
            var GetColum = ListParameter.Where(w => !w.IsKey).Select(s => new { Field = (s.Field + "=" + s.ParameterName), Parameter = s.Parameter }).ToList();
            return BsExecute($"UPDATE {typeof(T).Name} SET {string.Join(",", GetColum.Select(s => s.Field).ToList())} where 1=1 {Where}", GetColum.Select(s => s.Parameter as SqlParameter).ToArray());
        }
        /// <summary>
        /// 根据Key更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <param name="Exp"></param>
        /// <returns></returns>
        public bool GDUpdateByKey<T>(T Model) where T : new()
        {
            SQLPropertyInfo PropertyInfos = new SQLPropertyInfo();
            List<GDModel.SQLModel> ListParameter = PropertyInfos.GDGetPropertys(Model, BaseType);
            var Keys = ListParameter.Where(w => w.IsKey).Select(s => new { Field = s.Field, Value = s.Value }).ToList().First();
            var GetColum = ListParameter.Where(w => !w.IsKey).Select(s => new { Field = (s.Field + "=" + s.ParameterName), Parameter = s.Parameter }).ToList();
            return BsExecute($"UPDATE {typeof(T).Name} SET {string.Join(",", GetColum.Select(s => s.Field).ToList())} where {Keys.Field + "=" + Keys.Value}", GetColum.Select(s => s.Parameter as SqlParameter).ToArray());
        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <param name="Exp"></param>
        /// <returns></returns>
        public bool GDelete<T>(T Model, Expression<Func<T, bool>> Exp = null) where T : new()
        {
            string Where = Exp.DealExpress();
            Where = string.IsNullOrEmpty(Where) ? "" : (" and " + Where);
            return BsExecute($"DELETE FROM {typeof(T).Name} WHERE 1=1 {Where}");
        }
        /// <summary>
        /// 根据Key删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public bool GDeleteByKey<T>(T Model) where T : new()
        {
            SQLPropertyInfo PropertyInfos = new SQLPropertyInfo();
            List<GDModel.SQLModel> ListParameter = PropertyInfos.GDGetPropertys(Model, BaseType);
            var Keys = ListParameter.Where(w => w.IsKey).Select(s => new { Field = s.Field, Value = s.Value }).ToList().First();
            return BsExecute($"DELETE FROM {typeof(T).Name} WHERE {Keys.Field + "=" + Keys.Value.ToValStr()}");
        }
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public T GDInfo<T>(T Model, Expression<Func<T, bool>> Exp = null) where T : new()
        {
            T t = new T();
            string Where = Exp.DealExpress();
            Where = string.IsNullOrEmpty(Where) ? "" : (" and " + Where);
            SQLPropertyInfo PropertyInfos = new SQLPropertyInfo();
            List<GDModel.SQLModel> ListParameter = PropertyInfos.GDGetPropertys(Model, BaseType);
            DataRow dr = BsRows($"select * from {typeof(T).Name} where 1=1 {Where}");
            if (dr == null)
            {
                return t;
            }
            else
            {
                return dr.ToModel<T>();
            }
        }
        /// <summary>
        /// 获取多条数据无排序，默认排序为主键倒序
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="Source">对象</param>        
        /// <returns></returns>
        public List<T> GDList<T>(IEnumerable<T> Source) where T : new()
        {
            T t = new T();
            string Where = Source.ToString().Contains("Where") ? (Source.AsQueryable().Expression).DealExpress() : "";
            SQLPropertyInfo PropertyInfos = new SQLPropertyInfo();
            string Sort = PropertyInfos.GDGetIsIncrease(t) + " Desc";
            DataTable dt = BsDataTable($"select * from {typeof(T).Name} where 1=1 {Where} Order By {Sort}");
            return dt.ToModel<T>();
        }
        /// <summary>
        /// 获取多条数据无排序，默认排序为主键倒序
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="Source">对象</param>        
        /// <returns></returns>
        public List<T> GDList<T>(T Source, Expression<Func<T, bool>> Exp) where T : new()
        {
            T t = new T();
            string Where = Exp.DealExpress();
            SQLPropertyInfo PropertyInfos = new SQLPropertyInfo();
            string Sort = PropertyInfos.GDGetIsIncrease(t) + " Desc";
            DataTable dt = BsDataTable($"select * from {typeof(T).Name} where 1=1 {(string.IsNullOrEmpty(Where) ? "" : (" and " + Where))} Order By {Sort}");
            return dt.ToModel<T>();
        }
        /// <summary>
        /// 获取多条数据排序，默认排序为倒序
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <typeparam name="TRuslt">对象</typeparam>
        /// <param name="Source">List</param>        
        /// <param name="OrderBy">排序字段</param>
        /// <returns></returns>
        public List<T> GDList<T, TRuslt>(IEnumerable<T> Source, Expression<Func<T, TRuslt>> OrderBy) where T : new()
        {
            string Where = Source.ToString().Contains("Where") ? (Source.AsQueryable().Expression).DealExpress() : "";
            string[] Sort = OrderBy.DealExpress().Split(',');

            for (int i = 0; i < Sort.Length; i++)
            {
                Sort[i] = $" {Sort[i]} Desc";
            }
            DataTable dt = BsDataTable($"select * from {typeof(T).Name} where 1=1 {Where} ORDER BY {string.Join(",", Sort)}");
            return dt.ToModel<T>();
        }
        /// <summary>
        /// 获取多条数据排序，默认排序为倒序
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <typeparam name="TRuslt">对象</typeparam>
        /// <param name="Source">List</param>        
        /// <param name="Exp">查询条件</param>
        /// <param name="OrderBy">排序字段</param>        
        /// <returns></returns>
        public List<T> GDList<T, TRuslt>(T Source, Expression<Func<T, bool>> Exp, Expression<Func<T, TRuslt>> OrderBy) where T : new()
        {
            string Where = Exp.DealExpress();
            string[] Sort = OrderBy.DealExpress().Split(',');
            for (int i = 0; i < Sort.Length; i++)
            {
                Sort[i] = $" {Sort[i]} Desc";
            }
            DataTable dt = BsDataTable($"select * from {typeof(T).Name} where 1=1 {(string.IsNullOrEmpty(Where) ? "" : " and " + Where)} ORDER BY {string.Join(",", Sort)}");
            return dt.ToModel<T>();
        }
        /// <summary>
        /// 获取多条数据排序
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <typeparam name="TRuslt">对象</typeparam>
        /// <param name="Source">List</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="SType">排序类型</param>
        /// <returns></returns>
        public List<T> GDList<T, TRuslt>(IEnumerable<T> Source, Expression<Func<T, TRuslt>> OrderBy, SQLEnum.SortType SType) where T : new()
        {
            string Where = Source.ToString().Contains("Where") ? (Source.AsQueryable().Expression).DealExpress() : "";
            string[] Sort = OrderBy.DealExpress().Split(',');
            for (int i = 0; i < Sort.Length; i++)
            {
                Sort[i] = $" {Sort[i]} {Enum.GetName(typeof(SQLEnum.SortType), SType)}";
            }
            DataTable dt = BsDataTable($"select * from {typeof(T).Name} where 1=1 {Where} ORDER BY {string.Join(",", Sort)}");
            return dt.ToModel<T>();
        }
        /// <summary>
        /// 获取多条数据排序
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <typeparam name="TRuslt">对象</typeparam>
        /// <param name="Source">List</param>
        /// <param name="Exp">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="SType">排序类型</param>
        /// <returns></returns>
        public List<T> GDList<T, TRuslt>(T Source, Expression<Func<T, bool>> Exp, Expression<Func<T, TRuslt>> OrderBy, SQLEnum.SortType SType) where T : new()
        {
            string Where = Exp.DealExpress();
            string[] Sort = OrderBy.DealExpress().Split(',');
            for (int i = 0; i < Sort.Length; i++)
            {
                Sort[i] = $" {Sort[i]} {Enum.GetName(typeof(SQLEnum.SortType), SType)}";
            }
            DataTable dt = BsDataTable($"select * from {typeof(T).Name} where 1=1 {Where} ORDER BY {string.Join(",", Sort)}");
            return dt.ToModel<T>();
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">对象</typeparam>        
        /// <param name="Source">List</param> 
        /// <returns></returns>
        public GDPaging<T> GDPaging<T>(IEnumerable<T> Source, int ThisPage = 1, int PageSize = 10) where T : new()
        {
            T t = new T();
            string Where = Source.ToString().Contains("Where") ? (Source.AsQueryable().Expression).DealExpress() : "";
            SQLPropertyInfo PropertyInfos = new SQLPropertyInfo();
            string Sort = PropertyInfos.GDGetIsIncrease(t) + " Desc";
            GDPaging<T> GDModel = new GDPaging<T>();
            List<T> lt = new List<T>();
            SqlParameter[] parameter =
            {
               new SqlParameter("@ThisPage",ThisPage),
               new SqlParameter("@PageSize",PageSize),
               new SqlParameter("@TableName",typeof(T).Name),
               new SqlParameter("@Condition",Where),
               new SqlParameter("@Sorting",Sort)
            };
            DataSet ds = BsStorageDs("GT_Paging", parameter);
            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                GDModel.GDModel = new List<T>();
                return GDModel;
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lt.Add(ds.Tables[0].Rows[i].ToModel<T>());
                }
                GDModel.GDModel = lt;
                GDModel.Count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            }
            return GDModel;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">对象</typeparam>        
        /// <param name="Source">List</param> 
        /// <param name="Exp">查询条件</param> 
        /// <returns></returns>
        public GDPaging<T> GDPaging<T>(T Source, Expression<Func<T, bool>> Exp, int ThisPage = 1, int PageSize = 10) where T : new()
        {
            T t = new T();
            string Where = Exp.DealExpress();
            SQLPropertyInfo PropertyInfos = new SQLPropertyInfo();
            string Sort = PropertyInfos.GDGetIsIncrease(t) + " Desc";
            GDPaging<T> GDModel = new GDPaging<T>();
            List<T> lt = new List<T>();
            SqlParameter[] parameter =
            {
               new SqlParameter("@ThisPage",ThisPage),
               new SqlParameter("@PageSize",PageSize),
               new SqlParameter("@TableName",typeof(T).Name),
               new SqlParameter("@Condition",string.IsNullOrEmpty(Where)?"":(" and "+Where)),
               new SqlParameter("@Sorting",Sort)
            };
            DataSet ds = BsStorageDs("GT_Paging", parameter);
            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                GDModel.GDModel = new List<T>();
                return GDModel;
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lt.Add(ds.Tables[0].Rows[i].ToModel<T>());
                }
                GDModel.GDModel = lt;
                GDModel.Count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            }
            return GDModel;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <typeparam name="TRuslt">对象</typeparam>
        /// <param name="Source">List</param>        
        /// <param name="OrderBy">排序</param>
        /// <param name="ThisPage">当前页</param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public GDPaging<T> GDPaging<T, TRuslt>(IEnumerable<T> Source, Expression<Func<T, TRuslt>> OrderBy, int ThisPage = 1, int PageSize = 10) where T : new()
        {
            string Where = Source.ToString().Contains("Where") ? (Source.AsQueryable().Expression).DealExpress() : "";
            string[] Sort = OrderBy.DealExpress().Split(',');
            for (int i = 0; i < Sort.Length; i++)
            {
                Sort[i] = $" {Sort[i]} Desc";
            }
            GDPaging<T> GDModel = new GDPaging<T>();
            List<T> lt = new List<T>();
            SqlParameter[] parameter =
            {
               new SqlParameter("@ThisPage",ThisPage),
               new SqlParameter("@PageSize",PageSize),
               new SqlParameter("@TableName",typeof(T).Name),
               new SqlParameter("@Condition",Where),
               new SqlParameter("@Sorting",string.Join(",",Sort))
            };
            DataSet ds = BsStorageDs("GT_Paging", parameter);
            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                GDModel.GDModel = new List<T>();
                return GDModel;
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lt.Add(ds.Tables[0].Rows[i].ToModel<T>());
                }
                GDModel.GDModel = lt;
                GDModel.Count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            }
            return GDModel;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <typeparam name="TRuslt">对象</typeparam>
        /// <param name="Source">List</param>     
        /// <param name="Exp">查询条件</param>    
        /// <param name="OrderBy">排序</param>
        /// <param name="ThisPage">当前页</param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public GDPaging<T> GDPaging<T, TRuslt>(T Source, Expression<Func<T, bool>> Exp, Expression<Func<T, TRuslt>> OrderBy, int ThisPage = 1, int PageSize = 10) where T : new()
        {
            string Where = Exp.DealExpress();
            string[] Sort = OrderBy.DealExpress().Split(',');
            for (int i = 0; i < Sort.Length; i++)
            {
                Sort[i] = $" {Sort[i]} Desc";
            }
            GDPaging<T> GDModel = new GDPaging<T>();
            List<T> lt = new List<T>();
            SqlParameter[] parameter =
            {
               new SqlParameter("@ThisPage",ThisPage),
               new SqlParameter("@PageSize",PageSize),
               new SqlParameter("@TableName",typeof(T).Name),
               new SqlParameter("@Condition",string.IsNullOrEmpty(Where)?"":(" and "+Where)),
               new SqlParameter("@Sorting",string.Join(",",Sort))
            };
            DataSet ds = BsStorageDs("GT_Paging", parameter);
            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                GDModel.GDModel = new List<T>();
                return GDModel;
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lt.Add(ds.Tables[0].Rows[i].ToModel<T>());
                }
                GDModel.GDModel = lt;
                GDModel.Count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            }
            return GDModel;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <typeparam name="TRuslt">对象</typeparam>
        /// <param name="Source">List</param>
        /// <param name="OrderBy">排序字段</param>
        /// <param name="SType">排序类型</param>      
        /// <param name="ThisPage"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public GDPaging<T> GDPaging<T, TRuslt>(IEnumerable<T> Source, Expression<Func<T, TRuslt>> OrderBy, SQLEnum.SortType SType, int ThisPage = 1, int PageSize = 10) where T : new()
        {
            string Where = Source.ToString().Contains("Where") ? (Source.AsQueryable().Expression).DealExpress() : "";
            string[] Sort = OrderBy.DealExpress().Split(',');
            for (int i = 0; i < Sort.Length; i++)
            {
                Sort[i] = $" {Sort[i]} {Enum.GetName(typeof(SQLEnum.SortType), SType)}";
            }
            GDPaging<T> GDModel = new GDPaging<T>();
            List<T> lt = new List<T>();
            SqlParameter[] parameter =
            {
               new SqlParameter("@ThisPage",ThisPage),
               new SqlParameter("@PageSize",PageSize),
               new SqlParameter("@TableName",typeof(T).Name),
               new SqlParameter("@Condition",Where),
               new SqlParameter("@Sorting",string.Join(",",Sort))
            };
            DataSet ds = BsStorageDs("GT_Paging", parameter);
            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                GDModel.GDModel = new List<T>();
                return GDModel;
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lt.Add(ds.Tables[0].Rows[i].ToModel<T>());
                }
                GDModel.GDModel = lt;
                GDModel.Count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            }
            return GDModel;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <typeparam name="TRuslt">对象</typeparam>
        /// <param name="Source">List</param>
        /// <param name="Exp">查询条件</param>
        /// <param name="OrderBy">排序字段</param>
        /// <param name="SType">排序类型</param>      
        /// <param name="ThisPage"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public GDPaging<T> GDPaging<T, TRuslt>(T Source, Expression<Func<T, bool>> Exp, Expression<Func<T, TRuslt>> OrderBy, SQLEnum.SortType SType, int ThisPage = 1, int PageSize = 10) where T : new()
        {
            string Where = Exp.DealExpress();
            string[] Sort = OrderBy.DealExpress().Split(',');
            for (int i = 0; i < Sort.Length; i++)
            {
                Sort[i] = $" {Sort[i]} {Enum.GetName(typeof(SQLEnum.SortType), SType)}";
            }
            GDPaging<T> GDModel = new GDPaging<T>();
            List<T> lt = new List<T>();
            SqlParameter[] parameter =
            {
               new SqlParameter("@ThisPage",ThisPage),
               new SqlParameter("@PageSize",PageSize),
               new SqlParameter("@TableName",typeof(T).Name),
               new SqlParameter("@Condition",(string.IsNullOrEmpty(Where)?"":(" and "+Where))),
               new SqlParameter("@Sorting",string.Join(",",Sort))
            };
            DataSet ds = BsStorageDs("GT_Paging", parameter);
            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                GDModel.GDModel = new List<T>();
                return GDModel;
            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lt.Add(ds.Tables[0].Rows[i].ToModel<T>());
                }
                GDModel.GDModel = lt;
                GDModel.Count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            }
            return GDModel;
        }
        ////////////////////////////////查询多个表Start///////////////////////////        
        /// <summary>
        /// 查询多个表;
        /// </summary>
        /// <param>调用：var f= objc[0].As<!--实体-->()</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<List<object>> GDMergerSearch(params object[] obj)
        {

            List<List<object>> objlist = new List<List<object>>();
            List<GDModel.MergerModel> ListSQLStr = new List<GDModel.MergerModel>();
            foreach (var item in obj)
            {
                ListSQLStr.Add((item as GDModel.MergerModel));
            }
            DataSet r = BsDataSet(string.Join(";", ListSQLStr.Select(s => s.SQLStr).ToArray()));

            for (int i = 0; i < ListSQLStr.Count; i++)
            {
                List<object> listable = new List<object>();
                for (int j = 0; j < r.Tables[i].Rows.Count; j++)
                {
                    listable.Add(r.Tables[i].Rows[j].ToModel(ListSQLStr[i].Entity));
                }
                objlist.Add(listable);
            }
            return objlist;
        }
        /// <summary>
        /// 执行多个表操作
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool GDMergerExecute(params object[] obj)
        {
            List<string> SQLStr = new List<string>();
            foreach (var item in obj)
            {
                SQLStr.Add((item as GDModel.MergerModel).SQLStr);
            }

            return BsExecute(string.Join(";", SQLStr));
        }
        /// <summary>
        /// 条件
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t"></param>        
        /// <param name="Exp">条件</param>
        /// <param name="Sort">排序</param>
        /// <returns></returns>
        public GDModel.MergerModel GDCodition<T, TRuslt>(T t, Expression<Func<T, bool>> Exp = null, Expression<Func<T, TRuslt>> OrderBy = null, SQLEnum.SortType SType = SQLEnum.SortType.Desc) where T : new()
        {
            string TableName = typeof(T).Name;
            string Where = Exp.DealExpress();
            string Sort = $" {OrderBy.DealExpress()} {Enum.GetName(typeof(SQLEnum.SortType), SType)}";
            Where = $"select * from {TableName} where 1=1 " + (string.IsNullOrEmpty(Where) ? "" : (" and " + Where)) + (string.IsNullOrEmpty(Sort) ? "" : (" Order By " + Sort));
            return new GDModel.MergerModel() { SQLStr = Where, Entity = t, EntityName = TableName };
        }
        /// <summary>
        /// 条件
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t"></param>
        /// <param name="OperType">操作类型</param>
        /// <param name="Exp">条件</param> 
        /// <param name="Sort">排序</param>
        /// <returns></returns>
        public GDModel.MergerModel GDCodition<T>(T t, SQLEnum.OperationType OperType, Expression<Func<T, bool>> Exp = null) where T : new()
        {
            PropertyInfo[] propertys = t.GetType().GetProperties();
            string SQLStr = string.Empty;
            string Where = (Exp == null ? "" : Exp.DealExpress());
            string TableName = typeof(T).Name;
            if (OperType == SQLEnum.OperationType.Add || OperType == SQLEnum.OperationType.Update)
            {
                List<string> FileName = new List<string>();
                List<string> Value = new List<string>();
                string DbValue = string.Empty;
                foreach (PropertyInfo pi in propertys)
                {
                    GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
                    if (objAttrs != null && !objAttrs.IsKey)
                    {
                        object obj = pi.GetValue(t, null);
                        if (obj != null)
                        {
                            if (OperType == SQLEnum.OperationType.Add)
                            {
                                FileName.Add(pi.Name);
                                Value.Add(pi.GetValue(t, null).ToValStr());
                            }
                            else
                            {
                                FileName.Add($"{pi.Name}={pi.GetValue(t, null).ToValStr()}");
                            }
                        }
                    }
                }
                if (OperType == SQLEnum.OperationType.Add)
                {
                    SQLStr = $"INSERT INTO {TableName}({string.Join(",", FileName)}) values({string.Join(",", Value)})";
                }
                else
                {
                    SQLStr = $"UPDATE {TableName} set {string.Join(",", FileName)} where 1=1" + (string.IsNullOrEmpty(Where) ? "" : " and " + Where);
                }
            }
            else
            {
                SQLStr = $"DELETE FROM {TableName} where 1=1 {Where}";
            }
            return new GDModel.MergerModel() { SQLStr = SQLStr, Entity = t };
        }
        /// <summary>
        /// 转成其他实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ojbc"></param>
        /// <returns></returns>
        public List<T> As<T>(List<object> ojbc)
        {
            return ojbc.Cast<T>().ToList();
        }
        ////////////////////////////////查询多个表End/////////////////////////////
    }
}