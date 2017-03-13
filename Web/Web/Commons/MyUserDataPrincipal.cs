using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Web
{
    /// <summary>
    /// 存放数据的用户实体
    /// </summary>
    class MyUserDataPrincipal : IPrincipal
    {
        /// <summary>
        /// 数据源
        /// </summary>
        private readonly MingshiEntities mingshiDb = new MingshiEntities();
        public int UserId { get; set; }

        //这里可以定义其他一些属性

        /// <summary>
        /// 
        /// </summary>
        public List<int> RoleId { get; set; }

        /// <summary>
        /// 当前用户实例,实现IPrincipal接口必须要的
        /// </summary>
        [ScriptIgnore]    //在序列化的时候忽略该属性
        public IIdentity Identity
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 角色验证,实现IPrincipal接口必须要的
        /// 当使用Authorize特性时，会调用改方法验证角色 
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsInRole(string role)
        {
            //找出用户所有所属角色
            var userroles = mingshiDb.UserRole.Where(u => u.UserId == UserId).Select(u => u.Role.RoleName).ToList();
            var roles = role.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return (from s in roles from userrole in userroles where s.Equals(userrole) select s).Any();
        }

        /// <summary>
        /// 验证用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsInUser(string user)
        {
            //找出用户所有所属角色
            var users = user.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return mingshiDb.User.Any(u => users.Contains(u.UserName));
        }
    }
}
