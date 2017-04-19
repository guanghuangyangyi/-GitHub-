//**************************************************************
//文件名称（File Name）                 ValidateCode.cs
//作者(Author)                          叶金清
//日期（Create Date）                   2017.03.24
//修改记录(Revision History)
//    R1:
//        修改作者:
//        修改日期:
//        修改原因:
//    R2:
//        修改作者:
//        修改日期:
//        修改原因:
//**************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;

namespace Commons
{
    /// <summary>
    /// 图片验证码
    /// </summary>
    public class ValidateCode
    {
        // 图片的宽度和高度
        private int width = 95;
        private int height = 40;
        // 验证码字符个数
        private int codeCount = 4;
        // 验证码干扰线
        private int lineCount = 25;
        // 验证码
        private string code = string.Empty;
        //字体的大小
        private int fontSize = 22;
        // 验证码字符序列 注意:为了降低难度可以把i和l,o和0排除掉
        private char[] codeSequence = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U',
            'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7',
            '8', '9', };
        #region 构造器
        /// <summary>
        /// 无参构造器(使用默认的)
        /// </summary>
        public ValidateCode()
        {

        }
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="width">验证码图片的宽度</param>
        /// <param name="height">验证码图片的高</param>
        /// <param name="codeCount">验证码字符的个数</param>
        /// <param name="lineCount">验证码干扰线的数量</param>
        public ValidateCode(int width, int height, int codeCount, int lineCount)
        {
            this.width = width;
            this.height = height;
            this.codeCount = codeCount;
            this.lineCount = lineCount;
        }
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="width">验证码图片的宽度</param>
        /// <param name="height">验证码图片的高</param>
        /// <param name="codeCount">验证码字符的个数</param>
        /// <param name="lineCount">验证码干扰线的数量</param>
        /// <param name="codeStr">验证码字符的来源</param>
        public ValidateCode(int width, int height, int codeCount, int lineCount, string codeStr)
        {
            this.width = width;
            this.height = height;
            this.codeCount = codeCount;
            this.lineCount = lineCount;
            this.codeSequence = codeStr.ToCharArray();
        }
        #endregion
        #region 生成验证码
        /// <summary>
        /// 产生验证码
        /// </summary>
        /// <param name="count">验证码的位数</param>
        /// <returns>验证码</returns>
        public string CreateCode(int count)
        {
            //随机数生成器
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            //生成验证码
            for (int i = 0; i < count; i++)
            {
                //从验证码的仓库(验证码字符序列)中随机取出一个字符
                sb.Append(codeSequence[random.Next(codeSequence.Length)].ToString());
            }
            code = sb.ToString();
            return code;
        }
        public string CreateCode()
        {
            //随机数生成器
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            //生成验证码
            for (int i = 0; i < codeCount; i++)
            {
                //从验证码的仓库(验证码字符序列)中随机取出一个字符
                sb.Append(codeSequence[random.Next(codeSequence.Length)].ToString());
            }
            code = sb.ToString();
            return code;
        }
        #endregion
        #region 根据验证码生成图片
        /// <summary>
        /// 把验证码字符生成验证码图片
        /// </summary>
        /// <param name="context"></param>
        public void CreateValidateGraphic(HttpContext context)
        {
            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                int x1;
                int x2;
                int y1;
                int y2;
                int red;
                int green;
                int blue;
                //画图片的干扰线
                for (int i = 0; i < lineCount; i++)
                {
                    x1 = random.Next(image.Width);
                    x2 = random.Next(image.Width);
                    y1 = random.Next(image.Height);
                    y2 = random.Next(image.Height);
                    red = random.Next(255);
                    green = random.Next(255);
                    blue = random.Next(255);
                    g.DrawLine(new Pen(Color.FromArgb(red, green, blue)), x1, y1, x2, y2);
                }
                //字体
                Font font = new Font("Arial", fontSize, (FontStyle.Bold | FontStyle.Italic));
                //线性渐变
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                //把验证码字符画到图片中
                g.DrawString(code, font, brush, 3, 2);
                //画图片的前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                context.Response.Clear();
                context.Response.ContentType = "image/jpeg";
                context.Response.BinaryWrite(stream.ToArray());

            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                //关闭资源
                g.Dispose();
                image.Dispose();
            }

        }

        /// <summary>
        /// 把验证码字符生成验证码图片
        /// </summary>
        /// <returns></returns>
        public byte[] CreateValidateGraphic()
        {
            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                int x1;
                int x2;
                int y1;
                int y2;
                int red;
                int green;
                int blue;
                //画图片的干扰线
                for (int i = 0; i < lineCount; i++)
                {
                    x1 = random.Next(image.Width);
                    x2 = random.Next(image.Width);
                    y1 = random.Next(image.Height);
                    y2 = random.Next(image.Height);
                    red = random.Next(255);
                    green = random.Next(255);
                    blue = random.Next(255);
                    g.DrawLine(new Pen(Color.FromArgb(red, green, blue)), x1, y1, x2, y2);
                }
                //字体
                Font font = new Font("Arial", fontSize, (FontStyle.Bold | FontStyle.Italic));
                
                //线性渐变
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);

                //把验证码字符画到图片中
                
                g.DrawString(code, font, brush, 3, 2);
                //画图片的前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);
                //输出图片流
                return stream.ToArray();

            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                //关闭资源
                g.Dispose();
                image.Dispose();
            }

        }
        #endregion
    }
}
