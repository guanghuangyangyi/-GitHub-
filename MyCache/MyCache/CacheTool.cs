using CacheManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCache
{
    public class CacheTool
    {
        public void test()
        {
            //使用CacheFactory创建了一个名称为getStartedCache的缓存实例，
            //这个缓存实例使用的是SystemRunTime Cache, 内存缓存。
            //一个缓存实例是可以配置多个Handle的
            var cache = CacheFactory.Build("getStartedCache",
                settings =>
                {
                    settings
                    .WithSystemRuntimeCacheHandle("handleName");
                }
                );

            //            var cache1 = CacheFactory.Build<int>("myCache", settings =>
            //              {
            //                  settings
            //          .WithSystemRuntimeCacheHandle("inProcessCache")//内存缓存Handle
            // .And
            //             .WithRedisConfiguration("redis", config =>//Redis缓存配置
            //             {
            //                 config.WithAllowAdmin()
            //.WithDatabase(0)
            //.WithEndpoint("localhost", 6379);
            //             })
            //.WithMaxRetries(1000)//尝试次数
            //.WithRetryTimeout(100)//尝试超时时间
            //                      .WithRedisBackPlate("redis")//redis使用Back Plate
            //.WithRedisCacheHandle("redis", true);//redis缓存handle
            //              });
        }
    }
}
