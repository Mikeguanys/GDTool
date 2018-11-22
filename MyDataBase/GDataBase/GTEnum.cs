namespace GDataBase
{
    /// <summary>
    /// 公共枚举
    /// </summary>
    public class GTEnum
    {
        /// <summary>
        /// 图片类型
        /// </summary>
        public enum ImagePosition
        {
            /// <summary>
            /// 左上
            /// </summary>
            LeftTop,
            /// <summary>
            /// 左下
            /// </summary>
            LeftBottom,
            /// <summary>
            /// 右上
            /// </summary>
            RightTop,
            /// <summary>
            /// 右下
            /// </summary>
            RigthBottom,
            /// <summary>
            /// 顶部居中
            /// </summary>
            TopMiddle,
            /// <summary>
            /// 底部居中
            /// </summary>
            BottomMiddle,
            /// <summary>
            /// 中心
            /// </summary>
            Center
        }
        /// <summary>
        /// 操作类型增,删,改
        /// </summary>
        public enum OperationType
        {
            /// <summary>
            /// 新增
            /// </summary>
            Add,
            /// <summary>
            /// 删除
            /// </summary>
            Del,
            /// <summary>
            /// 修改
            /// </summary>
            Update
        }
    }
}
