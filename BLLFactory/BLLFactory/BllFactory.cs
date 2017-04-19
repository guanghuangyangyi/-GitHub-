using Commons;
using MyCache;
using System.Configuration;
using System.Reflection;

namespace BLLFactory
{
    public class BllFactory<T>
    {
        /// <summary>
        /// 获取bll对象
        /// </summary>
        /// <param name="className"></param>
        public static T GetBllObject(T t)
        {
            object obj=null;
            try
            {
                string className = t.GetType().Name;
                //DAL所在的程序集
                string BLLAssembly = (string)CacheUtil.GetCache("BLLAssembly");
                if (string.IsNullOrWhiteSpace(BLLAssembly))
                {
                    BLLAssembly = ConfigurationManager.AppSettings["BLLAssembly"];
                    CacheUtil.SetCache(BLLAssembly, BLLAssembly);
                }

                //BLL.TestBll
                string assemblyPath=(string)CacheUtil.GetCache("assemblyPath");
                if (string.IsNullOrWhiteSpace(assemblyPath))
                {
                    //DAL的命名空间   这里是DAL
                    string BLLNameSpace = (string)CacheUtil.GetCache("BLLNameSpace");
                    if (string.IsNullOrWhiteSpace(BLLNameSpace))
                    {
                        BLLNameSpace = ConfigurationManager.AppSettings["BLLNameSpace"];
                        CacheUtil.SetCache(BLLNameSpace, BLLNameSpace);
                    }
                   
                    assemblyPath = StringUtitly.Jonint(BLLNameSpace, ".", className,"Bll");
                    CacheUtil.SetCache(assemblyPath, assemblyPath);
                }
                
                var cache = CacheUtil.GetCache(className);
                if (cache == null)
                {
                    //要执行反射的a与要得到的对象b如果是在同一命名空间则
                    //System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("命名空间.类名", false);
                    //var b= Assembly.GetExecutingAssembly().CreateInstance("HCPexip.IDao.DaoCache", false);
                    //不在同一命名空间下
                    //System.Reflection.Assembly.Load("程序集名称").CreateInstance("命名空间.类名", false);
                    obj = (T)Assembly.Load(BLLAssembly).CreateInstance(assemblyPath);
                    CacheUtil.SetCache(StringUtitly.Jonint("DAL",className),obj);
                    
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
