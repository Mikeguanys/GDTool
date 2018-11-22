using System;
using System.IO;

namespace GDateBase2v.GDTools
{
    public static class GDRecord
    {
        /// <summary>
        /// 写入文本/默认路径在本项目bin目录下面
        /// </summary>
        /// <param name="txt"></param>
        public static void WriteFile(this string txt)
        {
            try
            {
                string filepath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "bin\\Error_log.txt";
                string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "bin";

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
            catch
            {

            }
        }
        /// <summary>
        /// 记录写入
        /// </summary>
        /// <param name="txt">写入内容</param>
        /// <param name="path">路径（E:\）</param>
        public static void WriteFile(this string txt, string path)
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
        public static void WriteFile(this string txt, string path, string filename)
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
    }
}
