namespace GDataBase
{
    /// <summary>
    /// SQLiteROM
    /// </summary>
    public static class SQLiteModelBS
    {
        ///// <summary>
        ///// 数据库连接类
        ///// </summary>
        ///// <param name="Connection">连接名字</param>
        ///// <returns></returns>
        //private static SQLiteDBHeper GetDBHeper(string Connection)
        //{
        //    if (string.IsNullOrEmpty(Connection))
        //    {
        //        return new SQLiteDBHeper();
        //    }
        //    else
        //    {
        //        return new SQLiteDBHeper(Connection);
        //    }
        //}
        ///// <summary>
        ///// 泛型查询默认主键排倒叙
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="Model"></param>
        ///// <param name="Condition"></param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static List<T> GTSearchCondition<T>(this T Model, string Condition, string ConnectionName = null) where T : new()
        //{
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    List<T> lt = new List<T>();
        //    PropertyInfo[] propertys = Model.GetType().GetProperties();
        //    string ModelName = Model.GetType().Name;
        //    DataTable dt = Helper.GetTable(Condition, ModelName);
        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            lt.Add(dt.Rows[i].ToModel<T>());
        //        }
        //    }
        //    return lt;
        //}
        ///// <summary>
        ///// 泛型查询默认主键排倒叙
        ///// </summary>
        ///// <typeparam name="T"></typeparam>        
        ///// <param name="source">条件</param>
        ///// <param name="Storing">排序</param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static List<T> GTSearch<T>(this IEnumerable<T> source, string Storing = null, string ConnectionName = null) where T : new()
        //{
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    List<T> lt = new List<T>();

        //    DataTable dt = Helper.GetTable((source.ToString().Contains("Where") ? (source.AsQueryable().Expression).DealExpress() : "") + " order by " + (string.IsNullOrEmpty(Storing) ? (" Id desc") : Storing), typeof(T).Name);
        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //        return lt;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            lt.Add(dt.Rows[i].ToModel<T>());
        //        }
        //    }
        //    return lt;
        //}

        ///// <summary>
        ///// 泛型查询默认主键排倒叙
        ///// </summary>
        ///// <typeparam name="T"></typeparam>   
        ///// <param name="Model">对象</param>
        ///// <param name="Exp">条件</param>
        ///// <param name="Storing">排序</param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static List<T> GTSearch<T>(this T Model, Expression<Func<T, bool>> Exp = null, string Storing = null, string ConnectionName = null) where T : new()
        //{
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    List<T> lt = new List<T>();
        //    string Condition = Exp.DealExpress();
        //    DataTable dt = Helper.GetTable(string.IsNullOrEmpty(Condition) ? "" : " and " + Condition + " order by " + (string.IsNullOrEmpty(Storing) ? (" Id desc") : Storing), typeof(T).Name);
        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //        return lt;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            lt.Add(dt.Rows[i].ToModel<T>());
        //        }
        //    }
        //    return lt;
        //}
        ///// <summary>
        ///// 分页查询
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="Model">对象</param>
        ///// <param name="ThisPage">当前页数</param>
        ///// <param name="Condition">条件</param>
        ///// <param name="Storing">排序</param>
        ///// <param name="PageSize">当前也分大小</param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static GDPaging<T> GTPagingByCondition<T>(this T Model, int ThisPage, string Condition, int PageSize = 10, string Storing = null, string ConnectionName = null) where T : new()
        //{
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    GDPaging<T> GDModel = new GDPaging<T>();
        //    List<T> lt = new List<T>();
        //    string ModelName = Model.GetType().Name;

        //    SQLiteParameter[] parameter =
        //    {
        //       new SQLiteParameter("@ThisPage",ThisPage),
        //       new SQLiteParameter("@PageSize",PageSize),
        //       new SQLiteParameter("@TableName",ModelName),
        //       new SQLiteParameter("@Condition",Condition),
        //       new SQLiteParameter("@Sorting",(string.IsNullOrEmpty(Storing)?(" Id desc"):Storing))
        //    };
        //    DataSet ds = Helper.MoreExecuteStorage("GT_Paging", parameter);
        //    if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
        //    {
        //        return GDModel;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            lt.Add(ds.Tables[0].Rows[i].ToModel<T>());
        //        }
        //        GDModel.GDModel = lt;
        //        GDModel.Count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
        //    }
        //    return GDModel;
        //}
        ///// <summary>
        ///// 分页查询
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="ThisPage">当前页数</param>    
        ///// <param name="Storing">排序</param>
        ///// <param name="PageSize">分页大小</param>
        ///// <param name="source">查询条件</param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static GDPaging<T> GTPaging<T>(this IEnumerable<T> source, int ThisPage = 1, int PageSize = 10, string Storing = null, string ConnectionName = null) where T : new()
        //{
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    GDPaging<T> GDModel = new GDPaging<T>();
        //    List<T> lt = new List<T>();
        //    string ModelName = typeof(T).Name;
        //    List<string> Conditions = new List<string>();
        //    string DbValue = string.Empty;
        //    SQLiteParameter[] parameter =
        //    {
        //       new SQLiteParameter("@ThisPage",ThisPage),
        //       new SQLiteParameter("@PageSize",PageSize),
        //       new SQLiteParameter("@TableName",ModelName),
        //       new SQLiteParameter("@Condition",source.ToString().Contains("Where")?(source.AsQueryable().Expression).DealExpress():""),
        //       new SQLiteParameter("@Sorting",(string.IsNullOrEmpty(Storing)?(" Id desc"):Storing))
        //    };
        //    DataSet ds = Helper.MoreExecuteStorage("GT_Paging", parameter);
        //    if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
        //    {
        //        GDModel.GDModel = new List<T>();
        //        return GDModel;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            lt.Add(ds.Tables[0].Rows[i].ToModel<T>());
        //        }
        //        GDModel.GDModel = lt;
        //        GDModel.Count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
        //    }
        //    return GDModel;
        //}
        ///// <summary>
        ///// 分页查询
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="Model">对象</param>    
        ///// <param name="ThisPage">当前页数</param>    
        ///// <param name="Storing">排序</param>
        ///// <param name="PageSize">分页大小</param>
        ///// <param name="Exp">查询条件</param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static GDPaging<T> GTPaging<T>(this T Model, Expression<Func<T, bool>> Exp = null, int ThisPage = 1, int PageSize = 10, string Storing = null, string ConnectionName = null) where T : new()
        //{
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    GDPaging<T> GDModel = new GDPaging<T>();
        //    List<T> lt = new List<T>();
        //    string ModelName = typeof(T).Name;
        //    List<string> Conditions = new List<string>();
        //    string DbValue = string.Empty;
        //    string Condition = Exp.DealExpress();
        //    SQLiteParameter[] parameter =
        //    {
        //       new SQLiteParameter("@ThisPage",ThisPage),
        //       new SQLiteParameter("@PageSize",PageSize),
        //       new SQLiteParameter("@TableName",ModelName),
        //       new SQLiteParameter("@Condition",string.IsNullOrEmpty(Condition)?"":" and "+Condition),
        //       new SQLiteParameter("@Sorting",(string.IsNullOrEmpty(Storing)?(" Id desc"):Storing))
        //    };
        //    DataSet ds = Helper.MoreExecuteStorage("GT_Paging", parameter);
        //    if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
        //    {
        //        GDModel.GDModel = new List<T>();
        //        return GDModel;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            lt.Add(ds.Tables[0].Rows[i].ToModel<T>());
        //        }
        //        GDModel.GDModel = lt;
        //        GDModel.Count = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
        //    }
        //    return GDModel;
        //}
        ///// <summary>
        ///// 查询一条信息
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="Model"></param>
        ///// <param name="expression">条件</param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static T GTInfo<T>(this T Model, Expression<Func<T, bool>> expression = null, string ConnectionName = null) where T : new()
        //{
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    T t = new T();
        //    List<SQLiteParameter> Parameter = new List<SQLiteParameter>();
        //    string ModelName = Model.GetType().Name;
        //    List<string> Conditions = new List<string>();
        //    string DbValue = string.Empty;
        //    DataRow dr = Helper.BsRows("select * from " + ModelName + " where " + (expression == null ? "" : expression.DealExpress()), Parameter.ToArray());
        //    if (dr == null)
        //    {
        //        return t;
        //    }
        //    return dr.ToModel<T>();
        //}
        ///// <summary>
        ///// 根据条件进行删除
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="Model"></param>
        ///// <param name="Condition">删除条件</param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static bool GTDel<T>(this T Model, Expression<Func<T, bool>> Condition = null, string ConnectionName = null) where T : new()
        //{
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    string ModelName = Model.GetType().Name;
        //    return Helper.BsExecuteSQL(" delete from " + ModelName + " where 1=1 " + (Condition == null ? "" : " and " + Condition.DealExpress()));
        //}
        ///// <summary>
        ///// 根据主键进行删除
        ///// </summary>
        ///// <typeparam name="T">泛型类型</typeparam>
        ///// <param name="Model">对象</param>        
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static bool GTDelKey<T>(this T Model, string ConnectionName = null) where T : new()
        //{
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    PropertyInfo[] propertys = Model.GetType().GetProperties();
        //    string ModelName = Model.GetType().Name;
        //    string KeyStr = " and 1=2";
        //    foreach (PropertyInfo pi in propertys)
        //    {
        //        GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
        //        if (objAttrs != null)
        //        {
        //            object obj = pi.GetValue(Model, null);
        //            if (obj != null)
        //            {
        //                if (objAttrs.IsKey)
        //                {
        //                    KeyStr = " and " + pi.Name + "=" + obj.ToString();
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    return Helper.BsExecuteSQL("Delete from " + ModelName + " where 1=1 " + KeyStr);
        //}
        ///// <summary>
        ///// 根据主键进行更新
        ///// </summary>
        ///// <typeparam name="T">泛型类型</typeparam>
        ///// <param name="Model">对象</param>        
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static bool GTUpdateKey<T>(this T Model, string ConnectionName = null) where T : new()
        //{
        //    PropertyInfo[] propertys = Model.GetType().GetProperties();
        //    List<SQLiteParameter> ListParameter = new List<SQLiteParameter>();
        //    string ModelName = Model.GetType().Name;
        //    string KeyStr = " and 1=2";
        //    List<string> FileName = new List<string>();
        //    foreach (PropertyInfo pi in propertys)
        //    {
        //        GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
        //        if (objAttrs != null)
        //        {
        //            object obj = pi.GetValue(Model, null);
        //            if (obj != null)
        //            {
        //                if (objAttrs.IsKey)
        //                {
        //                    KeyStr = " and " + pi.Name + "=" + obj.ToString();
        //                }
        //                else
        //                {
        //                    ListParameter.Add(new SQLiteParameter("@" + pi.Name, obj));
        //                    FileName.Add(pi.Name + "=@" + pi.Name);
        //                }
        //            }

        //        }
        //    }
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    return Helper.BsExecuteSQL("update " + ModelName + " set " + string.Join(",", FileName) + " where 1=1" + KeyStr, ListParameter.ToArray());
        //}
        ///// <summary>
        ///// 根据条件进行更新
        ///// </summary>
        ///// <typeparam name="T">泛型类型</typeparam>
        ///// <param name="Model">对象</param>
        ///// <param name="UpCondition">更新条件</param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static bool GTUpdata<T>(this T Model, Expression<Func<T, bool>> UpCondition = null, string ConnectionName = null) where T : new()
        //{
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    List<SQLiteParameter> ListParameter = new List<SQLiteParameter>();
        //    PropertyInfo[] propertys = Model.GetType().GetProperties();
        //    string ModelName = Model.GetType().Name;
        //    string DbValue = string.Empty;
        //    List<string> FileName = new List<string>();
        //    foreach (PropertyInfo pi in propertys)
        //    {
        //        GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
        //        if (objAttrs != null)
        //        {
        //            object obj = pi.GetValue(Model, null);
        //            if (obj != null)
        //            {
        //                if (!objAttrs.IsKey)
        //                {
        //                    FileName.Add(pi.Name + "=@" + pi.Name);
        //                    ListParameter.Add(new SQLiteParameter("@" + pi.Name, obj));
        //                }
        //            }
        //        }
        //    }
        //    return Helper.BsExecuteSQL("update " + ModelName + " set " + string.Join(",", FileName) + (UpCondition == null ? "" : " where " + UpCondition.DealExpress()), ListParameter.ToArray());
        //}
        ///// <summary>
        ///// 批量新增
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="Model"></param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static bool GTListAdd<T>(this List<T> Model, string ConnectionName = null) where T : new()
        //{
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    List<string> Listr = new List<string>();
        //    string ModelName = string.Empty;
        //    string ColumName = string.Empty;
        //    string DbValue = string.Empty;
        //    foreach (T item in Model)
        //    {
        //        PropertyInfo[] propertys = item.GetType().GetProperties();
        //        ModelName = item.GetType().Name;
        //        List<string> FileName = new List<string>();
        //        List<string> Value = new List<string>();
        //        foreach (PropertyInfo pi in propertys)
        //        {
        //            GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
        //            if (objAttrs != null)
        //            {
        //                object obj = pi.GetValue(item, null);
        //                if (obj != null)
        //                {
        //                    DbValue = pi.GetValue(item, null).DbTypeStr();
        //                    FileName.Add(pi.Name);
        //                    Value.Add(DbValue);
        //                }
        //            }
        //        }
        //        ColumName = string.Join(",", FileName);
        //        Listr.Add("(" + string.Join(",", Value) + ")");
        //    }
        //    return Helper.BsExecuteSQL("insert into " + ModelName + "(" + ColumName + ") values" + string.Join(",", Listr));
        //}
        ///// <summary>
        ///// 插入一条记录
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="Model"></param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static bool GTAdd<T>(this T Model, string ConnectionName = null) where T : new()
        //{
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    PropertyInfo[] propertys = Model.GetType().GetProperties();
        //    string tyu = Model.GetType().Name;

        //    List<SQLiteParameter> ListParameter = new List<SQLiteParameter>();
        //    List<string> FileName = new List<string>();
        //    List<string> Value = new List<string>();
        //    string DbValue = string.Empty;
        //    foreach (PropertyInfo pi in propertys)
        //    {
        //        GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
        //        if (objAttrs != null)
        //        {
        //            object obj = pi.GetValue(Model, null);
        //            if (obj != null)
        //            {
        //                FileName.Add(pi.Name);
        //                Value.Add("@" + pi.Name);
        //                ListParameter.Add(new SQLiteParameter("@" + pi.Name, pi.GetValue(Model, null)));
        //            }
        //        }
        //    }
        //    return Helper.Add(string.Join(",", FileName), string.Join(",", Value), tyu, ListParameter.ToArray());
        //}
        ///// <summary>
        ///// 新增返回自增Id
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="Model"></param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static int GTReturnAddId<T>(this T Model, string ConnectionName = null) where T : new()
        //{
        //    List<SQLiteParameter> Parameter = new List<SQLiteParameter>();
        //    PropertyInfo[] propertys = Model.GetType().GetProperties();
        //    string ModelName = Model.GetType().Name;
        //    List<string> FileName = new List<string>();
        //    List<string> Value = new List<string>();
        //    string DbValue = string.Empty;
        //    foreach (PropertyInfo pi in propertys)
        //    {
        //        GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
        //        if (objAttrs != null)
        //        {
        //            object obj = pi.GetValue(Model, null);
        //            if (obj != null)
        //            {
        //                Parameter.Add(new SQLiteParameter("@" + pi.Name, pi.GetValue(Model, null)));
        //                FileName.Add(pi.Name);
        //                Value.Add("@" + pi.Name);
        //            }
        //        }
        //    }
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    return Convert.ToInt32(Helper.GetAddGetId(string.Join(",", FileName), string.Join(",", Value), ModelName, Parameter.ToArray()));
        //}
        ///// <summary>
        ///// 直接用SQL查询返回一个表
        ///// </summary>
        ///// <param name="SQLStr"></param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static DataTable GTSearchByDtSQL(this string SQLStr, string ConnectionName = null)
        //{
        //    return GetDBHeper(ConnectionName).BsDataTable(SQLStr);
        //}
        ///// <summary>
        ///// 直接用SQL查询返回对象
        ///// </summary>
        ///// <param name="SQLStr"></param>
        ///// <param name="Model"></param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static List<T> GTSearchByModel<T>(this T Model, string SQLStr, string ConnectionName = null) where T : new()
        //{
        //    List<T> lt = new List<T>();
        //    DataTable dt = GetDBHeper(ConnectionName).BsDataTable(SQLStr);
        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //        return lt;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            lt.Add(dt.Rows[i].ToModel<T>());
        //        }
        //    }
        //    return lt;
        //}
        ///// <summary>
        ///// 直接用SQL查询返回多个表
        ///// </summary>
        ///// <param name="SQLStr"></param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static DataSet GTSearchByDsQL(this string SQLStr, string ConnectionName = null)
        //{
        //    return GetDBHeper(ConnectionName).BsDataSet(SQLStr);
        //}
        ///// <summary>
        ///// 返回单个结果存储过程
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="Model"></param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static string GTStorage<T>(this T Model, string ConnectionName = null) where T : new()
        //{
        //    List<SQLiteParameter> Parameter = new List<SQLiteParameter>();
        //    PropertyInfo[] propertys = Model.GetType().GetProperties();
        //    string ModelName = Model.GetType().Name;

        //    foreach (PropertyInfo pi in propertys)
        //    {
        //        GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
        //        if (objAttrs != null)
        //        {
        //            object obj = pi.GetValue(Model, null);
        //            if (obj != null)
        //            {
        //                Parameter.Add(new SQLiteParameter("@" + pi.Name, pi.GetValue(Model, null)));
        //            }
        //        }
        //    }
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    return Helper.StringExecuteStorage(ModelName, Parameter.ToArray());
        //}
        ///// <summary>
        ///// 返回一个表结果存储过程
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="Model"></param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static DataTable GTDtStorage<T>(this T Model, string ConnectionName = null) where T : new()
        //{
        //    List<SQLiteParameter> Parameter = new List<SQLiteParameter>();
        //    PropertyInfo[] propertys = Model.GetType().GetProperties();
        //    string ModelName = Model.GetType().Name;

        //    foreach (PropertyInfo pi in propertys)
        //    {
        //        GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
        //        if (objAttrs != null)
        //        {
        //            object obj = pi.GetValue(Model, null);
        //            if (obj != null)
        //            {
        //                Parameter.Add(new SQLiteParameter("@" + pi.Name, pi.GetValue(Model, null)));
        //            }
        //        }
        //    }
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    return Helper.ExecuteStorage(ModelName, Parameter.ToArray());
        //}
        ///// <summary>
        ///// 返回DataSet结果存储过程
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="Model"></param>
        ///// <param name="ConnectionName">数据库连接名字</param>
        ///// <returns></returns>
        //public static DataSet GTDsStorage<T>(this T Model, string ConnectionName = null) where T : new()
        //{
        //    List<SQLiteParameter> Parameter = new List<SQLiteParameter>();
        //    PropertyInfo[] propertys = Model.GetType().GetProperties();
        //    string ModelName = Model.GetType().Name;

        //    foreach (PropertyInfo pi in propertys)
        //    {
        //        GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
        //        if (objAttrs != null)
        //        {
        //            object obj = pi.GetValue(Model, null);
        //            if (obj != null)
        //            {
        //                Parameter.Add(new SQLiteParameter("@" + pi.Name, pi.GetValue(Model, null)));
        //            }
        //        }
        //    }
        //    SQLiteDBHeper Helper = GetDBHeper(ConnectionName);
        //    return Helper.MoreExecuteStorage(ModelName, Parameter.ToArray());
        //}
        ///// <summary>
        ///// 条件
        ///// </summary>
        ///// <typeparam name="T">实体类</typeparam>
        ///// <param name="t"></param>        
        ///// <param name="Exp">条件</param>
        ///// <param name="Sort">排序</param>
        ///// <returns></returns>
        ////public static GDModel.MergerModel GTCodition<T>(this T t, Expression<Func<T, bool>> Exp = null, string Sort = null) where T : new()
        ////{
        ////    string TableName = typeof(T).Name;
        ////    string Where = Exp.DealExpress();
        ////    Where = $"select * from {TableName} where 1=1 " + (string.IsNullOrEmpty(Where) ? "" : (" and " + Where)) + (string.IsNullOrEmpty(Sort) ? "" : Sort);
        ////    return new GDModel.MergerModel() { SQLStr = Where, Entity = t, EntityName = TableName };
        ////}
        ///// <summary>
        ///// 查询多个表;
        ///// </summary>
        ///// <param>调用：var f= objc[0].As<!--实体-->()</param>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public static List<List<object>> GTMergerSearch(params object[] obj)
        //{
        //    List<List<object>> objlist = new List<List<object>>();
        //    List<GDModel.MergerModel> ListSQLStr = new List<GDModel.MergerModel>();
        //    foreach (var item in obj)
        //    {
        //        ListSQLStr.Add((item as GDModel.MergerModel));
        //    }
        //    SQLiteDBHeper Helper = GetDBHeper(null);
        //    var r = Helper.BsDataSet(string.Join(";", ListSQLStr.Select(s => s.SQLStr).ToArray()));
        //    foreach (DataTable item in r.Tables)
        //    {
        //        var sl = ListSQLStr.Where(w => w.EntityName == item.TableName).Select(s => s.Entity).ToArray().First();
        //        List<object> listable = new List<object>();
        //        for (int i = 0; i < item.Rows.Count; i++)
        //        {
        //            listable.Add(item.Rows[i].ToModel(sl));
        //        }
        //        objlist.Add(listable);
        //    }
        //    return objlist;
        //}
        ///// <summary>
        ///// 查询多个表;
        ///// </summary>
        ///// <param>调用：var f= objc[0].As<!--实体-->()</param>
        ///// <param name="Connection">数据库连接</param>
        ///// <param name="obj"></param>
        //public static List<List<object>> GTMergerSearch(string Connection, params object[] obj)
        //{
        //    List<List<object>> objlist = new List<List<object>>();
        //    List<GDModel.MergerModel> ListSQLStr = new List<GDModel.MergerModel>();
        //    foreach (var item in obj)
        //    {
        //        ListSQLStr.Add((item as GDModel.MergerModel));
        //    }
        //    SQLiteDBHeper Helper = GetDBHeper(Connection);
        //    var r = Helper.BsDataSet(string.Join(";", ListSQLStr.Select(s => s.SQLStr).ToArray()));
        //    foreach (DataTable item in r.Tables)
        //    {
        //        var sl = ListSQLStr.Where(w => w.EntityName == item.TableName).Select(s => s.Entity).ToArray().First();
        //        List<object> listable = new List<object>();
        //        for (int i = 0; i < item.Rows.Count; i++)
        //        {
        //            listable.Add(item.Rows[i].ToModel(sl));
        //        }
        //        objlist.Add(listable);
        //    }
        //    return objlist;
        //}
        ///// <summary>
        ///// 条件
        ///// </summary>
        ///// <typeparam name="T">实体类</typeparam>
        ///// <param name="t"></param>
        ///// <param name="OperType">操作类型</param>
        ///// <param name="Exp">条件</param> 
        ///// <param name="Sort">排序</param>
        ///// <returns></returns>
        //public static GDModel.MergerModel GTCodition<T>(this T t, GTEnum.OperationType OperType, Expression<Func<T, bool>> Exp = null, string Sort = null) where T : new()
        //{
        //    PropertyInfo[] propertys = t.GetType().GetProperties();
        //    string SQLStr = string.Empty;
        //    string Where = (Exp == null ? "" : Exp.DealExpress());
        //    string TableName = typeof(T).Name;
        //    if (OperType == GTEnum.OperationType.Add || OperType == GTEnum.OperationType.Update)
        //    {
        //        List<string> FileName = new List<string>();
        //        List<string> Value = new List<string>();
        //        string DbValue = string.Empty;
        //        foreach (PropertyInfo pi in propertys)
        //        {
        //            GDColoum objAttrs = pi.GetCustomAttribute<GDColoum>();
        //            if (objAttrs != null && !objAttrs.IsKey)
        //            {
        //                object obj = pi.GetValue(t, null);
        //                if (obj != null)
        //                {
        //                    if (OperType == GTEnum.OperationType.Add)
        //                    {
        //                        FileName.Add(pi.Name);
        //                        Value.Add(pi.GetValue(t, null).DbTypeStr());
        //                    }
        //                    else
        //                    {
        //                        FileName.Add($"{pi.Name}={pi.GetValue(t, null).DbTypeStr()}");
        //                    }
        //                }
        //            }
        //        }
        //        if (OperType == GTEnum.OperationType.Add)
        //        {
        //            SQLStr = $"INSERT INTO {TableName}({string.Join(",", FileName)}) values({string.Join(",", Value)})";
        //        }
        //        else
        //        {
        //            SQLStr = $"UPDATE {TableName} set {string.Join(",", FileName)} where 1=1" + (string.IsNullOrEmpty(Where) ? "" : " and " + Where);
        //        }
        //    }
        //    else
        //    {
        //        SQLStr = $"DELETE FROM {TableName} where 1=1 {Where}";
        //    }
        //    return new GDModel.MergerModel() { SQLStr = SQLStr, Entity = t };
        //}
        ///// <summary>
        ///// 执行多个表操作
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public static bool GTMergerExecute(params object[] obj)
        //{
        //    List<string> SQLStr = new List<string>();
        //    foreach (var item in obj)
        //    {
        //        SQLStr.Add((item as GDModel.MergerModel).SQLStr);
        //    }
        //    SQLiteDBHeper Helper = GetDBHeper(null);
        //    return Helper.BsExecuteSQL(string.Join(";", SQLStr));
        //}
        ///// <summary>
        ///// 执行多个表操作
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <param name="Connection">数据库连接名字</param>
        ///// <returns></returns>
        //public static bool GTMergerExecute(string Connection, params object[] obj)
        //{
        //    List<string> SQLStr = new List<string>();
        //    foreach (var item in obj)
        //    {
        //        SQLStr.Add((item as GDModel.MergerModel).SQLStr);
        //    }
        //    SQLiteDBHeper Helper = GetDBHeper(Connection);
        //    return Helper.BsExecuteSQL(string.Join(";", SQLStr));
        //}
        ///// <summary>
        ///// 转成其他实体
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="ojbc"></param>
        ///// <returns></returns>
        //public static List<T> As<T>(this List<object> ojbc)
        //{
        //    return ojbc.Cast<T>().ToList();
        //}
    }
}
