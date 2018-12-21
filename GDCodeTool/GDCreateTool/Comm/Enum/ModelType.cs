using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDCreateTool.Comm.Enum
{
    public enum ModelType
    {
        /// <summary>
        /// 列表页UI
        /// </summary>
        ListPage,
        /// <summary>
        /// 列表方法
        /// </summary>
        List,
        /// <summary>
        /// 详情页UI
        /// </summary>
        InfoPage,
        /// <summary>
        /// 详情方法
        /// </summary>
        Info,
        /// <summary>
        /// 逻辑层
        /// </summary>
        BLL,
        /// <summary>
        /// 数据层
        /// </summary>
        DAL,
        /// <summary>
        /// 模型层
        /// </summary>
        Model,
        /// <summary>
        /// 新的模型层
        /// </summary>
        ModelBS,
        /// <summary>
        /// 接口
        /// </summary>
        WebAPI
    }
}
