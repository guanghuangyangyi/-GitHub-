

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Model;

namespace 控制台测试
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ///ITestBll test = BllFactory.GetBllObject("Test") as TestBll;
                Test test = new Test();
                //var a=test.GetType().Name;
                //var b = test.GetType().FullName;
                Func<string ,string> a = x =>  x ;
                Func<string> b = ()=> "";
                Console.WriteLine(a("aa"));
                Console.WriteLine(b());
            }
            catch (Exception e)
            {

                throw;
            }
           
        }
    

    }

   
}
