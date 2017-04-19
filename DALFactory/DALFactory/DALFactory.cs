using Commons;
using MyCache;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
    public class DALFactory<T>
    {
        /// <summary>
        /// 获取bll对象
        /// </summary>
        /// <param name="className"></param>
        public static T GetBllObject( T t)
        {
            object obj =null;
            try
            {
                string className = t.GetType().Name;
                //DAL所在的程序集  这里是DAL
                string DALAssembly = (string)CacheUtil.GetCache("DALAssembly");
                if (string.IsNullOrWhiteSpace(DALAssembly))
                {
                    DALAssembly = ConfigurationManager.AppSettings["DALAssembly"];
                    CacheUtil.SetCache(DALAssembly, DALAssembly);
                }

                //DAL.TestEFDal
                string assemblyPath = (string)CacheUtil.GetCache("assemblyPath");
                if (string.IsNullOrWhiteSpace(assemblyPath))
                {
                    //DAL的命名空间   这里是DAL
                    string DALNameSpace = (string)CacheUtil.GetCache("DALNameSpace");
                    if (string.IsNullOrWhiteSpace(DALNameSpace))
                    {
                        DALNameSpace = ConfigurationManager.AppSettings["DALNameSpace"];
                        CacheUtil.SetCache(DALNameSpace, DALNameSpace);
                    }

                    //数据层的后缀也就是使用了那种数据源 这里是 EF
                    string DALSuffix = (string)CacheUtil.GetCache("DALSuffix");
                    if (string.IsNullOrWhiteSpace(DALSuffix))
                    {
                        DALSuffix = ConfigurationManager.AppSettings["DALSuffix"];
                        CacheUtil.SetCache(DALSuffix, DALSuffix);
                    }
                    assemblyPath = StringUtitly.Jonint(DALNameSpace, ".", className, DALSuffix, "Dal");
                }
                var cache = CacheUtil.GetCache(className);
                if (cache == null)
                {
                    //要执行反射的a与要得到的对象b如果是在同一命名空间则
                    //System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("命名空间.类名", false);
                    //var b= Assembly.GetExecutingAssembly().CreateInstance("HCPexip.IDao.DaoCache", false);
                    //不在同一命名空间下
                    //System.Reflection.Assembly.Load("程序集名称").CreateInstance("命名空间.类名", false);
                    obj = (T)Assembly.Load(DALAssembly).CreateInstance(assemblyPath);
                    CacheUtil.SetCache(StringUtitly.Jonint("DAL", className), obj);
                }
            }
            catch (System.Exception ex)
            {
                //进行捕获异常/打印异常信息/记录日志
                obj= null;
            }
            return (T)obj;
        }
    }
}
