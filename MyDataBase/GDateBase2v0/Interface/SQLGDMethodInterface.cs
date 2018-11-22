using GDateBase2v.Enums;
using GDAttributes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GDateBase2v.Interface
{
    interface SQLGDMethodInterface
    {
        /// <summary>
        /// 添加并返回自增Id
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="Model">实体</param>
        /// <returns>自增Id</returns>
        int GDAddGetId<T>(T Model) where T : new();
        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="Model">实体</param>
        /// <returns></returns>
        bool GDAdd<T>(T Model) where T : new();
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        bool GDAddBatch<T>(List<T> ListModel) where T : new();
        /// <summary>
        /// 更新操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <param name="Exp"></param>
        /// <returns></returns>
        bool GDUpdate<T>(T Model, Expression<Func<T, bool>> Exp = null) where T : new();
        /// <summary>
        /// 根据Key更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <param name="Exp"></param>
        /// <returns></returns>
        bool GDUpdateByKey<T>(T Model) where T : new();
        /// <summary>
        /// 删除操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <param name="Exp"></param>
        /// <returns></returns>
        bool GDelete<T>(T Model, Expression<Func<T, bool>> Exp = null) where T : new();
        /// <summary>
        /// 根据Key删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        bool GDeleteByKey<T>(T Model) where T : new();
        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        T GDInfo<T>(T Model, Expression<Func<T, bool>> Exp = null) where T : new();
        /// <summary>
        /// 获取多条数据无排序，默认排序为主键倒序
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="Source">对象</param>        
        /// <returns></returns>
        List<T> GDList<T>(IEnumerable<T> Source) where T : new();
        /// <summary>
        /// 获取多条数据无排序，默认排序为主键倒序
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="Source">对象</param>        
        /// <returns></returns>
        List<T> GDList<T>(T Source, Expression<Func<T, bool>> Exp) where T : new();
        /// <summary>
        /// 获取多条数据排序，默认排序为倒序
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <typeparam name="TRuslt">对象</typeparam>
        /// <param name="Source">List</param>        
        /// <param name="OrderBy">排序字段</param>
        /// <returns></returns>
        List<T> GDList<T, TRuslt>(IEnumerable<T> Source, Expression<Func<T, TRuslt>> OrderBy) where T : new();
        /// <summary>
        /// 获取多条数据排序，默认排序为倒序
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <typeparam name="TRuslt">对象</typeparam>
        /// <param name="Source">List</param>        
        /// <param name="Exp">查询条件</param>
        /// <param name="OrderBy">排序字段</param>        
        /// <returns></returns>
        List<T> GDList<T, TRuslt>(T Source, Expression<Func<T, bool>> Exp, Expression<Func<T, TRuslt>> OrderBy) where T : new();
        /// <summary>
        /// 获取多条数据排序
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <typeparam name="TRuslt">对象</typeparam>
        /// <param name="Source">List</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="SType">排序类型</param>
        /// <returns></returns>
        List<T> GDList<T, TRuslt>(IEnumerable<T> Source, Expression<Func<T, TRuslt>> OrderBy, SQLEnum.SortType SType) where T : new();
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
        List<T> GDList<T, TRuslt>(T Source, Expression<Func<T, bool>> Exp, Expression<Func<T, TRuslt>> OrderBy, SQLEnum.SortType SType) where T : new();
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">对象</typeparam>        
        /// <param name="Source">List</param> 
        /// <returns></returns>
        GDPaging<T> GDPaging<T>(IEnumerable<T> Source, int ThisPage = 1, int PageSize = 10) where T : new();
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">对象</typeparam>        
        /// <param name="Source">List</param> 
        /// <param name="Exp">查询条件</param> 
        /// <returns></returns>
        GDPaging<T> GDPaging<T>(T Source, Expression<Func<T, bool>> Exp, int ThisPage = 1, int PageSize = 10) where T : new();
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
        GDPaging<T> GDPaging<T, TRuslt>(IEnumerable<T> Source, Expression<Func<T, TRuslt>> OrderBy, int ThisPage = 1, int PageSize = 10) where T : new();
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
        GDPaging<T> GDPaging<T, TRuslt>(T Source, Expression<Func<T, bool>> Exp, Expression<Func<T, TRuslt>> OrderBy, int ThisPage = 1, int PageSize = 10) where T : new();
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
        GDPaging<T> GDPaging<T, TRuslt>(IEnumerable<T> Source, Expression<Func<T, TRuslt>> OrderBy, SQLEnum.SortType SType, int ThisPage = 1, int PageSize = 10) where T : new();
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
        GDPaging<T> GDPaging<T, TRuslt>(T Source, Expression<Func<T, bool>> Exp, Expression<Func<T, TRuslt>> OrderBy, SQLEnum.SortType SType, int ThisPage = 1, int PageSize = 10) where T : new();
        /// <summary>
        /// 查询多个表;
        /// </summary>
        /// <param>调用：var f= objc[0].As<!--实体-->()</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        List<List<object>> GDMergerSearch(params object[] obj);
        /// <summary>
        /// 执行多个表操作
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool GDMergerExecute(params object[] obj);
        /// <summary>
        /// 条件
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t"></param>        
        /// <param name="Exp">条件</param>
        /// <param name="Sort">排序</param>
        /// <returns></returns>
        GDModel.MergerModel GDCodition<T, TRuslt>(T t, Expression<Func<T, bool>> Exp = null, Expression<Func<T, TRuslt>> OrderBy = null, SQLEnum.SortType SType = SQLEnum.SortType.Desc) where T : new();
        /// <summary>
        /// 条件
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t"></param>
        /// <param name="OperType">操作类型</param>
        /// <param name="Exp">条件</param> 
        /// <param name="Sort">排序</param>
        /// <returns></returns>
        GDModel.MergerModel GDCodition<T>(T t, SQLEnum.OperationType OperType, Expression<Func<T, bool>> Exp = null) where T : new();
        /// <summary>
        /// 转成其他实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ojbc"></param>
        /// <returns></returns>
        List<T> As<T>(List<object> ojbc);
    }
}
