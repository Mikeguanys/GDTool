using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace GDataBase
{
    /// <summary>
    /// GT工具库
    /// </summary>
    public class MyGT
    {
        /// <summary>
        /// 写入文本/默认路径在本项目bin目录下面
        /// </summary>
        /// <param name="txt"></param>
        public void WriteFile(string txt)
        {
            try
            {
                string filepath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "bin\\Error_log.txt";
                string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "bin";

                if (!File.Exists(filepath))
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    File.Create(filepath).Close();
                }
                using (FileStream fs = new FileStream(filepath, FileMode.Append))
                {
                    //获得字节数组
                    byte[] data = System.Text.Encoding.Default.GetBytes(txt);
                    //开始写入
                    fs.Write(data, 0, data.Length);
                    //清空缓冲区、关闭流
                }
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 记录写入
        /// </summary>
        /// <param name="txt">写入内容</param>
        /// <param name="path">路径（E:\）</param>
        public void WriteFile(string txt, string path)
        {
            try
            {
                string filepath = string.Empty;
                string filepath1 = string.Empty;
                if (path.IndexOf('.') > -1)
                {
                    filepath1 = path.Substring(0, path.IndexOf('.'));
                    filepath = filepath1 + "\\";

                }
                else
                {
                    filepath1 = path;
                    filepath = path;
                }
                filepath += "Message.txt";

                if (!File.Exists(filepath))
                {
                    if (!Directory.Exists(filepath1))
                    {
                        Directory.CreateDirectory(filepath1);
                    }
                    File.Create(filepath).Close();
                }
                using (FileStream fs = new FileStream(filepath, FileMode.Append))
                {
                    //获得字节数组
                    byte[] data = System.Text.Encoding.Default.GetBytes(txt);
                    //开始写入
                    fs.Write(data, 0, data.Length);
                    //清空缓冲区、关闭流
                }

            }
            catch
            {

            }
        }
        /// <summary>
        /// 记录写入
        /// </summary>
        /// <param name="txt">写入内容</param>
        /// <param name="path">文件路径</param>
        /// <param name="filename">文件名</param>
        public void WriteFile(string txt, string path, string filename)
        {
            try
            {
                string filepath = string.Empty;
                string filepath1 = string.Empty;
                if (path.IndexOf('.') > -1)
                {
                    filepath1 = path.Substring(0, path.IndexOf('.'));
                    filepath = filepath1 + "\\";

                }
                else
                {
                    filepath1 = path;
                    filepath = path;
                }
                filepath += filename + ".txt";

                if (!File.Exists(filepath))
                {
                    if (!Directory.Exists(filepath1))
                    {
                        Directory.CreateDirectory(filepath1);
                    }
                    File.Create(filepath).Close();
                }
                using (FileStream fs = new FileStream(filepath, FileMode.Append))
                {
                    //获得字节数组
                    byte[] data = System.Text.Encoding.Default.GetBytes(txt);
                    //开始写入
                    fs.Write(data, 0, data.Length);
                    //清空缓冲区、关闭流
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 后缀自定义
        /// </summary>
        /// <param name="txt">写入内容</param>
        /// <param name="path">文件路径</param>
        /// <param name="filename">文件名</param>
        public void WriteAnyFile(string txt, string path, string filename)
        {
            try
            {
                string filepath = string.Empty;
                string filepath1 = string.Empty;
                if (path.IndexOf('.') > -1)
                {
                    filepath1 = path.Substring(0, path.IndexOf('.'));
                    filepath = filepath1 + "\\";

                }
                else
                {
                    filepath1 = path;
                    filepath = path;
                }
                filepath += filename;

                if (!File.Exists(filepath))
                {
                    if (!Directory.Exists(filepath1))
                    {
                        Directory.CreateDirectory(filepath1);
                    }
                    File.Create(filepath).Close();
                }
                using (FileStream fs = new FileStream(filepath, FileMode.Append))
                {
                    //获得字节数组
                    byte[] data = System.Text.Encoding.Default.GetBytes(txt);
                    //开始写入
                    fs.Write(data, 0, data.Length);
                    //清空缓冲区、关闭流
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 将数据Post到接口里
        /// </summary>
        /// <param name="url">一般是带https方式</param>
        /// <param name="data">要post的数据，转化为utf-8格式。如果没有数据则为空</param>
        /// <returns></returns>
        public string WebRequestPost(string url, string data)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "POST";

                if (!string.IsNullOrEmpty(data))
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(data); // 转化
                    webRequest.ContentLength = byteArray.Length;
                    Stream newStream = webRequest.GetRequestStream();
                    newStream.Write(byteArray, 0, byteArray.Length); //写入参数
                    newStream.Close();
                }
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                //StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return sr.ReadToEnd();
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 将数据Post到接口里带证书的
        /// </summary>
        /// <param name="url">一般是带https方式</param>
        /// <param name="data">要post的数据，转化为utf-8格式。如果没有数据则为空</param>
        /// <returns></returns>
        public string WebRequestPost(string url, string data, X509Certificate keyku)
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.ClientCertificates.Add(keyku);
                webRequest.Method = "POST";

                if (!string.IsNullOrEmpty(data))
                {
                    byte[] byteArray = Encoding.UTF8.GetBytes(data); // 转化
                    webRequest.ContentLength = byteArray.Length;
                    Stream newStream = webRequest.GetRequestStream();
                    newStream.Write(byteArray, 0, byteArray.Length); //写入参数
                    newStream.Close();
                }
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                //StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                return sr.ReadToEnd();
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 获取接口数据
        /// </summary>
        /// <param name="url">接口</param>
        /// <param name="Type">返回的是json，还是xml</param>
        /// <returns></returns>
        public string GetJsonPostData(string url)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            // 要注意的这是这个编码方式，还有内容的Xml内容的编码方式  
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            byte[] data = encoding.GetBytes(url);

            // 准备请求,设置参数  
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            //request.ContentType = "text/plain";  
            request.ContentLength = data.Length;

            outstream = request.GetRequestStream();
            outstream.Write(data, 0, data.Length);
            outstream.Flush();
            outstream.Close();
            //发送请求并获取相应回应数据  
            response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求  
            instream = response.GetResponseStream();
            sr = new StreamReader(instream, encoding);
            //返回结果网页Class1.cs(html)代码  
            string content = sr.ReadToEnd();
            return content;
        }

        /// <summary>
        /// 将DataTable转化成Json格式 
        /// </summary>
        /// <param name="dt">DataTable 数据源</param>
        /// <returns></returns>
        public string DataTableToJsoin(DataTable dt)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            System.Collections.ArrayList dic = new System.Collections.ArrayList();
            foreach (DataRow dr in dt.Rows)
            {
                System.Collections.Generic.Dictionary<string, object> drow = new System.Collections.Generic.Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    drow.Add(dc.ColumnName, dr[dc.ColumnName]);
                }
                dic.Add(drow);

            }
            return jss.Serialize(dic);
        }
        /// <summary>
        /// 后台Json获取某个Json的值（只支持一层Json{a:1,b:2,c:3}）
        /// </summary>
        /// <param name="jsonData">json数据源</param>
        /// <param name="columName">json的字段</param>
        /// <returns></returns>
        public string JsonToDictionary(string jsonData, string columName)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                Dictionary<string, object> dic = jss.Deserialize<Dictionary<string, object>>(jsonData);
                if (!dic.ContainsKey(columName))
                {
                    return null;
                }
                else
                {
                    return dic[columName].ToString();
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Xml 转化成Json
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public string XmlToJson(XmlDocument xml)
        {
            return JsonConvert.SerializeXmlNode(xml);
        }
        /// <summary>
        /// Json转化成Xml
        /// </summary>
        /// <param name="Jsondata"></param>
        /// <returns></returns>
        public XmlDocument JsonToXml(string Jsondata)
        {
            return JsonConvert.DeserializeXmlNode(Jsondata);
        }
        /// <summary>
        /// Json转换成对象
        /// </summary>
        /// <param name="jsondata"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object JsonToObject(string jsondata, object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());

            MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsondata));

            return serializer.ReadObject(mStream);
        }
        /// <summary>
        /// 对象转化成Json
        /// </summary>        
        /// <param name="obj"></param>
        /// <returns></returns>
        public string ObjectToJson(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());

            MemoryStream stream = new MemoryStream();

            serializer.WriteObject(stream, obj);

            byte[] dataBytes = new byte[stream.Length];

            stream.Position = 0;

            stream.Read(dataBytes, 0, (int)stream.Length);

            return Encoding.UTF8.GetString(dataBytes);
        }
        /// <summary>
        /// 对象转化成XML
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string XMLSerialize<T>(T entity)
        {
            StringBuilder buffer = new StringBuilder();
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (TextWriter writer = new StringWriter(buffer))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(writer, entity, ns);
            }
            return buffer.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "").Trim();
        }
        /// <summary>
        /// String Xml转化成Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public T DeXMLSerialize<T>(string xmlString)
        {
            T cloneObject = default(T);

            StringBuilder buffer = new StringBuilder();
            buffer.Append(xmlString);

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (TextReader reader = new StringReader(buffer.ToString()))
            {
                Object obj = serializer.Deserialize(reader);
                cloneObject = (T)obj;
            }
            return cloneObject;
        }
        /// <summary>
        /// MD5 16位加密
        /// </summary>
        /// <param name="Str">加密的参数</param>
        /// <returns></returns>
        public string ToMD5_16(string Str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(Str)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }
        /// <summary>
        /// MD5 32位加密小写
        /// </summary>
        /// <param name="Str">加密的参数</param>
        /// <returns></returns>
        public string ToMD5_32(string Str)
        {
            string pwd = string.Empty;
            string getUTF = string.Empty;
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(Str));
            for (int i = 0; i < s.Length; i++)
            {
                getUTF = s[i].ToString("x");
                if (getUTF.Length == 1)
                {
                    pwd = pwd + "0" + getUTF;
                }
                else
                {
                    pwd = pwd + getUTF;
                }
            }
            return pwd;
        }
        /// <summary>
        /// MD532位大写
        /// </summary>
        /// <returns></returns>
        public string ToMD5_32_Capital(string Str)
        {
            string pwd = string.Empty;
            string getUTF = string.Empty;
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(Str));
            for (int i = 0; i < s.Length; i++)
            {
                getUTF = s[i].ToString("X");
                if (getUTF.Length == 1)
                {
                    pwd = pwd + "0" + s[i];
                }
                else
                {
                    pwd = pwd + getUTF;
                }
            }
            return pwd;
        }
        /// <summary>
        /// Base64位加密
        /// 有必要可以自己实现加密方式
        /// </summary>
        /// <param name="Str">加密参数</param>
        /// <returns></returns>
        public string ToBase64(string Str)
        {
            return Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(Str));
        }
        /// <summary>
        /// Base64位解密
        /// 需要输入参数s为base-64编码格式解密失败将会为null
        /// </summary>
        /// <param name="Str">解密参数</param>
        /// <returns></returns>
        public string DecBase64(string Str)
        {
            try
            {
                return Encoding.Default.GetString(Convert.FromBase64String(Str));
            }
            catch
            {
                return null;
            }
        }
    }
}
