using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCache
{
    /// <summary>
    ///  缓存服务的基本接口，定义缓存服务的基本功能
    /// </summary>
    public interface ICacheManager : IHttpRunTimeCacheManager
    {
        void Add(string cacheManagerName, string key, Object obj, int duration);
        void Add(string cacheManagerName, string key, Object obj, string file);
        void Add(string key, Object obj);
        void Add(string cacheManagerName, string key, Object obj);
        void Flush();
        void Flush(string cacheManagerName);
        Object GetData(string key);
        Object GetData(string cacheManagerName, string key);
        T GetData<T>(string key);
        T GetData<T>(string cacheManagerName, string key);
        void Remove(string cacheManagerName, string key);
        void Remove(string key);
    }
}
