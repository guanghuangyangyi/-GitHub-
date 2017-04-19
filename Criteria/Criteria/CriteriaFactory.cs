using Criteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 条件
/// </summary>
namespace Criteria
{
    /// <summary>
    /// 条件工厂
    /// </summary>
    public class CriteriaFactory
    {
        /// <summary>
        /// 创建条件实例
        /// </summary>
        /// <returns></returns>
        public Criteria<T> Create<T>()
        {
            return new Criteria<T>();
        }
    }
}
