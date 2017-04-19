//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MyCache
//{
//    public class CacheManager:ICacheManager
//    {
//        #region 常量定义
//        /// <summary>默认缓存策略 60秒</summary>
//        public const string DefalutCacheManager = "Default Cache Manager";
//        /// <summary>基础数据缓存策略 120秒</summary>
//        public const string BaseDataCacheManager = "Base Data Cache Manager";
//        /// <summary>临时数据缓存策略 30秒</summary>
//        public const string TempDataCacheManager = "Temp Data Cache Manager";
//        /// <summary>业务数据缓存策略 80秒</summary>
//        public const string BusinessDataCacheManager = "Business Data Cache Manager";
//        #endregion

//        #region 构造函数
//        /// <summary>
//        /// 实例化 <see cref="T:CacheManager"/> 类.
//        /// </summary>
//        protected CacheManager()
//        {
//        }
//        #endregion

//        #region ICacheManager 实例
//          /// <summary></summary>
//          public static ICacheManager Instance = new CacheManager();
  
//          #endregion
  
//          #region 实现ICacheManager
//          /// <summary>
//          /// 往缓存写数据
//          /// </summary>
//          /// <param name="key">缓存的键值</param>
//          /// <param name="obj">要放入缓存的数据</param>
//          public void Add(string key, Object obj)
//          {
//              Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager
//                  cacheManager = CacheFactory.GetCacheManager();
  
//              cacheManager.Add(key, obj);
//          }
  
//        /// <summary>
//        /// 往缓存写数据
//        /// </summary>
//        /// <param name="cacheManagerName">cache manager 的名字</param>
//        /// <param name="key">缓存的键值</param>
//        /// <param name="obj">要放入缓存的数据</param>
//        public void Add(string cacheManagerName, string key, Object obj)
//        {
//            Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager
//                cacheManager = CacheFactory.GetCacheManager(cacheManagerName);

//            cacheManager.Add(key, obj);
//        }
  
//          /// <summary>
//          /// 往缓存写数据
//          /// </summary>
//          /// <param name="cacheManagerName">cache manager 的名字</param>
//          /// <param name="key">缓存的键值</param>
//          /// <param name="obj">要放入缓存的数据</param>
//          /// <param name="duration">缓存有效时间</param>
//          public void Add(string cacheManagerName, string key, Object obj, int duration)
//          {
//              Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager
//                  cacheManager = CacheFactory.GetCacheManager();
  
//              cacheManager.Add(
//                   key, obj, CacheItemPriority.Normal, null,
//                   new SlidingTime(TimeSpan.FromSeconds(600)));
//             //cacheManager.Add(
//             //     key, obj, CacheItemPriority.Normal, null,
//             //     new SlidingTime(TimeSpan.FromSeconds(ParamUtil.getint(
//             //         ConfigurationManager.AppSettings[BusinessDataCacheManager]))));
//         }
 
 
//         /// <summary>
//         /// 往缓存写数据
//         /// </summary>
//         /// <param name="cacheManagerName">cache manager 的名字</param>
//         /// <param name="key">缓存的键值</param>
//         /// <param name="obj">要放入缓存的数据</param>
//         /// <param name="file">依赖的文件，当文件被修改后缓存自动失效</param>
//         public void Add(string cacheManagerName, string key, Object obj, string file)
//         {
//             Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager
//                 cacheManager = CacheFactory.GetCacheManager(cacheManagerName);
 
//             cacheManager.Add(key, obj, CacheItemPriority.Normal, null, new FileDependency(file));
//         }
 
//         /// <summary>
//         /// 从缓存移除数据
//         /// </summary>
//         /// <param name="key">缓存的键值</param>
//         public void Remove(string key)
//         {
//             Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager
//                 cacheManager = CacheFactory.GetCacheManager( );
//             cacheManager.Remove(key);
//         }
 
//         /// <summary>
//         /// 从缓存移除数据
//         /// </summary>
//         /// <param name="cacheManagerName">cache manager 的名字</param>
//         /// <param name="key">缓存的键值</param>
//         public void Remove(string cacheManagerName, string key)
//         {
//             Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager
//                 cacheManager = CacheFactory.GetCacheManager(cacheManagerName);
//             cacheManager.Remove(key);
//         }
 
 
//         /// <summary>
//         /// 清空缓存里面的所有数据
//         /// </summary>
//         public void Flush()
//         {
//             Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager
//                 cacheManager = CacheFactory.GetCacheManager();
//             cacheManager.Flush();
//         }
 
//         /// <summary>
//         /// 清空缓存里面的所有数据
//         /// </summary>
//         /// <param name="cacheManagerName">cache manager 的名字</param>
//         public void Flush(string cacheManagerName)
//         {
//             Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager
//                 cacheManager = CacheFactory.GetCacheManager(cacheManagerName);
//    }
//}
