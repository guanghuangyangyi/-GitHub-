using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCache
{
    public interface IHttpRunTimeCacheManager
    {
        /// <summary>
        /// 往缓存写数据
        /// </summary> 
        /// <param name="key">缓存的键值</param>
        /// <param name="obj">要放入缓存的数据</param>
        /// <param name="sqlDependncy">与数据库依赖的对象</param>
        void AddRunTimeCache(string key, Object obj, System.Web.Caching.SqlCacheDependency sqlDependncy);

        /// <summary>
        ///  获取运行时的缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object GetRunTimeCache(string key);

        /// <summary>
        /// 移除运行时缓存对象
        /// </summary>
        /// <param name="key"></param>
        void RemoveRuntimeCache(string key);

    }
}
