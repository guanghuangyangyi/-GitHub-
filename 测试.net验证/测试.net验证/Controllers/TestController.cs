using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 测试.net验证.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            string[] str = new string[4];
            string serverCode = "";
            //生成随机生成器 
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                str[i] = random.Next(10).ToString().Substring(0, 1);
            }
            CreateCheckCodeImage(str);
            foreach (string s in str)
            {
                serverCode += s;
            }
            return null;
        }

        private void CreateCheckCodeImage(string[] checkCode)
        {
            if (checkCode == null || checkCode.Length <= 0)
                return;

            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 32.5)), 30);
            System.Drawing.Graphics g = Graphics.FromImage(image);

            try
            {
                Random random = new Random();
                //清空图片背景色 
                g.Clear(Color.White);

                //画图片的背景噪音线 
                for (int i = 0; i < 20; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);

                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                //定义颜色
                Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
                //定义字体
                string[] f = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };

                for (int k = 0; k <= checkCode.Length - 1; k++)
                {
                    int cindex = random.Next(7);
                    int findex = random.Next(5);

                    Font drawFont = new Font(f[findex], 16, (System.Drawing.FontStyle.Bold));



                    SolidBrush drawBrush = new SolidBrush(c[cindex]);

                    float x = 5.0F;
                    float y = 0.0F;
                    float width = 20.0F;
                    float height = 25.0F;
                    int sjx = random.Next(10);
                    int sjy = random.Next(image.Height - (int)height);

                    RectangleF drawRect = new RectangleF(x + sjx + (k * 25), y + sjy, width, height);

                    StringFormat drawFormat = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Center;

                    g.DrawString(checkCode[k], drawFont, drawBrush, drawRect, drawFormat);
                }

                //画图片的前景噪音点 
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //画图片的边框线 
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                Response.ClearContent();
                Response.ContentType = "image/Gif";
                Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }




        /// <summary>
        /// 生成内存位图
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public static Bitmap GetCode(out string Code)
        {
            int imgWidth = 80;
            int imgHeight = 40;
            //获取随机字符
            //Code = DateTimeHelper.GetCode_Ran(4);
            Code = "1234";
            //颜色列表，用于验证码、噪线、噪点 
            Color[] color = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };
            //字体列表，用于验证码 
            string[] font = { "Times New Roman", "MS Mincho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact" };

            Bitmap bmp = new Bitmap(imgWidth, imgHeight);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            Random rnd = new Random();
            //画噪线 
            for (int i = 0; i < 10; i++)
            {
                int x1 = rnd.Next(imgWidth);
                int y1 = rnd.Next(imgHeight);
                int x2 = rnd.Next(imgWidth);
                int y2 = rnd.Next(imgHeight);
                Color clr = color[rnd.Next(color.Length)];
                g.DrawLine(new Pen(clr), x1, y1, x2, y2);
            }
            //画验证码字符串 
            for (int i = 0; i < Code.Length; i++)
            {
                string fnt = font[rnd.Next(font.Length)];
                Font ft = new Font(fnt, 18);
                Color clr = color[rnd.Next(color.Length)];
                g.DrawString(Code[i].ToString(), ft, new SolidBrush(clr), (float)i * 19, (float)8);
            }
            //画噪点 
            for (int i = 0; i < 100; i++)
            {
                int x = rnd.Next(bmp.Width);
                int y = rnd.Next(bmp.Height);
                Color clr = color[rnd.Next(color.Length)];
                bmp.SetPixel(x, y, clr);
            }
            //显式释放资源 
            // bmp.Dispose();
            g.Dispose();
            return bmp;
        }
        /// <summary>
        /// 生成位图，输出到响应流
        /// </summary>
        /// <param name="Response"></param>
        /// <param name="Code"></param>
        public static void GetCode(HttpResponseBase Response, out string Code)
        {
            Code = string.Empty;
            Bitmap bit = GetCode(out Code);

            ////清除该页输出缓存，设置该页无缓存 
            //Response.Buffer = true;
            //Response.ExpiresAbsolute = DateTime.Now.AddMilliseconds(0);
            //Response.Expires = 0;
            //Response.CacheControl = "no-cache";
            //Response.AppendHeader("Pragma", "No-Cache");

            Response.ClearContent();
            bit.Save(Response.OutputStream, ImageFormat.Png);
            Response.ContentType = "image/png";

            //释放资源
            bit.Dispose();
        }

        public ActionResult test1()
        {
            Commons.ValidateCode ValidateCode = new Commons.ValidateCode();

            string code = ValidateCode.CreateCode(4);//生成验证码，传几就是几位验证码
            Session["code"] = code;
            byte[] buffer = ValidateCode.CreateValidateGraphic();//把验证码画到画布
            return File(buffer, "image/jpeg");
        }
    }

    
}