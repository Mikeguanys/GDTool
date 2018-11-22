using GDateBase2v.Enums;
using GDateBase2v.SQLServer;
using GDAttributes;
using GDUnitTest.TestModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GDUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            GDModel.SQLModel Model = new GDModel.SQLModel();
            List<GDModel.SQLModel> ListModel = new List<GDModel.SQLModel>();
            ListModel.OrderByDescending(o => o.Value);
            SQLServerBSHelper helper = new SQLServerBSHelper();
            GDTable dt = new GDTable()
            {
                Id = -1,
                Money = 0,
                DateTime = DateTime.Now,
                Float = 0,
                Name = $"测试{DateTime.Now.ToString("yyyyMMddhhmmssffff")}",
                Nums = 0,
                Sex = false,
                State = GDTable.States
                  .启用,
                Rember = "一大段文字。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。",
            };
            List<GDTable> GDList = new List<GDTable>();
            for (int i = 0; i < 10; i++)
            {
                dt.Nums = i;
                GDList.Add(dt);
            }
            //插入返回自增Id：测试通过
            //int it = helper.GDAddGetId(dt);
            //插入一条数据：测试通过
            //bool r = helper.GDAdd(dt);
            //批量插入数据：测试通过（insert into table values(),(),(),(),(),(),(),(),()）
            //bool r = helper.GDAddBatch(GDList);
            //更新数据：
            GDTable updatedt = new GDTable()
            {
                Id = 64,
                Money = 1,
                DateTime = DateTime.Now,
                Float = 1,
                Name = $"Update1测试{DateTime.Now.ToString("yyyyMMddhhmmssffff")}",
                Nums = 1,
                Sex = true,
                State = GDTable.States.启用,
                Rember = "Update1一大段文字",
            };
            //根据条件更新表数据：测试通过
            //bool r = helper.GDUpdate(updatedt,w=>w.Id==1);
            //根据主键更新表数据：测试通过
            //bool r = helper.GDUpdateByKey(updatedt);
            //删除数据：测试通过
            //bool r = helper.GDelete(updatedt, w => w.Sex==false);
            //根据主键删除表数据：测试通过
            //bool r = helper.GDeleteByKey(updatedt);
            /////************-------查询单个表Start----------***********/////
            //查询一条数据：测试通过
            //var info = helper.GDInfo(updatedt,w=>w.Id==1);
            //查询多条数据无排序默认主键倒叙：测试通过            
            var l = GDList.AsQueryable();
            l = l.Where(w => w.Id == 1);
            l = l.Where(w => w.Nums == 1);
            //var list1 = helper.GDList(updatedt, o => o.Id == 1);
            //var list11 = helper.GDList(l);
            //查询多条数据排序倒叙：测试通过
            //var list2 = helper.GDList(updatedt, o => o.Id == 1, o => o.Id);
            //var list22 = helper.GDList(l, o => o.Id);
            //查询多条数据排序：测试通过
            //var list3 = helper.GDList(updatedt, null, o => new { o.Id, o.Nums }, SQLEnum.SortType.Asc);
            //var list33 = helper.GDList(l, o => o.Id, SQLEnum.SortType.Asc);
            //分页：测试通过
            //var Pading1 = helper.GDPaging(updatedt, o => o.Id == 1, 1, 5);
            //var Pading11 = helper.GDPaging(l, 1, 5);
            //分页：测试通过
            //var Pading2 = helper.GDPaging(updatedt, null, o => o.Id, 1, 5);
            //var Pading22 = helper.GDPaging(l, o => o.Id, 1, 5);
            //分页：测试通过
            //var Pading3 = helper.GDPaging(updatedt, null, o => o.Id, SQLEnum.SortType.Asc, 2, 5);
            //var Pading33 = helper.GDPaging(l, o => o.Id, SQLEnum.SortType.Asc, 1, 5);
            /////************-------查询单个表End----------***********/////
            /////************-------查询多个表Start----------***********/////
            //多表查询
            //var searchmore = helper.GDMergerSearch(helper.GDCodition(new GDTable(), o => o.Id == 1, q => q.Id), helper.GDCodition(new GDTable(), o => o.Id == 2, q => q.Id));
            //var r1 = helper.As<GDTable>(searchmore[0]);
            //var r2 = helper.As<GDTable>(searchmore[1]);
            //多表执行
            var morex = helper.GDMergerExecute(helper.GDCodition(new GDTable()
            {
                Money = 1,
                DateTime = DateTime.Now,
                Float = 1,
                Name = $"Update1测试{DateTime.Now.ToString("yyyyMMddhhmmssffff")}",
                Nums = 8,
                Sex = true,
                State = GDTable.States.启用,
                Rember = "Update1一大段文字",
            }, SQLEnum.OperationType.Add, null), helper.GDCodition(new GDTable()
            {
                Money = 1,
                DateTime = DateTime.Now,
                Float = 1,
                Name = $"Update1测试{DateTime.Now.ToString("yyyyMMddhhmmssffff")}",
                Nums = 9,
                Sex = true,
                State = GDTable.States.启用,
                Rember = "Update1一大段文字",
            }, SQLEnum.OperationType.Add, null));

            /////************-------查询多个表End----------***********/////
        }
        [TestMethod]
        public void TestMethod2()
        {
            GDTable dt = new GDTable()
            {
                Id = 1,
                Money = 0,
                DateTime = DateTime.Now,
                Float = 0,
                Name = $"测试{DateTime.Now.ToString("yyyyMMddhhmmssffff")}",
                Nums = 0,
                Sex = false,
                State = GDTable.States
                  .启用,
                Rember = "一大段文字。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。",
            };
            GDTable dt1 = new GDTable()
            {
                Id = 2,
                Money = 0,
                DateTime = DateTime.Now,
                Float = 0,
                Name = $"测试{DateTime.Now.ToString("yyyyMMddhhmmssffff")}",
                Nums = 0,
                Sex = false,
                State = GDTable.States
                 .启用,
                Rember = "一大段文字。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。。",
            };
            CMoth cm = new CMoth();
            List<GDTable> lis = new List<GDTable>();
            lis.Add(dt);
            lis.Add(dt1);
            //cm.GDOrderBy(dt, o => o.Id == 1);
            var sdf = lis.OrderBy(o => o.Id == 1).ToList();
        }
        //基类1测试方法
        [TestMethod]
        public void TestMethod3()
        {
            SQLServerStaticBSHelper.ConnectName = "GDataBase";
            var fd = new GDTable().GDList(o => o.Id == 1);
        }
    }
}
