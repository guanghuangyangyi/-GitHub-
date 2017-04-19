using System.Text;

namespace Commons
{
    public class StringUtitly
    {
        /// <summary>
        /// 拼接字符串的方法
        /// 1.简单 “+=” 拼接法
        /// string是引用类型，保留在堆上，而不是栈上，用的时候传的是内存中的地址，每次修改就会重新创建一个新的string对象来存储字符串，原有的会被自动回收。
        /// 2.String.Format()
        /// 先创建一个StringBuilder类型的变量，长度为第一个参数的长度+参数长度的8倍。.Net自动分配一个比较大的容量来存储。
        /// 3.StringBuilder.Append
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static string Jonint(params string[] str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in str)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }
    }
}
