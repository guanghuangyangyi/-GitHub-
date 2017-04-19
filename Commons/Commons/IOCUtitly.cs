using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public class IOCUtitly
    {
        public void GetDalObject<T>(string className)
        {
            T t;
            string dalName;
            string fullClassName;
            //dal的命名空间
            string DALNameSpace = ConfigurationManager.AppSettings["DALNameSpace"];
            fullClassName = StringUtitly.Jonint( DALNameSpace , "." , className);
            //通过反射，取得数据访问层对象  
            //t = Assembly.Load(dalName).CreateInstance(fullClassName) as T;

        }
    }
}
