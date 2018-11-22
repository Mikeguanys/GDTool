using System.Xml.Serialization;

namespace GDataBase
{
    public class WXModel
    {

    }
    [XmlRootAttribute("xml")]
    public class ReturnGoodsModel
    {
        /// <summary>
        /// appid
        /// </summary>
        //[XmlAttribute("appid")]
        public string appid { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        //[XmlAttribute("mch_id")]
        public string mch_id { get; set; }
        /// <summary>
        /// 设备号pc网页web
        /// </summary>
        //[XmlAttribute("device_info")]
        public string device_info { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        //[XmlAttribute("nonce_str")]
        public string nonce_str { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        //[XmlAttribute("sign")]
        public string sign { get; set; }
        /// <summary>
        /// 微信订单
        /// </summary>
        //[XmlAttribute("transaction_id")]
        public string transaction_id { get; set; }
        /// <summary>
        /// 微信订单号
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 商户退单号
        /// </summary>
        //[XmlAttribute("out_refund_no")]
        public string out_refund_no { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        //[XmlAttribute("total_fee")]
        public int total_fee { get; set; }
        /// <summary>
        /// 推客金额
        /// </summary>
        //[XmlAttribute("refund_fee")]
        public int refund_fee { get; set; }
        /// <summary>
        /// 货币种类
        /// </summary>
        //[XmlAttribute("refund_fee_type")]
        public string refund_fee_type { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        //[XmlAttribute("op_user_id")]
        public string op_user_id { get; set; }
    }

    public class BackReturnModel
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        [XmlAttribute("return_code")]
        public string return_code { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        [XmlAttribute("return_msg")]
        public string return_msg { get; set; }
        /// <summary>
        /// 业务结果
        /// </summary>
        [XmlAttribute("result_code")]
        public string result_code { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        [XmlAttribute("err_code")]
        public string err_code { get; set; }
        /// <summary>
        /// 错误代码描述
        /// </summary>
        [XmlAttribute("err_code_des")]
        public string err_code_des { get; set; }
        /// <summary>
        /// 公众账号ID
        /// </summary>
        [XmlAttribute("appid")]
        public string appid { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        [XmlAttribute("mch_id")]
        public string mch_id { get; set; }
        /// <summary>
        /// 设备号
        /// </summary>
        [XmlAttribute("device_info")]
        public string device_info { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        [XmlAttribute("nonce_str")]
        public string nonce_str { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        [XmlAttribute("sign")]
        public string sign { get; set; }
        /// <summary>
        /// 微信订单号
        /// </summary>
        [XmlAttribute("transaction_id")]
        public string transaction_id { get; set; }
        /// <summary>
        /// 商户订单号
        /// </summary>
        [XmlAttribute("out_trade_no")]
        public string out_trade_no { get; set; }
        /// <summary>
        /// 商户退款单号
        /// </summary>
        [XmlAttribute("out_refund_no")]
        public string out_refund_no { get; set; }
        /// <summary>
        /// 微信退单号
        /// </summary>
        [XmlAttribute("refund_id")]
        public string refund_id { get; set; }
        /// <summary>
        /// 退款渠道
        /// </summary>
        [XmlAttribute("refund_channel")]
        public string refund_channel { get; set; }
        /// <summary>
        /// 退款金额
        /// </summary>
        [XmlAttribute("refund_fee")]
        public string refund_fee { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        [XmlAttribute("total_fee")]
        public string total_fee { get; set; }
        /// <summary>
        /// 订单金额货币种
        /// </summary>
        [XmlAttribute("fee_type")]
        public string fee_type { get; set; }
        /// <summary>
        /// 现金支付金额
        /// </summary>
        [XmlAttribute("cash_fee")]
        public string cash_fee { get; set; }
        /// <summary>
        /// 现金退款金额
        /// </summary>
        [XmlAttribute("cash_refund_fee")]
        public string cash_refund_fee { get; set; }
        /// <summary>
        /// 代金券或立减优惠退款金额
        /// </summary>
        [XmlAttribute("coupon_refund_fee")]
        public string coupon_refund_fee { get; set; }
        /// <summary>
        /// 代金券或立减优惠使用数量
        /// </summary>
        [XmlAttribute("coupon_refund_count")]
        public string coupon_refund_count { get; set; }
        /// <summary>
        /// 代金券或立减优惠ID
        /// </summary>
        [XmlAttribute("coupon_refund_id")]
        public string coupon_refund_id { get; set; }
    }
}
