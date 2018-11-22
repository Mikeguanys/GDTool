using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Reflection;
using ThoughtWorks.QRCode.Codec;
using static GDataBase.GTEnum;

namespace GDataBase
{
    /// <summary>
    /// 静态方法类
    /// </summary>
    public static class MyStatesGTL
    {
        /// <summary>
        /// 获取Model Display的注释
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDisplayName(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DisplayAttribute[] attributes =
                  (DisplayAttribute[])fi.GetCustomAttributes(
                  typeof(DisplayAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Name : value.ToString();
        }
        /// <summary>   
        /// 水印合成图片  
        /// </summary>   
        /// <param name="sourcePicture">源图片文件名</param>   
        /// <param name="waterImage">水印图片文件名</param>   
        /// <param name="alpha">透明度(0.1-1.0数值越小透明度越高)</param>   
        /// <param name="position">位置</param>   
        /// <param name="PicturePath" >图片的路径</param>
        /// <param name="NewName" >图片文件</param>
        /// <returns>返回生成于指定文件夹下的水印文件名</returns>   
        public static string DrawImage(string sourcePicture, string waterImage, float alpha, ImagePosition position, string PicturePath, string NewName)
        {
            // 判断参数是否有效   
            if (sourcePicture == string.Empty || waterImage == string.Empty || alpha == 0.0 || PicturePath == string.Empty)
            {
                return sourcePicture;
            }
            // 源图片，水印图片全路径   
            string sourcePictureName = sourcePicture;
            string waterPictureName = waterImage;
            string fileSourceExtension = System.IO.Path.GetExtension(sourcePictureName).ToLower();
            string fileWaterExtension = System.IO.Path.GetExtension(waterPictureName).ToLower();
            // 判断文件是否存在,以及类型是否正确   
            if (System.IO.File.Exists(sourcePictureName) == false ||
                System.IO.File.Exists(waterPictureName) == false || (
                fileSourceExtension != ".gif" &&
                fileSourceExtension != ".jpg" &&
                fileSourceExtension != ".png") || (
                fileWaterExtension != ".gif" &&
                fileWaterExtension != ".jpg" &&
                fileWaterExtension != ".png")
                )
            {
                return sourcePicture = "未能找到本地图片";
            }
            // 目标图片名称及全路径   
            string targetImage = PicturePath + NewName + ".png";
            // 将需要加上水印的图片装载到Image对象中   
            System.Drawing.Image imgPhoto1 = System.Drawing.Image.FromFile(sourcePictureName);
            System.Drawing.Image imgPhoto = new System.Drawing.Bitmap(imgPhoto1);
            imgPhoto1.Dispose();
            // 确定其长宽   
            int phWidth = imgPhoto.Width;
            int phHeight = imgPhoto.Height;
            // 封装 GDI+ 位图，此位图由图形图像及其属性的像素数据组成。   
            Bitmap bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bmPhoto);
            g.FillRectangle(Brushes.White, new Rectangle(0, 0, phWidth, phHeight));
            // 设定分辨率   
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
            // 定义一个绘图画面用来装载位图   
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            //同样，由于水印是图片，我们也需要定义一个Image来装载它   
            System.Drawing.Image imgWatermark = new Bitmap(waterPictureName);
            // 获取水印图片的高度和宽度   
            int wmWidth = imgWatermark.Width;
            int wmHeight = imgWatermark.Height;
            //SmoothingMode：指定是否将平滑处理（消除锯齿）应用于直线、曲线和已填充区域的边缘。   
            // 成员名称   说明    
            // AntiAlias      指定消除锯齿的呈现。     
            // Default        指定不消除锯齿。     
            // HighQuality  指定高质量、低速度呈现。     
            // HighSpeed   指定高速度、低质量呈现。     
            // Invalid        指定一个无效模式。     
            // None          指定不消除锯齿。             
            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
            // 第一次描绘，将我们的底图描绘在绘图画面上   
            grPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, phWidth, phHeight), 0, 0, phWidth, phHeight, GraphicsUnit.Pixel);
            // 与底图一样，我们需要一个位图来装载水印图片。并设定其分辨率   
            Bitmap bmWatermark = new Bitmap(bmPhoto);
            bmWatermark.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
            // 继续，将水印图片装载到一个绘图画面grWatermark   
            Graphics grWatermark = Graphics.FromImage(bmWatermark);
            //ImageAttributes 对象包含有关在呈现时如何操作位图和图元文件颜色的信息。   
            ImageAttributes imageAttributes = new ImageAttributes();
            //Colormap: 定义转换颜色的映射   
            ColorMap colorMap = new ColorMap();
            //我的水印图被定义成拥有绿色背景色的图片被替换成透明   
            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };
            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);
            //颜色矩阵
            float[][] colorMatrixElements = {
            new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f}, // red红色   
            new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f}, //green绿色   
            new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f}, //blue蓝色          
            new float[] {0.0f,  0.0f,  0.0f,  alpha, 0.0f}, //透明度        
            new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}};//   
            //  ColorMatrix:定义包含 RGBA 空间坐标的 5 x 5 矩阵。   
            //  ImageAttributes 类的若干方法通过使用颜色矩阵调整图像颜色。   
            ColorMatrix wmColorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(wmColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            //上面设置完颜色，下面开始设置位置   
            int xPosOfWm;
            int yPosOfWm;

            switch (position)
            {
                case ImagePosition.BottomMiddle:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case ImagePosition.Center:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = (phHeight - wmHeight) / 2;
                    break;
                case ImagePosition.LeftBottom:
                    xPosOfWm = 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case ImagePosition.LeftTop:
                    xPosOfWm = 10;
                    yPosOfWm = 10;
                    break;
                case ImagePosition.RightTop:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = 10;
                    break;
                case ImagePosition.RigthBottom:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case ImagePosition.TopMiddle:
                    xPosOfWm = (phWidth - wmWidth) / 2;
                    yPosOfWm = 10;
                    break;
                default:
                    xPosOfWm = 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
            }
            // 第二次绘图，把水印印上去   
            grWatermark.DrawImage(imgWatermark,
             new Rectangle(xPosOfWm, yPosOfWm, wmWidth, wmHeight), 0, 0, wmWidth, wmHeight, GraphicsUnit.Pixel, imageAttributes);
            imgPhoto = bmWatermark;
            grPhoto.Dispose();
            grWatermark.Dispose();
            // 保存文件到服务器的文件夹里面   
            imgPhoto.Save(targetImage, ImageFormat.Jpeg);
            imgPhoto.Dispose();
            imgWatermark.Dispose();
            return targetImage.Replace(PicturePath, "");
        }
        /// <summary>   
        /// 文字水印   
        /// </summary>   
        /// <param name="sourcePicture">源图片文件</param>   
        /// <param name="waterWords">需要添加到图片上的文字</param>   
        /// <param name="alpha">透明度</param>   
        /// <param name="position">位置</param>   
        /// <param name="PicturePath">文件路径</param>   
        /// <returns></returns>
        public static string DrawWords(string sourcePicture, string waterWords, float alpha, ImagePosition position, string PicturePath)
        {
            //   
            // 判断参数是否有效   
            //   
            if (sourcePicture == string.Empty || waterWords == string.Empty || alpha == 0.0 || PicturePath == string.Empty)
            {
                return sourcePicture;
            }

            //   
            // 源图片全路径   
            //   
            string sourcePictureName = PicturePath + sourcePicture;
            string fileExtension = System.IO.Path.GetExtension(sourcePictureName).ToLower();

            //   
            // 判断文件是否存在,以及文件名是否正确   
            //   
            if (System.IO.File.Exists(sourcePictureName) == false || (
                fileExtension != ".gif" &&
                fileExtension != ".jpg" &&
                fileExtension != ".png"))
            {
                return sourcePicture;
            }

            //   
            // 目标图片名称及全路径   
            //   
            string targetImage = sourcePictureName.Replace(System.IO.Path.GetExtension(sourcePictureName), "") + ".jpg";

            //创建一个图片对象用来装载要被添加水印的图片   
            System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(sourcePictureName);

            //获取图片的宽和高   
            int phWidth = imgPhoto.Width;
            int phHeight = imgPhoto.Height;

            //   
            //建立一个bitmap，和我们需要加水印的图片一样大小   
            Bitmap bmPhoto = new Bitmap(phWidth, phHeight, PixelFormat.Format24bppRgb);

            //SetResolution：设置此 Bitmap 的分辨率   
            //这里直接将我们需要添加水印的图片的分辨率赋给了bitmap   
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            //Graphics：封装一个 GDI+ 绘图图面。   
            Graphics grPhoto = Graphics.FromImage(bmPhoto);

            //设置图形的品质   
            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;

            //将我们要添加水印的图片按照原始大小描绘（复制）到图形中   
            grPhoto.DrawImage(
             imgPhoto,                                           //   要添加水印的图片   
             new Rectangle(0, 0, phWidth, phHeight), //  根据要添加的水印图片的宽和高   
             0,                                                     //  X方向从0点开始描绘   
             0,                                                     // Y方向    
             phWidth,                                            //  X方向描绘长度   
             phHeight,                                           //  Y方向描绘长度   
             GraphicsUnit.Pixel);                              // 描绘的单位，这里用的是像素   

            //根据图片的大小我们来确定添加上去的文字的大小   
            //在这里我们定义一个数组来确定   
            int[] sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };

            //字体   
            Font crFont = null;
            //矩形的宽度和高度，SizeF有三个属性，分别为Height高，width宽，IsEmpty是否为空   
            SizeF crSize = new SizeF();

            //利用一个循环语句来选择我们要添加文字的型号   
            //直到它的长度比图片的宽度小   
            for (int i = 0; i < 7; i++)
            {
                crFont = new Font("arial", sizes[i], FontStyle.Bold);

                //测量用指定的 Font 对象绘制并用指定的 StringFormat 对象格式化的指定字符串。   
                crSize = grPhoto.MeasureString(waterWords, crFont);

                // ushort 关键字表示一种整数数据类型   
                if ((ushort)crSize.Width < (ushort)phWidth)
                    break;
            }

            //截边5%的距离，定义文字显示(由于不同的图片显示的高和宽不同，所以按百分比截取)   
            int yPixlesFromBottom = (int)(phHeight * .05);

            //定义在图片上文字的位置   
            float wmHeight = crSize.Height;
            float wmWidth = crSize.Width;

            float xPosOfWm;
            float yPosOfWm;

            switch (position)
            {
                case ImagePosition.BottomMiddle:
                    xPosOfWm = phWidth / 2;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case ImagePosition.Center:
                    xPosOfWm = phWidth / 2;
                    yPosOfWm = phHeight / 2;
                    break;
                case ImagePosition.LeftBottom:
                    xPosOfWm = wmWidth;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case ImagePosition.LeftTop:
                    xPosOfWm = wmWidth / 2;
                    yPosOfWm = wmHeight / 2;
                    break;
                case ImagePosition.RightTop:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = wmHeight;
                    break;
                case ImagePosition.RigthBottom:
                    xPosOfWm = phWidth - wmWidth - 10;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
                case ImagePosition.TopMiddle:
                    xPosOfWm = phWidth / 2;
                    yPosOfWm = wmWidth;
                    break;
                default:
                    xPosOfWm = wmWidth;
                    yPosOfWm = phHeight - wmHeight - 10;
                    break;
            }

            //封装文本布局信息（如对齐、文字方向和 Tab 停靠位），显示操作（如省略号插入和国家标准 (National) 数字替换）和 OpenType 功能。   
            StringFormat StrFormat = new StringFormat();

            //定义需要印的文字居中对齐   
            StrFormat.Alignment = StringAlignment.Center;

            //SolidBrush:定义单色画笔。画笔用于填充图形形状，如矩形、椭圆、扇形、多边形和封闭路径。   
            //这个画笔为描绘阴影的画笔，呈灰色   
            int m_alpha = Convert.ToInt32(256 * alpha);
            SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(m_alpha, 0, 0, 0));

            //描绘文字信息，这个图层向右和向下偏移一个像素，表示阴影效果   
            //DrawString 在指定矩形并且用指定的 Brush 和 Font 对象绘制指定的文本字符串。   
            grPhoto.DrawString(waterWords,                                    //string of text   
                                       crFont,                                         //font   
                                       semiTransBrush2,                            //Brush   
                                       new PointF(xPosOfWm + 1, yPosOfWm + 1),  //Position   
                                       StrFormat);

            //从四个 ARGB 分量（alpha、红色、绿色和蓝色）值创建 Color 结构，这里设置透明度为153   
            //这个画笔为描绘正式文字的笔刷，呈白色   
            SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));

            //第二次绘制这个图形，建立在第一次描绘的基础上   
            grPhoto.DrawString(waterWords,                 //string of text   
                                       crFont,                                   //font   
                                       semiTransBrush,                           //Brush   
                                       new PointF(xPosOfWm, yPosOfWm),  //Position   
                                       StrFormat);

            //imgPhoto是我们建立的用来装载最终图形的Image对象   
            //bmPhoto是我们用来制作图形的容器，为Bitmap对象   
            imgPhoto = bmPhoto;
            //释放资源，将定义的Graphics实例grPhoto释放，grPhoto功德圆满   
            grPhoto.Dispose();

            //将grPhoto保存   
            imgPhoto.Save(targetImage, ImageFormat.Jpeg);
            imgPhoto.Dispose();

            return targetImage.Replace(PicturePath, "");
        }
        /// <summary>
        /// 创建并保存到本地
        /// </summary>
        /// <param name="content">二维码内容</param>
        /// <param name="path">保存路径</param>
        /// <param name="imagename">返回图片名</param>
        /// <returns></returns>
        public static string CreateQRCode(string content, string path, ref string imagename)
        {
            GDataBase.MyGT gt = new GDataBase.MyGT();
            if (string.IsNullOrEmpty(content))
            {
                return "";
            }
            string filename = string.Empty;
            string filepath = string.Empty;
            string txt_qr = content;
            string qrEncoding = "Byte";
            string Level = "L";
            string txt_ver = "10";
            string txt_size = "10";
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            String encoding = qrEncoding;
            if (encoding == "Byte")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            }
            else if (encoding == "AlphaNumeric")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
            }
            else if (encoding == "Numeric")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
            }
            try
            {
                int scale = Convert.ToInt16(txt_size);
                qrCodeEncoder.QRCodeScale = scale;
            }
            catch (Exception ex)
            {
                gt.WriteFile("生成二维码错误！");
            }

            try
            {
                int version = Convert.ToInt16(txt_ver);
                qrCodeEncoder.QRCodeVersion = version;
            }
            catch (Exception ex)
            {
                gt.WriteFile("生成二维码错误！");
            }
            qrCodeEncoder.QRCodeScale = 4;
            qrCodeEncoder.QRCodeVersion = 0;
            string errorCorrect = Level;
            if (errorCorrect == "L")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            else if (errorCorrect == "M")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            else if (errorCorrect == "Q")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
            else if (errorCorrect == "H")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string QRStr = string.Empty;
            if (string.IsNullOrEmpty(path))
            {
                QRStr = "CreateErr";
            }
            else
            {
                QRStr = DateTime.Now.ToString("yyyyMMddhhmmssffff");
            }
            filename = QRStr + ".jpg";

            System.Drawing.Image image;
            String data = txt_qr;
            image = qrCodeEncoder.Encode(data);
            filepath = path + "\\" + filename;
            System.IO.FileStream fs = new System.IO.FileStream(filepath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
            fs.Close();
            image.Dispose();
            imagename = filename;
            return path + "/" + filename;
        }
        /// <summary>
        /// 创建临时二维码画布
        /// </summary>
        /// <param name="content">二维码内容</param>
        /// <returns></returns>        
        public static Bitmap CreateTempQRCode(string content)
        {
            GDataBase.MyGT gt = new GDataBase.MyGT();
            if (string.IsNullOrEmpty(content))
            {
                return null;
            }
            string filename = string.Empty;
            string filepath = string.Empty;
            string txt_qr = content;
            string qrEncoding = "Byte";
            string Level = "L";
            string txt_ver = "10";
            string txt_size = "10";
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            String encoding = qrEncoding;
            if (encoding == "Byte")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            }
            else if (encoding == "AlphaNumeric")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
            }
            else if (encoding == "Numeric")
            {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;
            }

            try
            {
                int scale = Convert.ToInt16(txt_size);
                qrCodeEncoder.QRCodeScale = scale;
            }
            catch (Exception ex)
            {
                gt.WriteFile(ex.Message);
            }

            try
            {
                int version = Convert.ToInt16(txt_ver);
                qrCodeEncoder.QRCodeVersion = version;
            }
            catch (Exception ex)
            {
                gt.WriteFile(ex.Message);
            }
            qrCodeEncoder.QRCodeScale = 4;
            qrCodeEncoder.QRCodeVersion = 0;
            string errorCorrect = Level;
            if (errorCorrect == "L")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            else if (errorCorrect == "M")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            else if (errorCorrect == "Q")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
            else if (errorCorrect == "H")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
            String data = txt_qr;
            return qrCodeEncoder.Encode(data);
        }
        public static Bitmap Create(string content)
        {
            try
            {
                QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
                qRCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;//设置二维码编码格式 
                qRCodeEncoder.QRCodeScale = 7;//设置编码测量度             
                qRCodeEncoder.QRCodeVersion = 7;//设置编码版本   
                qRCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;//设置错误校验 

                Bitmap image = qRCodeEncoder.Encode(content);
                return image;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 获取本地图片
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static Bitmap GetLocalLog(string fileName)
        {
            Bitmap newBmp = new Bitmap(fileName);
            //Bitmap bmp = new Bitmap(newBmp);
            return newBmp;
        }
        /// <summary>
        /// 生成带logo二维码
        /// </summary>
        /// <returns></returns>
        public static Bitmap CreateQRCodeWithLogo(string content, string logopath)
        {
            //生成二维码
            Bitmap qrcode = Create(content);
            //生成logo
            Bitmap logo = GetLocalLog(logopath);
            ImageUtility util = new ImageUtility();
            Bitmap finalImage = util.MergeQrImg(qrcode, logo);
            return finalImage;
        }
        /// <summary>
        /// 生成带logo二维码
        /// </summary>
        /// <returns></returns>
        public static Bitmap CreateQRCodeWithLogo(string content, Bitmap Image)
        {
            //生成二维码
            Bitmap qrcode = Create(content);
            //生成logo
            Bitmap logo = Image;
            ImageUtility util = new ImageUtility();
            Bitmap finalImage = util.MergeQrImg(qrcode, logo);
            return finalImage;
        }
        /// <summary>
        /// 获取网络图片
        /// </summary>
        /// <param name="Image"></param>
        /// <returns></returns>
        public static Bitmap GetWebImg(this string Image)
        {
            Bitmap img = null;
            HttpWebRequest req;
            HttpWebResponse res = null;
            try
            {
                System.Uri httpUrl = new System.Uri(Image);
                req = (HttpWebRequest)(WebRequest.Create(httpUrl));
                req.Timeout = 180000; //设置超时值10秒
                //req.UserAgent = "XXXXX";
                //req.Accept = "XXXXXX";
                MemoryStream ms = new MemoryStream();
                req.Method = "GET";
                res = (HttpWebResponse)(req.GetResponse());
                img = new Bitmap(res.GetResponseStream());
            }

            catch (Exception ex)
            {
                string aa = ex.Message;
            }
            finally
            {
                res.Close();
            }
            return img;
        }
        /// <summary>
        /// JSON转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToModel<T>(this string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            T t = o as T;
            return t;
        }
        /// <summary>
        /// JSON转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> JsonToListModel<T>(this string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            List<T> list = o as List<T>;
            return list;
        }
    }
}
