using GDateBase2v.Enums;
using GDAttributes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GDateBase2v.MySQL
{
    public static class MySQLStaticBSHelper
    {
        public static string ConnectName = string.Empty;
        public static int GDAddGetId<T>(this T Model) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDAddGetId(Model);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="Model">实体</param>
        /// <returns></returns>
        public static bool GDAdd<T>(this T Model) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDAdd(Model);
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static bool GDAddBatch<T>(this List<T> ListModel) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDAddBatch(ListModel);
        }
        /// <summary>
        /// 更新操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <param name="Exp"></param>
        /// <returns></returns>
        public static bool GDUpdate<T>(this T Model, Expression<Func<T, bool>> Exp = null) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDUpdate(Model, Exp);
        }
        /// <summary>
        /// 根据Key更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <param name="Exp"></param>
        /// <returns></returns>
        public static bool GDUpdateByKey<T>(this T Model) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDUpdateByKey(Model);
        }
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <param name="Exp"></param>
        /// <returns></returns>
        public static bool GDelete<T>(this T Model, Expression<Func<T, bool>> Exp = null) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDelete(Model, Exp);
        }
        /// <summary>
        /// 根据Key删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static bool GDeleteByKey<T>(this T Model) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDeleteByKey(Model);
        }
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public static T GDInfo<T>(this T Model, Expression<Func<T, bool>> Exp = null) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDInfo(Model, Exp);
        }
        /// <summary>
        /// 获取多条数据无排序，默认排序为主键倒序
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="Source">对象</param>        
        /// <returns></returns>
        public static List<T> GDList<T>(this IEnumerable<T> Source) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDList(Source);
        }
        /// <summary>
        /// 获取多条数据无排序，默认排序为主键倒序
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="Source">对象</param>        
        /// <returns></returns>
        public static List<T> GDList<T>(this T Source, Expression<Func<T, bool>> Exp) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDList(Source, Exp);
        }
        /// <summary>
        /// 获取多条数据排序，默认排序为倒序
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <typeparam name="TRuslt">对象</typeparam>
        /// <param name="Source">List</param>        
        /// <param name="OrderBy">排序字段</param>
        /// <returns></returns>
        public static List<T> GDList<T, TRuslt>(this IEnumerable<T> Source, Expression<Func<T, TRuslt>> OrderBy) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDList(Source, OrderBy);
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
        public static List<T> GDList<T, TRuslt>(this T Source, Expression<Func<T, bool>> Exp, Expression<Func<T, TRuslt>> OrderBy) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDList(Source, Exp, OrderBy);
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
        public static List<T> GDList<T, TRuslt>(this IEnumerable<T> Source, Expression<Func<T, TRuslt>> OrderBy, SQLEnum.SortType SType) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDList(Source, OrderBy, SType);
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
        public static List<T> GDList<T, TRuslt>(this T Source, Expression<Func<T, bool>> Exp, Expression<Func<T, TRuslt>> OrderBy, SQLEnum.SortType SType) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDList(Source, Exp, OrderBy, SType);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">对象</typeparam>        
        /// <param name="Source">List</param> 
        /// <returns></returns>
        public static GDPaging<T> GDPaging<T>(this IEnumerable<T> Source, int ThisPage = 1, int PageSize = 10) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDPaging(Source, ThisPage, PageSize);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">对象</typeparam>        
        /// <param name="Source">List</param> 
        /// <param name="Exp">查询条件</param> 
        /// <returns></returns>
        public static GDPaging<T> GDPaging<T>(this T Source, Expression<Func<T, bool>> Exp, int ThisPage = 1, int PageSize = 10) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDPaging(Source, Exp, ThisPage, PageSize);
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
        public static GDPaging<T> GDPaging<T, TRuslt>(this IEnumerable<T> Source, Expression<Func<T, TRuslt>> OrderBy, int ThisPage = 1, int PageSize = 10) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDPaging(Source, OrderBy, ThisPage, PageSize);
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
        public static GDPaging<T> GDPaging<T, TRuslt>(this T Source, Expression<Func<T, bool>> Exp, Expression<Func<T, TRuslt>> OrderBy, int ThisPage = 1, int PageSize = 10) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDPaging(Source, Exp, OrderBy, ThisPage, PageSize);
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
        public static GDPaging<T> GDPaging<T, TRuslt>(this IEnumerable<T> Source, Expression<Func<T, TRuslt>> OrderBy, SQLEnum.SortType SType, int ThisPage = 1, int PageSize = 10) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDPaging(Source, OrderBy, SType, ThisPage, PageSize);
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
        public static GDPaging<T> GDPaging<T, TRuslt>(this T Source, Expression<Func<T, bool>> Exp, Expression<Func<T, TRuslt>> OrderBy, SQLEnum.SortType SType, int ThisPage = 1, int PageSize = 10) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDPaging(Source, Exp, OrderBy, SType, ThisPage, PageSize);
        }
        ////////////////////////////////查询多个表Start///////////////////////////        
        /// <summary>
        /// 查询多个表;
        /// </summary>
        /// <param>调用：var f= objc[0].As<!--实体-->()</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static List<List<object>> GDMergerSearch(params object[] obj)
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDMergerSearch(obj);
        }
        /// <summary>
        /// 执行多个表操作
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GDMergerExecute(params object[] obj)
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDMergerExecute(obj);
        }
        /// <summary>
        /// 条件
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t"></param>        
        /// <param name="Exp">条件</param>
        /// <param name="Sort">排序</param>
        /// <returns></returns>
        public static GDModel.MergerModel GDCodition<T, TRuslt>(this T t, Expression<Func<T, bool>> Exp = null, Expression<Func<T, TRuslt>> OrderBy = null, SQLEnum.SortType SType = SQLEnum.SortType.Desc) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDCodition(t, Exp, OrderBy, SType);
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
        public static GDModel.MergerModel GDCodition<T>(this T t, SQLEnum.OperationType OperType, Expression<Func<T, bool>> Exp = null) where T : new()
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.GDCodition(t, OperType, Exp);
        }
        /// <summary>
        /// 转成其他实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ojbc"></param>
        /// <returns></returns>
        public static List<T> As<T>(this List<object> ojbc)
        {
            MySQLBSHelper Bs = new MySQLBSHelper(ConnectName);
            return Bs.As<T>(ojbc);
        }
        ////////////////////////////////查询多个表End/////////////////////////////
    }
}
