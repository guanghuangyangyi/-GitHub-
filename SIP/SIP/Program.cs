using Independentsoft.Sip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIP
{
    class Program
    {
        static void Main(string[] args)
        {
            //开源sip服务器 mysipswitch

            //身份验证失败时抛出的异常
            throw new AuthenticationException();
            //连接异常
            throw new ConnectionException();
        }
    }
}
