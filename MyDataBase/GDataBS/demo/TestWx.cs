using GDataBase;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace GDataBS.demo
{
    public class TestWx : GDataBase.WXInterface
    {
        public string WxBack()
        {
            MyGT gt = new MyGT();
            //随机数
            string nonce = GetNonce_str();
            //需要这些字段用MD5加密成签名
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("appid", "wx075899c9330df281");
            dic.Add("mch_id", "1268028601");
            dic.Add("nonce_str", nonce);
            dic.Add("transaction_id", "0000000001");
            dic.Add("out_trade_no", "ba000000001");
            dic.Add("out_refund_no", "CX000000001");
            dic.Add("total_fee", "1");
            dic.Add("refund_fee", "1");
            dic.Add("op_user_id", "00000001");
            string sign = CreateSign(dic);

            ReturnGoodsModel returngoods = new ReturnGoodsModel()
            {
                appid = dic["appid"],
                mch_id = dic["mch_id"],
                // device_info = dic["device_info"],
                nonce_str = nonce,
                sign = sign,
                transaction_id = dic["transaction_id"],
                out_trade_no = dic["out_trade_no"],
                out_refund_no = dic["out_refund_no"],
                total_fee = Convert.ToInt32(dic["total_fee"]),
                refund_fee = Convert.ToInt32(dic["refund_fee"]),
                refund_fee_type = "CNY",
                op_user_id = "190000000109"

            };

            //将要验证的证书
            string xml = gt.XMLSerialize(returngoods);

            string cert = @"D:\apiclient_cert.p12";

            string password = "10010000";

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

            //读取证书
            //X509Certificate cer = new X509Certificate(cert, password);

            return gt.WebRequestPost(BackPay, xml);
        }
        /*CheckValidationResult的定义*/
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}