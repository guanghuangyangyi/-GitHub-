//**************************************************************
//文件名称（File Name）                 Data.cs
//作者(Author)                          yjq
//日期（Create Date）                   2017.03.13
//修改记录(Revision History)
//    R1:
//        修改作者:
//        修改日期:
//        修改原因:
//    R2:
//        修改作者:
//        修改日期:
//        修改原因:
//**************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    public class ResultData
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public ResultData()
        {
            this.dataCount = 0;
            this.success = false;
            this.msg = string.Empty;
            this.data = new object();
            this.excepton = null;
        }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public String msg { get; set; }
        /// <summary>
        /// 数据总条数
        /// </summary>
        public int dataCount { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// 异常信息返回(辅助前端开发人员与后台调试)
        /// StackTrace 属性
        /// InnerException 属性
        /// Message 属性
        /// Data 属性
        /// InnerException 属性
        /// </summary>
        public Exception excepton { get; set; }
        
    }
}
