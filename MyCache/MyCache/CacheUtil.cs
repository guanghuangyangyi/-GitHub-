using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace MyCache
{
    public class CacheUtil
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public CacheUtil()
        {

        }
        #endregion

        #region 操作缓存
        /// <summary>
        /// 根据key获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetCache(string key)
        {
            Cache cache = HttpRuntime.Cache;
            return cache.Get(key);
        }

        /// <summary>
        ///插入缓存 
        /// </summary>
        /// <param name="key">缓存的key</param>
        /// <param name="obj">缓存的value</param>
        public static void SetCache(string key, object obj)
        {
            if (GetCache(key) == null)
            {
                Cache cache = HttpRuntime.Cache;
                cache.Insert(key, obj);
            }
        }
        #endregion
    }
}
