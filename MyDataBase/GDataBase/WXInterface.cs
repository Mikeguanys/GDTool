using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace GDataBase
{
    public abstract class WXInterface : MyGWx
    {        
        
        ///////////////////////////////////////////////////////////---接口STart---///////////////////////////////////////////
        /// <summary>
        /// 退款接口
        /// </summary>
        public string BackPay
        {
            get { return "https://api.mch.weixin.qq.com/secapi/pay/refund"; }
        }
        /// <summary>
        /// 支付接口
        /// </summary>
        public string Pay
        {
            get { return "https://api.mch.weixin.qq.com/pay/unifiedorder"; }
        }
        ///////////////////////////////////////////////////////////---接口Start---///////////////////////////////////////////
        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <returns></returns>
        public string GetNonce_str()
        {
            StringBuilder _builder = new StringBuilder(32);
            Random random = new Random();
            int _startChar = true ? 97 : 65;//65 = A / 97 = a
            for (int i = 0; i < 32; i++)
                _builder.Append((char)(26 * random.NextDouble() + _startChar));            
            return _builder.ToString();
        }
        /// <summary>
        /// WxMD5生成算法
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public string WXMD5Util(string r)
        {
            char[] hexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
					'A', 'B', 'C', 'D', 'E', 'F' };
            try
            {
                byte[] btInput = System.Text.Encoding.Default.GetBytes(r);
                // 获得MD5摘要算法的 MessageDigest 对象
                MD5 mdInst = System.Security.Cryptography.MD5.Create();
                // 使用指定的字节更新摘要
                mdInst.ComputeHash(btInput);
                // 获得密文
                byte[] md = mdInst.Hash;
                // 把密文转换成十六进制的字符串形式
                int j = md.Length;
                char[] str = new char[j * 2];
                int k = 0;
                for (int i = 0; i < j; i++)
                {
                    byte byte0 = md[i];
                    str[k++] = hexDigits[(int)(((byte)byte0) >> 4) & 0xf];
                    str[k++] = hexDigits[byte0 & 0xf];
                }
                return new string(str);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.StackTrace);
                return null;
            }
        }       
        /// <summary>
        /// 获取prepay_id
        /// </summary>
        /// <returns></returns>
        protected string GetPrepay_id<T>(T t)
        {
            MyGT gt=new MyGT ();
            string prepay_id = null;
            string xml =gt.XMLSerialize(t);            
            if (!string.IsNullOrWhiteSpace(xml))
            {
                string url = "https://api.mch.weixin.qq.com/secapi/pay/refund";
                System.Net.WebClient webClient = new System.Net.WebClient();
                string result = webClient.UploadString(url, "post", xml); ;
                
                if (result.IndexOf("OUT_TRADE_NO_USED") > 0)
                {
                    throw new Exception("商户订单号重复");
                }
                else if (result.IndexOf("SUCCESS") > 0)
                {                 
                    prepay_id = GetXmlData(result);                 
                }
            }
            return prepay_id;
        }

        /// <summary>
        /// 解析xml 获取prepay_id
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        protected string GetXmlData(string xml)
        {
            string prepay_id = string.Empty;
            System.Xml.XmlDocument postObj = new System.Xml.XmlDocument();
            postObj.LoadXml(xml);
            XmlElement postElement = postObj.DocumentElement;
            if ("SUCCESS".Equals(postElement.SelectSingleNode("result_code").InnerText))//成功获取
            {
                prepay_id = postElement.SelectSingleNode("prepay_id").InnerText;
            }
            else if ("FAIL".Equals(postElement.SelectSingleNode("result_code").InnerText))//获取失败
            {
                return "";
            }
            return prepay_id;
        }
        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"> DateTime时间格式</param>
        /// <returns>Unix时间戳格式</returns>
        public int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public string CreateSign(Dictionary<string, string> dic)
        {
            string str = string.Empty;
            var r = from x in dic orderby x.Key select x;
            foreach (var item in r)
            {
                 str += item.Key + "=" + item.Value + "&";
            }
            str += "key=wanguohao20150811abcwanguohaoabc";
            str = WXMD5Util(str).ToUpper();            
            return str;
        }
    }
}
